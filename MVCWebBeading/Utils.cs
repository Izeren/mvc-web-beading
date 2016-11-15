using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public class Utils
    {
        public static IPaletteColor getMostPopularColorFromDict( Dictionary<IPaletteColor, int> dict)
        {
            KeyValuePair<IPaletteColor, int> currentBest = dict.First();
            foreach (KeyValuePair<IPaletteColor, int> pair in dict)
            {
                if (pair.Value > currentBest.Value)
                {
                    currentBest = pair;
                }
            }
            return currentBest.Key;
        }

    }

}