using System.Collections.Generic;

namespace Monstromatic.Models
{
    public class MonsterDefinition
    {
        public string Name { get; }

        public int Level { get; private set; }

        public IReadOnlyList<FeatureBase> Features { get; }
    }
}
