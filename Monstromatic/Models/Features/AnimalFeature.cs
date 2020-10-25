namespace Monstromatic.Models
{
    public class AnimalFeature : FeatureBase
    {
        public override string Id => nameof(AnimalFeature);
        public override string DisplayName => "Животное/Злое";
        public override int LevelModifier => 1;
    }
}
