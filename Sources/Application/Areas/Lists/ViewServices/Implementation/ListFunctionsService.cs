using System;
using System.Text;

namespace Mmu.Wb.TextBuddy.Areas.Lists.ViewServices.Implementation
{
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
    }
}