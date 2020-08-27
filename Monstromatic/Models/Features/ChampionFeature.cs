namespace Monstromatic.Models
{
    public class ChampionFeature : FeatureBase
    {
        public override string Id => nameof(ChampionFeature);
        public override string DisplayName => "Чемпион";
        public override string Description => "Мораль чемпиона не завист от морали Лидера или Группы";
    }
}