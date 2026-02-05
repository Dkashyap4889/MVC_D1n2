using System.ComponentModel.DataAnnotations;

namespace MVC_Assignment.Models
{ 
    public class CustomerModel
    {
        [Key]
        public string CustomerID { get; set; }
        
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(100, MinimumLength =3, ErrorMessage = "Customer Name must be between 3 and 100 characters long")]
        public string CustomerName { get; set; }
        
        [Range(18, 123, ErrorMessage = "Age must be between 18 and 123")]
        public int Age { get; set; }

    }
}