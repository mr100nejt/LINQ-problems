using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_problems
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> classGrades = new List<string>()
          {
              "80,100,92,89,65",
              "93,81,78,84,69",
              "73,88,83,99,64",
              "98,100,66,74,55"
          };
            Console.WriteLine(FilterByTh(new List<string>() { "the", "bike", "this", "it", "tenth", "mathematics" }, "th"));
            Console.WriteLine(RemoveDuplicates(new List<string>() { "Mike", "Brad", "Nevin", "Ian", "Mike" }));
            Console.WriteLine(ReturnAverageGrades(classGrades));
            Console.WriteLine(GetLetterFrequency("wwwooorrrddd"));
          
            Console.ReadLine();
        }
        static string FilterByTh(List<string> words, string delimiter)
        {
          
          IEnumerable<string> results = words.Where(w => w.Contains(delimiter));
            string result = "";
            foreach (string word in results)
            {
                if (result.Length > 0)
                {
                    result += ", ";
                }
                result += word;
            }
            return result;
        }
        static string RemoveDuplicates(List<string> names)
        {
          
          IEnumerable<string> results = names.Distinct();
            string result = "";
            foreach (string word in results)
            {
                if (result.Length > 0)
                {
                    result += ", ";
                }
                result += word;
            }
            return result;
        }
        static double ReturnAverageGrades(List<string> classGrades)
        {
            List<double> individualAverages = new List<double>();
            foreach (string initialValue in classGrades)
            {
                var individualvalues = initialValue.Split(',').OrderBy(s => s).Select(s => Convert.ToDouble(s)).ToList();
                var updated = individualvalues.Where(d => d > individualvalues.Min()).Average();
                individualAverages.Add(updated);
            }
            var totalAverage = individualAverages.Average();
            return totalAverage;
        }
        static string GetLetterFrequency(string word)
        {
            var characters = word.ToUpper().ToCharArray().OrderBy(c => c).GroupBy(c => c);
            string result = "";
            foreach (var c in characters)
            {
                result += c.Key;
                result += c.Count();
            }
            return result;
        }
    }
}
