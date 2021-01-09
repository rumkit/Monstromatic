namespace Monstromatic.Models
{
    public class RegenerationFeature : FeatureBase
    {
        public override string Id => nameof(RegenerationFeature);
        public override string DisplayName => "Регенeрация/Маг";
        public override int DefenceModifier => 1;
    }
}