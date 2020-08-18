namespace Monstromatic.Models
{
    public class MassAttackFeature : FeatureBase
    {
        public override string Id => nameof(MassAttackFeature);
        public override string DisplayName => "Мас. атака/Маг";
        public override string Description => "Атакует сразу несколько целей";
    }
}