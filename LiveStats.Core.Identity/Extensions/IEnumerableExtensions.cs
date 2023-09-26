using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveStats.Core.Identity.Extensions
{
    public static class IEnumerableExtensions
    {
        public static Dictionary<string, List<string>> GroupByFirstWord(this IEnumerable<string> data)
        {
            var result = new Dictionary<string, List<string>>();

            foreach (string item in data)
            {
                string current = item.Split()[0];

                if (result.ContainsKey(current))
                    result[current].Add(item);
                else
                    result.Add(current, new List<string> { item });
            }

            return result;
        }
    }
}
