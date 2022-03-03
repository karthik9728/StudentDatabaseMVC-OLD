using System.ComponentModel.DataAnnotations;

namespace StudentOnline.Models
{
    public class Student
    {
        [Key]
        public int Student_Id { get; set; }
        [Required]
        [Display(Name ="Student Name")]
        public string? Student_Name { get; set; }
        [Required]
        [Display(Name ="Department")]
        public string? Student_Department { get; set; }  
        [Required]
        public int Year { get; set; }
        public DateTime Created { get; set; }= DateTime.Now;
    }
}
