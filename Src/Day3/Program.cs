using Businesslogic;
using Businesslogic.Locations;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.WriteResult(Test1, FileType.Test1Sample, 4361);
            //Helper.WriteResult(Test1, FileType.Test1);
            //Helper.WriteResult(Test2, FileType.Test1Sample, 467835);
            Helper.WriteResult(Test2, FileType.Test1);
        }

        private static int Test1(List<string> input)
        {
            var grid = new Grid<string>();
            grid.Parse(input.Select(i => i.ToArray().Select(i => i.ToString()).ToList()).ToList());
            var foundValues = new List<int>();
            foreach (var y in Enumerable.Range(0, grid.SizeY))
            {
                var value = 0;
                var found = false;
                foreach (var x in Enumerable.Range(0, grid.SizeX))
                {
                    if(grid.GetValue(x,y).IsNumeric())
                    {
                        value = value * 10 + Convert.ToInt32(grid.GetValue(x, y));
                        if(grid.GetAdjoiningAll(x,y).Any(i => i.Value != "." && !i.Value.IsNumeric()))
                            found = true;
                    }
                    else
                    {
                        if(found)
                        {
                            foundValues.Add(value);
                        }
                        found = false;
                        value = 0;
                    }
                }
                if (found)
                {
                    foundValues.Add(value);
                }
            }
            return foundValues.Sum();
        }

        private static int Test2(List<string> input)
        {
            var grid = new Grid<string>();
            grid.Parse(input.Select(i => i.ToArray().Select(i => i.ToString()).ToList()).ToList());
            var foundValues = new List<(CoordinateValue<string> coord, int value)>();
            foreach (var y in Enumerable.Range(0, grid.SizeY))
            {
                var value = 0;
                CoordinateValue<string> coordicate = null;
                var found = false;
                foreach (var x in Enumerable.Range(0, grid.SizeX))
                {
                    if (grid.GetValue(x, y).IsNumeric())
                    {
                        value = value * 10 + Convert.ToInt32(grid.GetValue(x, y));
                        if (grid.GetAdjoiningAll(x, y).Any(i => i.Value == "*"))
                        {
                            found = true;
                            coordicate = grid.GetAdjoiningAll(x, y).FirstOrDefault(i => i.Value == "*");
                        }
                    }
                    else
                    {
                        if (found)
                        {
                            foundValues.Add((coordicate,value));
                        }
                        found = false;
                        value = 0;
                    }
                }
                if (found)
                {
                    foundValues.Add((coordicate, value));
                }
            }
            var results = foundValues.GroupBy(i => i.coord, new CoordinateValueComparer())
                                     .Where(i => i.Count() == 2)
                                     .Select(i => i.First().value * i.Last().value);
            return results.Sum();
            //return 0;
        }
    }
    class CoordinateValueComparer : IEqualityComparer<CoordinateValue<string>>
    {
        public bool Equals(CoordinateValue<string>? a, CoordinateValue<string>? b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.X == b.X
                && a.Y == b.Y;
        }

        public int GetHashCode(CoordinateValue<string> item) => item.X ^ item.Y;
    }
}
