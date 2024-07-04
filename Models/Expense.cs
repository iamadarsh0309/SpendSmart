using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class Expense
    {
        public int Id { get; set; } // primary key for our db

        public decimal Value { get; set; }

        [Required] 
        public string? Description { get; set; } 
    }
}
