namespace backend.Models.Constants;

public class TrainingOccupation
{
    public string Abbr { get; set; }
    public string Name { get; set; }
    public List<string> Skills { get; set; } = ["Skill 1", "Skill 2", "Skill 3", "Skill 4", "Skill 5"];
}