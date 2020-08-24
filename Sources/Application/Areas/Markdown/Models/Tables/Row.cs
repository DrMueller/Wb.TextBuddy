using System.Collections.Generic;
using System.Text;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
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

        public void AppendMarkdownToString(StringBuilder sb)
        {
            Values.ForEach(
                val =>
                {
                    sb.Append("|");
                    sb.Append(val.Trim());
                });

            sb.AppendLine("|");
        }
    }
}