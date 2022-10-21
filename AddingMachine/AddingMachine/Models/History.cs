using System.ComponentModel.DataAnnotations;

namespace Adding_Machine.Models
{
    public class History
    {
        [Key]
        public int Id { get; set; }
        public string Equation { get; set; } = string.Empty;
        public bool Deleted { get; set; } = false;
    }
}
