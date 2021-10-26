using System.Collections.Generic;

namespace Sales.BlazorClient.Exceptions
{
    public class ProblemsDetails
    {
        public string Title { get; set; }
        public string Detail { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public IDictionary<string, string> InvalidParams { get; set; }
    }
}
