namespace Monstromatic.Models
{
    public class PredatorFeature : FeatureBase
    {
        public override string Id => nameof(PredatorFeature);
        public override string DisplayName => "Хищник";
        public override int LevelModifier => 1;
    }
}