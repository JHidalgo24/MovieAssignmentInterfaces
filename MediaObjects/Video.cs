using System;
using CsvHelper.Configuration.Attributes;

namespace AbstractMovieAssignment.MediaObjects
{
    public class Video : Media
    {

        [Name("format")] public string Format { get; set; }
        [Name("length")] public int Length { get; set; }
        [Name("regions")] public string RegionsString { get; set; }
        private int[] Region { get; set; }

        public int[] RegionArray()
        {
            Region = Array.ConvertAll(RegionsString.Split('|'), input => Int32.Parse(input));
            return Region;
        }

        public override string Display()
        {
            return $"VideoId:{Id} Title:{title} Format:{Format} Length:{Length} Region(s):{RegionsString}";
        }
    }
}