using System.Linq;

namespace Core.CoreUtilities
{
    public static class Null
    {
        public static bool None(params object[] items) => items.All(x => x != null);
    }
}