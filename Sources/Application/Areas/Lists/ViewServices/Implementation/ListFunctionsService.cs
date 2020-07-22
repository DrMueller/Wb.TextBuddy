using System;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;

namespace Mmu.Wb.TextBuddy.Areas.Lists.ViewServices.Implementation
{
    [UsedImplicitly]
    public class ListFunctionsService : IListFunctionsService
    {
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

        public string SortList(string value)
        {
            var splitEntries = value.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();

            splitEntries.OrderBy(f => f).ForEach(f => sb.AppendLine(f));

            return sb.ToString();
        }
    }
}