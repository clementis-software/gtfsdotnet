using GtfsDotNet.Attributes;
using GtfsDotNet.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace GtfsDotNet
{
    public class GtfsDataset
    {
        public List<Agency> Agencies { get; } = new();
        public List<Area> Areas { get; } = new();
        public List<Stop> Stops { get; } = new();
        public List<BookingRule> BookingRules { get; } = new();
        public List<Calendar> Calendars { get; } = new();
        public List<CalendarDate> CalendarDates { get; } = new();
        public List<Fare> Fares { get; } = new();
        public List<RiderCategory> RiderCategories { get; } = new();
        public List<FareLegRule> FareLegRules { get; } = new();
        public List<FareLegJoinRule> FareLegJoinRules { get; } = new();
        public List<FareMedia> FareMedias { get; } = new();
        public List<FareProduct> FareProducts { get; } = new();
        public List<Route> Routes { get; } = new();
        public List<FareRule> FareRules { get; } = new();
        public List<Shape> Shapes { get; } = new();
        public List<Trip> Trips { get; } = new();
        public List<FareTransferRule> FareTransferRules { get; } = new();
        public List<FeedInfo> FeedInfos { get; } = new();
        public List<Frequency> Frequencys { get; } = new();
        public List<Level> Levels { get; } = new();
        public List<LocationGroup> LocationGroups { get; } = new();
        public List<LocationGroupStop> LocationGroupStops { get; } = new();
        public List<Network> Networks { get; } = new();
        public List<Pathway> Pathways { get; } = new();
        public List<RouteNetwork> RouteNetworks { get; } = new();
        public List<StopArea> StopAreas { get; } = new();
        public List<StopTime> StopTimes { get; } = new();
        public List<Timeframe> Timeframes { get; } = new();
        public List<Transfer> Transfers { get; } = new();

        public async Task ReadDataset(GtfsFeedArchive archive)
        {
            var allGtfsDataItemTypes = typeof(GtfsDataItem).Assembly.GetTypes().Where(x => typeof(GtfsDataItem).IsAssignableFrom(x));

            foreach (var type in allGtfsDataItemTypes)
            {
                var gtfsFileAttribute = type.GetCustomAttribute<GtfsFileAttribute>();
                if (gtfsFileAttribute == null)
                    continue;

                var fileType = GtfsFeedArchive.MapFileNameToType(gtfsFileAttribute.Filename);

                if (fileType.HasValue && archive.HasFile(fileType.Value))
                {
                    var readMethod = typeof(GtfsFeedArchive)
                        .GetMethod(nameof(GtfsFeedArchive.ReadFullFileAsync))
                        ?.MakeGenericMethod(type);

                    if (readMethod != null)
                    {
                        var task = (Task)readMethod.Invoke(archive, new object[] { fileType.Value });
                        await task.ConfigureAwait(false);

                        var resultProperty = task.GetType().GetProperty("Result");
                        var items = resultProperty?.GetValue(task) as IEnumerable<GtfsDataItem>;

                        if (items != null)
                        {
                            FillDatasetList(type, items);
                        }
                    }
                }
            }
        }

        private void FillDatasetList(Type type, IEnumerable<GtfsDataItem> items)
        {
            var listProperty = this.GetType()
                .GetProperties()
                .FirstOrDefault(p => p.PropertyType.IsGenericType &&
                                     p.PropertyType.GetGenericArguments()[0] == type);

            if (listProperty != null)
            {
                var list = listProperty.GetValue(this);

                (list as System.Collections.IList)?.Clear();

                var addRangeMethod = list.GetType().GetMethod("AddRange");
                addRangeMethod?.Invoke(list, new object[] { items });
            }
        }

        private void ResolveAll(IEnumerable<GtfsDataItem> list)
        {
            GtfsDataItemResolver.ResolveDataItems(this, list);
        }
    }
}
