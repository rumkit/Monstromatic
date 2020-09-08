using System.Collections.Generic;
using DynamicData;
using Monstromatic.Utils;

namespace Monstromatic.Models
{
    public interface IFeatureController
    {
        SourceList<FeatureBase> SelectedFeatures { get; }

        void AddFeature(FeatureBase feature);

        void RemoveFeature(FeatureBase feature);

        IEnumerable<FeatureBase> CreateBundle();
    }

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
            return SelectedFeatures.Items;
        }
    }
}
