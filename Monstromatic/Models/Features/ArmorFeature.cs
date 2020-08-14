﻿namespace Monstromatic.Models
{
    public class ArmorFeature : FeatureBase
    {
        public override string Id => nameof(ArmorFeature);
        public override string DisplayName => "Броня/Маг";
        public override int LevelModifier => 0;
        public override int BraveryModifier => 1;
    }
}