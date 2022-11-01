using System.ComponentModel.DataAnnotations;

namespace AddingMachine.Models
{
    /// <summary>
    /// Class to store the history entry in the database
    /// </summary>
    public class History
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// String of the math expression and solution
        /// </summary>
        public string Equation { get; set; } = string.Empty;

        /// <summary>
        /// Used for soft delete, so equations that have been deleted can still be accessed from within the database
        /// </summary>
        public bool Deleted { get; set; } = false;

    }
}
