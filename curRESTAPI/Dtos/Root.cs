using static System.Runtime.InteropServices.JavaScript.JSType;

namespace curRESTAPI.Dtos
{
    public record Root
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public List<Rate> rates { get; set; }
    }
}
