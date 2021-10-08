using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

//I got this converter from someone on stackoverflow to convert the genres, regions, and writers into an array
namespace MovieAssignmentInterfaces.Converters
{
    public class ToIntArrayConverter : TypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            string[] allElements = text.Split(',');
            int[] elementsAsInteger = allElements.Select(s => int.Parse(s)).ToArray();
            return new List<int>(elementsAsInteger);
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            return string.Join('|', ((List<int>)value).ToArray());
        }
        
    }
}