namespace Monstromatic.Models
{
    public class SwarmFeature : FeatureBase
    {
        public override string Id => nameof(SwarmFeature);
        public override string DisplayName => "Рой/Потусторонний";
        public override int LevelModifier => 1;
        public override string Description => "Неуязвим к физическим атакам";
    }
}