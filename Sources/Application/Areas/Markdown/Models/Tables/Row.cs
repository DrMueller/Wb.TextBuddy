using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables
{
    public class Row
    {
        public Row(IReadOnlyCollection<string> values)
        {
            Guard.ObjectNotNull(() => values);

            Values = values;
        }

        public IReadOnlyCollection<string> Values { get; }
    }
}