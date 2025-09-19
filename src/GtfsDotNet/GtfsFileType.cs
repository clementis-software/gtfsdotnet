namespace GtfsDotNet
{
    public enum GtfsFileType
    {
        // Required
        Agency,
        Stops,
        Routes,
        Trips,
        StopTimes,
        Calendar,
        CalendarDates,

        // Optional
        Frequencies,
        Transfers,
        Shapes,
        Levels,
        FeedInfo,
        Pathways,
        BookingRules,
        FareAttributes,
        FareRules,
        FareProducts,
        FareMedia,
        FareLegRules,
        FareLegJoinRules,
        FareTransferRules,
        Areas,
        StopAreas,
        Networks,
        RouteNetworks,
        LocationGroups,
        LocationGroupStops,
        LocationsGeoJson,
        Translations
    }
}
