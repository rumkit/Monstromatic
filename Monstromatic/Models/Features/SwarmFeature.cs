namespace Monstromatic.Models
{
    public class SwarmFeature : FeatureBase
    {
        public override string Id => nameof(SwarmFeature);
        public override string DisplayName => "Конструк. Путсут. Рой";
        public override string DetailsDisplayName => "Нематериальный";
        public override string Description => "Неуязвим к физическим атакам";
    }
}