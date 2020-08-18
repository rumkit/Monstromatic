namespace Monstromatic.Models
{
    public class FlyingFeature : FeatureBase
    {
        public override string Id => nameof(FlyingFeature);
        public override string DisplayName => "Летающий";
        public override string Description => "Уязвим только к дальним атакам (пока не кончится храбрость)";
    }
}