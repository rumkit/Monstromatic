using System.Collections.Generic;
using DynamicData;

namespace Monstromatic.Models
{
    public interface IFeatureController
    {
        SourceList<FeatureBase> SelectedFeatures { get; }

        void AddFeature(FeatureBase feature);

        void RemoveFeature(FeatureBase feature);

        IEnumerable<FeatureBase> CreateBundle();
    }
}
