using System.Linq;
using DynamicData;

namespace Monstromatic.Utils
{
    static class SourceListExtensions
    {
        public static void AddOnce<T>(this SourceList<T> sourceList, T item)
        {
            if (!sourceList.Items.Contains(item))
                sourceList.Add(item);
        }
    }
}
