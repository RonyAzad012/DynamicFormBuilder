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
        // Options for generic dropdowns (e.g., Option 1, Option 2, Option 3)
        public List<string> Options { get; set; } = new List<string> { "Option 1", "Option 2", "Option 3" };
        public string? SelectedOption { get; set; } // For preview/submission

        // New: To distinguish field types (e.g., "generic", "country")
        public string FieldType { get; set; } = "generic"; // Default to generic

        // New: List of countries for the country dropdown
        public List<string> CountryOptions { get; set; } = new List<string>
        {
            "United States", "Canada", "Mexico", "United Kingdom", "Germany",
            "France", "Australia", "India", "China", "Japan", "Brazil", "South Africa",
            "Egypt", "Nigeria", "Argentina", "Italy", "Spain", "Russia", "Saudi Arabia",
            "United Arab Emirates", "Bangladesh" // Added Bangladesh
            // Add more countries as needed
        };
    }
}