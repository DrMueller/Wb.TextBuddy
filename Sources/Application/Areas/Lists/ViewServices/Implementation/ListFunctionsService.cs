using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Wb.TextBuddy.Areas.Lists.ViewServices.Implementation
{
    [UsedImplicitly]
    public class ListFunctionsService : IListFunctionsService
    {
        public string AnalyzePerformance(string value)
        {
            var splitEntries = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var newList = new List<string>();

            var measures = new List<string> { "min" };

            for (var i = 0; i < splitEntries.Count(); i++)
            {
                var cells = splitEntries[i].Split("\t");

                if (cells.Length == 2)
                {
                    var measure = cells.First();
                    var hasAny = measures.Any(str => measure.Contains(str));

                    if (hasAny)
                    {
                        var testName = splitEntries[i - 1].Split("\t").ElementAt(1);

                        newList.Add(testName + " = " + measure);
                    }
                }
            }

            newList = newList.OrderBy(f => f).ToList();

            return string.Join(Environment.NewLine, newList);
        }

        public string SortList(string value)
        {
            var splitEntries = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            splitEntries.OrderBy(f => f).ForEach(f => sb.AppendLine(f));

            return sb.ToString();
        }

        public string TransformToCommaSeparatedList(string value)
        {
            var splitEntries = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var splitEntry in splitEntries)
            {
                sb.Append(", ");
                sb.Append(splitEntry);
            }

            sb.Remove(0, 2);

            return sb.ToString();
        }

        public string TransformToCommaSeparatedAndApostrophedList(string value)
        {
            var splitEntries = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var splitEntry in splitEntries)
            {
                sb.Append("\"");
                sb.Append(splitEntry);
                sb.AppendLine("\", ");
            }

            sb.Remove(0, 2);

            return sb.ToString();
        }

        public string FormatNpmDpenendecies(string value)
        {
            var template = "{{ name: '{0}', versionWithRange: '{1}' }},";
            var lines = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            foreach (var line in lines)
            {
                var val = line.Split(" ");

                var result = string.Format(template, val[0], val[1] + val[2]);
                sb.AppendLine(result);

            }

            return sb.ToString();
        }
    }
}