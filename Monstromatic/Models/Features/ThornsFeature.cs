namespace Monstromatic.Models
{
    public class ThornsFeature : FeatureBase
    {
        public override string Id => nameof(ThornsFeature);
        public override string DisplayName => "Шипы/Маг";
        public override string DetailsDisplayName => "Возмездие";
        public override string Description => "Атакующий получает урон равный уровню";
    }
}