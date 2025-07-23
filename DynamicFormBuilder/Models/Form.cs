using Microsoft.AspNetCore.Http;

namespace DynamicFormBuilder.Models
{
    public class Form
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public ICollection<FormField>? FormFields { get; set; }
    }
}