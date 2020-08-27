namespace Monstromatic.Models
{
    public class LeaderFeature : FeatureBase
    {
        public override string Id => nameof(LeaderFeature);
        public override string DisplayName => "Лидер";
        public override string Description => "Союзная Группа не бежит, пока не бежит Лидер";
    }
}