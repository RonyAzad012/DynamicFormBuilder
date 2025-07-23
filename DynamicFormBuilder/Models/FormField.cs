namespace DynamicFormBuilder.Models
{
    public class FormField
    {
        public int Id { get; set; }
        public int FormId { get; set; }
        public string? Label { get; set; }
        public bool IsRequired { get; set; }
        public string? SelectedOption { get; set; } // To store the selected option on preview/submission

        // NEW: To store the type of field (e.g., "generic", "country")
        public string? FieldType { get; set; }

        public Form? Form { get; set; }
    }
}