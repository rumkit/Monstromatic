﻿namespace Monstromatic.Models
{
    public class RangeAtackFeature : FeatureBase
    {
        public override string Id => nameof(RangeAtackFeature);
        public override string DisplayName => "Дальний бой";
        public override string Description => "Атакует на дистанции";
    }
}