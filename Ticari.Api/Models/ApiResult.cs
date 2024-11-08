namespace Ticari.Api.Models
{
    public class ApiResult
    {
        public string type { get; set; }
        public int status { get; set; }

        public Dictionary<string, string> errors { get; set; } = new Dictionary<string, string>();
        public string traceId { get; set; }
        public bool hasError { get; set; }
    }
}
