namespace Monstromatic.Models
{
    public class MassAttackFeature : FeatureBase
    {
        public override string Id => nameof(MassAttackFeature);
        public override string DisplayName => "Масс. атака";
        public override string DetailsDisplayName => "Массовая атака";
        public override string Description => "Атакует сразу несколько целей";
    }
}