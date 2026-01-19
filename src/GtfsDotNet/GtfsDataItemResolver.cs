using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GtfsDotNet.Attributes;
using GtfsDotNet.Model;

namespace GtfsDotNet
{
    public class GtfsDataItemResolver
    {
        public static void ResolveDataItems(GtfsDataset dataset, IEnumerable<GtfsDataItem> dataItems)
        {
            Parallel.ForEach(dataItems, item => ResolveDataItem(dataset, item, new HashSet<GtfsDataItem>()));
        }

        public static void ResolveDataItem(GtfsDataset dataset, GtfsDataItem dataItem)
        {
            ResolveInternal(dataset, dataItem, new HashSet<GtfsDataItem>());
        }

        internal static void ResolveDataItem(GtfsDataset dataset, GtfsDataItem dataItem, HashSet<GtfsDataItem> visited)
        {
            ResolveInternal(dataset, dataItem, visited);
        }

        private static void ResolveInternal(GtfsDataset dataset, GtfsDataItem dataItem, HashSet<GtfsDataItem> visited)
        {
            if (dataItem == null || visited.Contains(dataItem)) return;
            visited.Add(dataItem);

            var type = dataItem.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                var refPropAttr = prop.GetCustomAttribute<GtfsReferencePropertyAttribute>();
                if (refPropAttr != null)
                {
                    ResolveReferenceProperty(dataset, dataItem, prop, refPropAttr, visited);
                }

                var childCollAttr = prop.GetCustomAttribute<GtfsChildCollectionAttribute>();
                if (childCollAttr != null)
                {
                    ResolveChildCollection(dataset, dataItem, prop, childCollAttr, visited);
                }
            }
        }

        private static void ResolveReferenceProperty(GtfsDataset dataset, GtfsDataItem dataItem, PropertyInfo prop, GtfsReferencePropertyAttribute attr, HashSet<GtfsDataItem> visited)
        {
            var fkProperty = dataItem.GetType().GetProperty(attr.IdPropertyName);
            var fkValue = fkProperty?.GetValue(dataItem) as string;

            if (string.IsNullOrEmpty(fkValue)) return;

            var targetType = prop.PropertyType;
            var sourceList = GetDatasetList(dataset, targetType);

            if (sourceList != null)
            {
                var linkedItem = sourceList.Cast<GtfsDataItem>().FirstOrDefault(x => IsMatchingId(x, fkValue));
                if (linkedItem != null)
                {
                    prop.SetValue(dataItem, linkedItem);
                    ResolveInternal(dataset, linkedItem, visited);
                }
            }
        }

        private static void ResolveChildCollection(GtfsDataset dataset, GtfsDataItem dataItem, PropertyInfo prop, GtfsChildCollectionAttribute attr, HashSet<GtfsDataItem> visited)
        {
            var pkProperty = dataItem.GetType().GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<GtfsIdAttribute>() != null);
            var pkValue = pkProperty?.GetValue(dataItem) as string;

            if (string.IsNullOrEmpty(pkValue)) return;

            var childType = prop.PropertyType.GetGenericArguments()[0];
            var sourceList = GetDatasetList(dataset, childType);

            if (sourceList != null)
            {
                var children = sourceList.Cast<GtfsDataItem>()
                    .Where(child => {
                        var fkProp = child.GetType().GetProperty(attr.IdPropertyName);
                        return fkProp?.GetValue(child)?.ToString() == pkValue;
                    }).ToList();

                var listType = typeof(List<>).MakeGenericType(childType);
                var collection = (IList)Activator.CreateInstance(listType);
                foreach (var child in children)
                {
                    collection.Add(child);
                    ResolveInternal(dataset, child, visited);
                }

                prop.SetValue(dataItem, collection);
            }
        }

        private static IEnumerable GetDatasetList(GtfsDataset dataset, Type itemType)
        {
            return dataset.GetType().GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericArguments()[0] == itemType)
                ?.GetValue(dataset) as IEnumerable;
        }

        private static bool IsMatchingId(GtfsDataItem item, string id)
        {
            return item.Id == id;
        }
    }
}