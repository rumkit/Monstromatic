using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Monstromatic.Models
{
    class ReflectiveFeatureRepository : IFeatureRepository
    {
        public IEnumerable<FeatureBase> GetFeatures()
        {
            return Assembly.GetCallingAssembly().GetTypes()
                .Where(t => t.BaseType == typeof(FeatureBase))
                .Where(t => t.CustomAttributes.All(attr => attr.AttributeType != typeof(HideFeatureAttribute)))
                .Select(t => Activator.CreateInstance(t) as FeatureBase);
        }
    }
}