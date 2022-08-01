using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Source
{
    public static class ListExtensions
    {
        public static int GetRandomNotExistedElement(this IEnumerable<int> collection)
        {
            collection = collection.ToList();
            while (true)
            {
                var random = Random.Range(int.MinValue, int.MaxValue);
                var isNumberUnique = !collection.Contains(random);
                if (isNumberUnique) return random;
            }

        }
    }
}