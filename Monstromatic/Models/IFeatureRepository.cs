using System.Collections.Generic;

namespace Monstromatic.Models
{
    public interface IFeatureRepository
    {
        IEnumerable<FeatureBase> GetFeatures();
    }
}
