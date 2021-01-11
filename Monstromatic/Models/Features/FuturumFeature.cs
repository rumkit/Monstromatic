namespace Monstromatic.Models
{
    public class FuturumFeature : FeatureBase
    {
        public override string Id => nameof(FuturumFeature);
        public override string DisplayName => "Маг,Si-Fi,Экзот";
        public override int LevelModifier => 1;
    }
}