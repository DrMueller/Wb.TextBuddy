namespace Mmu.Wb.TextBuddy.Areas.Lists.ViewServices
{
    public interface IListFunctionsService
    {
        string AnalyzePerformance(string value);

        string SortList(string value);

        string TransformToCommaSeparatedList(string value);

        string TransformToCommaSeparatedAndApostrophedList(string value);

        string FormatNpmDpenendecies(string value);
    }
}