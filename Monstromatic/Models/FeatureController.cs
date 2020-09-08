using System.Collections.Generic;
using System.Linq;
using DynamicData;
using Monstromatic.Utils;

namespace Monstromatic.Models
{
    public class FeatureController : IFeatureController
    {
        public SourceList<FeatureBase> SelectedFeatures { get; } = new SourceList<FeatureBase>();

        public void AddFeature(FeatureBase feature)
        {
            SelectedFeatures.AddOnce(feature);

            foreach (var includedFeature in feature.IncludedFeatures)
            {
                SelectedFeatures.AddOnce(includedFeature);
            }
        }

        public void RemoveFeature(FeatureBase feature)
        {
            SelectedFeatures.Remove(feature);
        }

        public IEnumerable<FeatureBase> CreateBundle()
        {
            var mutexes = SelectedFeatures.Items.SelectMany(f => f.MutexFeatures);
            return SelectedFeatures.Items.Except(mutexes);
        }
    }
}