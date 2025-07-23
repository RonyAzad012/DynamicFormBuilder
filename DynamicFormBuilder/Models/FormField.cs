namespace DynamicFormBuilder.Models
{
    public class FormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string? Label { get; set; } // This will store the actual label text selected or typed (e.g., "Country", "My Custom Field")
        public bool IsRequired { get; set; }
        public string? SelectedOption { get; set; } // To store the selected option on preview/submission

        // NEW: Store the type of label/options this field uses (e.g., "Country", "Custom Label", "Occupation")
        public string? SelectedLabelType { get; set; }

        public Form Form { get; set; }
    }
}