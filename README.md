# GTFS.NET

**GTFS.NET** is a .NET library that provides a complete implementation of the [General Transit Feed Specification (GTFS)](https://gtfs.org/documentation/schedule/) standard. It allows you to read, validate, and work with GTFS datasets in C# applications.

## Features

- **Full GTFS Schedule support**: Implements all required and optional GTFS files, including:
  - `agency.txt`, `stops.txt`, `routes.txt`, `trips.txt`, `stop_times.txt`, `calendar.txt`, `calendar_dates.txt`
  - Optional files like `frequencies.txt`, `transfers.txt`, `shapes.txt`, `fare_attributes.txt`, `fare_rules.txt`, and many more.
- **Batch reading**: Efficiently read large GTFS CSV files in configurable batches.
- **Validation**: Validate GTFS feeds for required files, required columns, and data consistency.
- **Enum support**: Strongly-typed enums for coded GTFS fields (e.g., `RouteType`, `LocationType`, `WheelchairBoarding`, `PaymentMethod`).

## Installation

You can install the NuGet package:

```bash
dotnet add package GtfsDotNet --version 0.1
```

## Usage

```chsarp
using GtfsDotNet;
using System.IO;

// Load a GTFS feed from a ZIP file
using var stream = File.OpenRead("gtfs-feed.zip");
var feed = new GtfsDirectory(stream);

// Check if all required files are present
bool allRequired = feed.HasAllRequiredFiles();

// Read stops in batches
await feed.ReadFileAsync<Stop>(GtfsFileType.Stops, async stops =>
{
    foreach (var stop in stops)
    {
        Console.WriteLine(stop.Name);
    }
});

// Validate the feed
var validator = new GtfsValidator(stream);
var validationResult = validator.Validate();
if (validationResult.IsValid)
{
    Console.WriteLine("GTFS feed is valid!");
}
```

## License

License

This project is licensed under the MIT License. See the LICENSE file for details.