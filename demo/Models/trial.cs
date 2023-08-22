using System.ComponentModel.DataAnnotations;

namespace demo.Models
{
    public class trial
    {
        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
