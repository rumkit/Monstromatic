using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class SmallSizeFeature : FeatureBase
    {
        public override string Id => nameof(SmallSizeFeature);
        public override string DisplayName => "Малый размер";
        public override int LevelModifier => 1;
        public override string Description => "Неспособен наносить ран, если не ядовит";

        public override IEnumerable<string> IncompatibleFeatures
        {
            get
            {
                yield return nameof(BigSizeFeature);
                yield return nameof(GiantFeature);
            }
        }
    }
}