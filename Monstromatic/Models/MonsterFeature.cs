using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Monstromatic.Models
{
    public class MonsterFeature
    {  
        public string Key { get; init; }
        public string DisplayName { get; init; }
        public string DetailsDisplayName { get; init; }
        public int LevelModifier { get; init; }
        public int AttackModifier { get; init; }
        public int DefenceModifier { get; init; }
        public string Description { get; init; }
        
        public bool IsHidden { get; init; }
        
        [JsonPropertyName("IncompatibleFeatures")]
        public IReadOnlyCollection<string> IncompatibleFeaturesKeys { get; init; }
        
        [JsonPropertyName("IncludedFeatures")]
        public IReadOnlyCollection<string> IncludedFeaturesKeys { get; init; }
        
        [JsonPropertyName("ExcludedFeatures")]
        public IReadOnlyCollection<string> ExcludedFeaturesKeys { get; init; }
        
        [JsonIgnore]
        public IReadOnlyCollection<MonsterFeature> IncompatibleFeatures { get; init; }
        
        [JsonIgnore]
        public IReadOnlyCollection<MonsterFeature> IncludedFeatures { get; init; }
        
        [JsonIgnore]
        public IReadOnlyCollection<MonsterFeature> ExcludedFeatures { get; init; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is MonsterFeature feature)
                return Equals(feature);
            return false;
        }

        protected bool Equals(MonsterFeature other)
        {
            return other.Key == Key;
        }

        public override int GetHashCode() => Key.GetHashCode();
    }
}
