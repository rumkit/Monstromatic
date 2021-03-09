using System.Collections.Generic;

namespace Monstromatic.Models
{
    public record Monster (string Name, int BaseLevel, IReadOnlyList<string> Features);
}
