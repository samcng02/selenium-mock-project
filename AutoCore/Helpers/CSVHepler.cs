using CsvHelper;
using System.Globalization;

namespace AutoCore.Helpers
{
    /// <summary>
    /// CSVHelper support read data from file csv
    /// </summary>
    public class CSVHelper
    {
        /// <summary>
        /// Get data after read from csv
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetDataFromCsvHelper<T>(string fileName)
        {
            //Get path, which stored file csv:
            string csvPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, $@"..\..\..\TestData\{fileName}.csv"));
            //
            using (var reader = new StreamReader(csvPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<T>().ToList();
            }
        }
    }
}
