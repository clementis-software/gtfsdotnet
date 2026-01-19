using GtfsDotNet.Attributes;

namespace GtfsDotNet.Model
{
    /// <summary>
    /// Indicates the type of pathway. 
    /// Used to determine the physical nature of the connection between station locations.
    /// </summary>
    [GtfsEnum]
    public enum PathwayMode
    {
        /// <summary>
        /// A walkway. A generally level path without stairs or specialized equipment.
        /// </summary>
        Walkway = 1,

        /// <summary>
        /// Stairs. A path consisting of one or more steps.
        /// </summary>
        Stairs = 2,

        /// <summary>
        /// A moving sidewalk (travelator). A motorized horizontal surface that moves people.
        /// </summary>
        MovingSidewalk = 3,

        /// <summary>
        /// An escalator. A motorized staircase.
        /// </summary>
        Escalator = 4,

        /// <summary>
        /// An elevator (lift).
        /// </summary>
        Elevator = 5,

        /// <summary>
        /// A fare gate. A barrier where passengers must validate a ticket to enter or exit.
        /// </summary>
        FareGate = 6,

        /// <summary>
        /// An exit gate. A gate designed specifically for leaving a restricted area.
        /// </summary>
        ExitGate = 7
    }
}