namespace Monstromatic.Models
{
    [HideFeature]
    public class GroupFeature : FeatureBase
    {
        public override string Id => nameof(GroupFeature);
        public override string DisplayName => "Группа";
        public override int LevelModifier => 1;
        public int Count { get; set; }
    }
}