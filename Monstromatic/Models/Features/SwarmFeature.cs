namespace Monstromatic.Models
{
    public class SwarmFeature : FeatureBase
    {
        public override string Id => nameof(SwarmFeature);
        public override string DisplayName => "Нематериальный ";
        public override string DetailsDisplayName => "Неуязвим к физическим атакам";
        public override string Description => "Неуязвим к физическим атакам";
    }
}