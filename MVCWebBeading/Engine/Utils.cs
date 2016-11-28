using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBeading
{
    public class Utils
    {
        private static Utils instance;
        private Utils() {
            StringWaysOfBixelColorDefinition.Add("Most popular of closest to palette");
            StringWaysOfBixelColorDefinition.Add("Closest to palette from average");
            StringWaysOfBixelColorDefinition.Add("Closest to palette from median");
            namesToEnumWays[StringWaysOfBixelColorDefinition.ElementAt(0)] = WaysOfBixelColorDefinition.MostPopularOfClosestToPalette;
            namesToEnumWays[StringWaysOfBixelColorDefinition.ElementAt(1)] = WaysOfBixelColorDefinition.ClosestFromPaletteToAverage;
            namesToEnumWays[StringWaysOfBixelColorDefinition.ElementAt(2)] = WaysOfBixelColorDefinition.ClosestFromPaletteToMedian;
        }
        public static Utils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Utils();
                }
                return instance;
            }
        }
        public IPaletteColor getMostPopularColorFromDict( Dictionary<IPaletteColor, int> dict)
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
        public ICollection<string> StringWaysOfBixelColorDefinition = new List<string>();
        public Dictionary<string, WaysOfBixelColorDefinition> namesToEnumWays = new Dictionary<string, WaysOfBixelColorDefinition>();
    }

}