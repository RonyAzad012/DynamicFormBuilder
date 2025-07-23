using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DynamicFormBuilder.Models
{
    public class FormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Form Title is required.")]
        public string? Title { get; set; }
        public List<FormFieldViewModel> FormFields { get; set; } = new List<FormFieldViewModel>();
    }

    public class FormFieldViewModel
    {
        public int Id { get; set; } // For existing fields
        [Required(ErrorMessage = "Label is required.")]
        public string? Label { get; set; }
        public bool IsRequired { get; set; }
        public List<string> Options { get; set; } = new List<string> { "Option 1", "Option 2", "Option 3" }; // Fixed options
        public string? SelectedOption { get; set; } // For preview/submission
    }
}