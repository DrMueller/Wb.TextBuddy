using Newtonsoft.Json;

namespace Mmu.Wb.TextBuddy.Areas.Json.ViewServices.Implementation
{
    public class JsonFunctionsService : IJsonFunctionsService
    {
        public string PrettifyJson(string json)
        {
            var ser = JsonConvert.DeserializeObject(json);
            var formatted = JsonConvert.SerializeObject(ser, Formatting.Indented);

            return formatted;
        }
    }
}