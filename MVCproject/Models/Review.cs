using System.ComponentModel.DataAnnotations;

namespace MVCproject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
    } 
}
