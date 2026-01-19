using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;

namespace GtfsDotNet
{
    public class GtfsDataReader<TData> where TData : GtfsDataItem, new ()
    {
        public async Task ReadDataAsync(GtfsFeedArchive archive, Stream inputStream, Func<IEnumerable<TData>, Task> processBatchFunc, int batchSize = 1024, CancellationToken cancellationToken = default)
        {
            using var streamReader = new StreamReader(inputStream, Encoding.UTF8);

            VerifyNotEndOfStream(streamReader);

            string headerLine = streamReader.ReadLine();
            var headers = ParseCsvLine(headerLine);

            var mapper = new GtfsDataMapper(typeof(TData));
            List<TData> buffer = new List<TData>();

            while (!streamReader.EndOfStream && !cancellationToken.IsCancellationRequested)
            {
                string line = streamReader.ReadLine();
                var values = ParseCsvLine(line);
                TData obj = new TData();
                obj.Dataset = archive;

                for (int i = 0; i < headers.Count; i++)
                {
                    if (!mapper.Mappings.TryGetValue(headers[i], out var prop))
                        continue;

                    if (i >= values.Count)
                        continue;

                    var raw = values[i]?.Trim();
                    if (string.IsNullOrEmpty(raw))
                        continue;

                    object? converted = ConvertValue(raw, prop.PropertyType);
                    prop.SetValue(obj, converted);

                    if (mapper.IdProperty != null && mapper.IdProperty == prop)
                        obj.Id = raw;
                }

                buffer.Add(obj);

                if (buffer.Count >= batchSize)
                {
                    await processBatchFunc(buffer);
                    buffer.Clear();
                }
            }

            if (buffer.Any())
            {
                await processBatchFunc(buffer);
                buffer.Clear();
            }
        }

        private void VerifyNotEndOfStream(StreamReader streamReader)
        {
            if (streamReader.EndOfStream)
                throw new InvalidOperationException("The input stream seems to be empty. EndOfStream was reached before reading the first line.");
        }

        private static object? ConvertValue(string raw, Type targetType)
        {
            if (targetType == typeof(string))
                return raw;

            var underlying = Nullable.GetUnderlyingType(targetType) ?? targetType;

            if (string.IsNullOrEmpty(raw))
                return null;

            if (underlying.IsEnum)
            {
                if (int.TryParse(raw, out int enumValue))
                    return Enum.ToObject(underlying, enumValue);

                return Enum.Parse(underlying, raw, ignoreCase: false);
            }

            if (underlying == typeof(int))
                return int.Parse(raw, CultureInfo.InvariantCulture);

            if (underlying == typeof(double))
                return double.Parse(raw, CultureInfo.InvariantCulture);

            if (underlying == typeof(DateTime))
                return DateTime.ParseExact(raw, "yyyyMMdd", CultureInfo.InvariantCulture);

            if (underlying == typeof(TimeSpan))
                return TimeSpan.ParseExact(
                    raw,
                    @"hh\:mm\:ss",
                    CultureInfo.InvariantCulture
                );

            if (underlying == typeof(bool))
                return raw == "1" || raw.Equals("true", StringComparison.OrdinalIgnoreCase);

            return Convert.ChangeType(raw, underlying, CultureInfo.InvariantCulture);
        }

        // RFC4180-compliant CSV line parser
        private static List<string> ParseCsvLine(string line)
        {
            var result = new List<string>();
            var sb = new StringBuilder();
            bool inQuotes = false;

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (inQuotes)
                {
                    if (c == '"')
                    {
                        if (i + 1 < line.Length && line[i + 1] == '"')
                        {
                            sb.Append('"'); // Escaped quote
                            i++;
                        }
                        else
                        {
                            inQuotes = false;
                        }
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else
                {
                    if (c == ',')
                    {
                        result.Add(sb.ToString());
                        sb.Clear();
                    }
                    else if (c == '"')
                    {
                        inQuotes = true;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            result.Add(sb.ToString());
            return result;
        }

        internal async Task<string[]> ReadHeadersAsync(Stream stream)
        {
            using var streamReader = new StreamReader(stream);

            VerifyNotEndOfStream(streamReader);

            return ParseCsvLine(await streamReader.ReadLineAsync()).ToArray();
        }
    }

}
