using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Hotel.Models
{
    public class Status
    {
        internal IEnumerable<object> Errors;

        public string Message { get; set; }
        public int StatusCode { get; set; }
        public bool? Succeeded { get; internal set; }
    }
}
