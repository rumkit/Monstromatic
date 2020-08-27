using System;

namespace Monstromatic.Models
{
    // Feature isn't displayed in the main grid view
    [AttributeUsage(AttributeTargets.Class)]
    public class HideFeatureAttribute : Attribute
    {
    }
}
