using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace HealthChecksBenchMark
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SomeClass>();
        }
    }

    public class SomeClass
    {
        public static List<string> Inputs = new List<string>()
        {
            "input",
            "Another input",
            "",
            null,
            DateTime.Now.Hour > 0 ? null : "", // Can't optimise this away
            DateTime.Now.Hour > 0 ? "" : null,
        };


        private readonly DateTime _cantOptimiseThis = DateTime.Now;

        string SomeNormalArgCheckMethod(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            return input + _cantOptimiseThis;
        }

        string HeathCheckStaticChecksMethod(string input)
        {
            Guard.ArgumentNotNull(nameof(input), input);

            return input + _cantOptimiseThis;
        }

        [Benchmark]
        public string CheckInline()
        {
            var output = "";
            foreach (var input in Inputs)
            {
                try
                {
                    output += SomeNormalArgCheckMethod(input);
                }
                catch (ArgumentNullException e)
                {
                    output += $"null! {e.Message}";
                }
            }

            return output;        
        }

        [Benchmark]
        public string CheckStatic()
        {
            var output = "";
            foreach (var input in Inputs)
            {
                try
                {
                    output += HeathCheckStaticChecksMethod(input);
                }
                catch (ArgumentNullException e)
                {
                    output += $"null! {e.Message}";
                }
            }

            return output;
        }
    }
}
