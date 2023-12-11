using Businesslogic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        private static object lockObject = new object();
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 35);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test1Sample, 46);
            Helper.WriteResult(Test2, FileType.Test1);
        }

        private static long Test1(List<string> input)
        {
            var results = new List<long>();
            var maps = Parse(input);
            foreach (var seed in maps.Seeds)
            {
                var location = maps.GetResult(seed);

                results.Add(location);
#if DEBUG
                Console.WriteLine($"===========================================================================");
#endif
            }
            return results.Min();
        }

        private static long Test2(List<string> input)
        {
            var result = long.MaxValue;
            var maps = Parse(input);
            var seeds = input.First().Substring(7).Split(' ').Select(i => Convert.ToInt64(i)).ToList();
            var index = maps.Seeds.Count() / 2;
            foreach(var run in maps.Seeds.Batch(2))
            {
                var start = run.First();
                var end = start + run.Last()+1;
                var options = new ParallelOptions() { MaxDegreeOfParallelism = 1000 };
                Parallel.For(start, end, options, (seed) =>
                {
                    WriteLine(seed.ToString());
                    var location = maps.GetResult(seed);
                    lock(lockObject)
                    {
                        if (result > location)
                        {
                            result = location;
                            Console.WriteLine($"{seed}:{result}");
                        }
                    }
                    WriteLine($"===========================================================================");
                });
            }
            return result;
        }

        public static Maps Parse(List<string> input)
        {
            var maps = new Maps();
            maps.Seeds = input.First().Substring(7).Split(' ').Select(i => Convert.ToInt64(i)).ToList();
            var mode = "";
            foreach(var line in input)
            {
                if (line.Contains("map:"))
                {
                    mode = line;
                    continue;
                }
                if (line == "")
                {
                    mode = string.Empty; 
                    continue;
                }
                if (mode == "")
                {
                    continue;
                }
                switch (mode)
                {
                    case "seed-to-soil map:":
                        maps.SeedToSoil.Add(Map.Parse(line));
                        continue;
                    case "soil-to-fertilizer map:":
                        maps.SoilToFertilizer.Add(Map.Parse(line));
                        continue;
                    case "fertilizer-to-water map:":
                        maps.FertilizerToWater.Add(Map.Parse(line));
                        continue;
                    case "water-to-light map:":
                        maps.WaterToLight.Add(Map.Parse(line));
                        continue;
                    case "light-to-temperature map:":
                        maps.LightToTemperature.Add(Map.Parse(line));
                        continue;
                    case "temperature-to-humidity map:":
                        maps.TemperatureToHumidity.Add(Map.Parse(line));
                        continue;
                    case "humidity-to-location map:":
                        maps.HumidityToLocation.Add(Map.Parse(line));
                        continue;
                }
            }
            return maps;
        }
        public static void WriteLine(string input)
        {
#if DEBUG
            Console.WriteLine(input);
#endif
        }
    }
    public class Maps
    {
        public List<long> Seeds = new ();
        public List<Map> SeedToSoil = new ();
        public List<Map> SoilToFertilizer = new ();
        public List<Map> FertilizerToWater = new ();
        public List<Map> WaterToLight = new ();
        public List<Map> LightToTemperature = new ();
        public List<Map> TemperatureToHumidity = new ();
        public List<Map> HumidityToLocation = new ();
        public long GetResult(long seed)
        {
            Program.WriteLine($"Seed: {seed.ToString().Pastel(Color.Red)}");
            var soil = GetValue(SeedToSoil, seed);
            Program.WriteLine($"Soil: {soil.ToString().Pastel(Color.Red)}");
            var fertilizer = GetValue(SoilToFertilizer, soil);
            Program.WriteLine($"Fertilizer: {fertilizer.ToString().Pastel(Color.Red)}");
            var water = GetValue(FertilizerToWater, fertilizer);
            Program.WriteLine($"Water: {water.ToString().Pastel(Color.Red)}");
            var light = GetValue(WaterToLight, water);
            Program.WriteLine($"Light: {light.ToString().Pastel(Color.Red)}");
            var temp = GetValue(LightToTemperature, light);
            Program.WriteLine($"Temperature: {temp.ToString().Pastel(Color.Red)}");
            var humidity = GetValue(TemperatureToHumidity, temp);
            Program.WriteLine($"Humidity: {humidity.ToString().Pastel(Color.Red)}");
            var location = GetValue(HumidityToLocation, humidity);
            Program.WriteLine($"location: {location.ToString().Pastel(Color.Green)}");
            return location;
        }

        private long GetValue(List<Map> maps, long input)
        {
            foreach(var map in maps)
            {
                if (input >= map.SourceStart && input <= map.SourceStart + map.Length)
                {
                    return map.DestinationStart + input - map.SourceStart;
                }
            }
            return input;
        }
    }

    [DebuggerDisplay("{DestinationStart} {SourceStart} {Length}")]
    public class Map
    {
        public long DestinationStart { get; set; }
        public long SourceStart { get; set; }
        public long Length { get; set; }
        public static Map Parse(string input)
        {
            var args = input.Split(' ').Select(i => Convert.ToInt64(i)).ToArray();
            return new(args[0], args[1], args[2]);
        }

        public Map(long destinationStart, long sourceStart, long length)
        {
            DestinationStart = destinationStart;
            SourceStart = sourceStart;
            Length = length -1;
        }
    }
}
