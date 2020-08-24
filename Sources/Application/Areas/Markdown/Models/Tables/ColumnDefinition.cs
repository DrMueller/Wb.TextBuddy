using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.TextBuddy.Areas.Markdown.Models.Tables
{
    public class ColumnDefinition
    {
        public ColumnDefinition(IReadOnlyCollection<string> headerValues)
        {
            Guard.ObjectNotNull(() => headerValues);

            HeaderValues = headerValues;
        }

        public IReadOnlyCollection<string> HeaderValues { get; }
    }
}