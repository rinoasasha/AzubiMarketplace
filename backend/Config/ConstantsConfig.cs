using System.Reflection.Metadata;
using backend.Models.Constants;

namespace backend.Config;

public class ConstantsConfig
{
    public static readonly List<Location> Locations = [
        new Location()
        {
                Abbr = "Fe",
                Name = "Feuerbach"
        },
        new Location()
        {
            Abbr = "We",
            Name = "Wernau"
        }
    ];

    public static readonly List<TrainingOccupation> TrainingOccupations =
    [
        new TrainingOccupation()
        {
            Abbr = "FI-AE",
            Name = "Fachinformatik - Anwendungsentwicklung"
        }
    ];
}