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
        // [Required(ErrorMessage = "Label is required.")] // Label will now be selected from a list or custom text
        public string? Label { get; set; } // This will hold the actual label text displayed, either pre-defined or custom.
        public bool IsRequired { get; set; }

        // List of predefined labels the user can choose from for this field
        public List<string?> PredefinedLabels { get; set; } = new List<string?>
        {
            "Custom Label", // Always allow a custom label
            "Country",
            "State",
            "City",
            "Occupation",
            "Education Level"
            // Add more predefined labels as needed
        };

        // This will store the *name* of the predefined label selected (e.g., "Country", "Custom Label")
        public string? SelectedLabelName { get; set; } = "Custom Label"; // Default to custom for initial flexibility

        // Options for generic dropdowns (e.g., Option 1, Option 2, Option 3)
        public List<string?> GenericOptions { get; set; } = new List<string?> { "Option 1", "Option 2", "Option 3" };

        // Specific lists for predefined label types
        public List<string?> CountryOptions { get; set; } = new List<string?>
        {
            "United States", "Canada", "Mexico", "United Kingdom", "Germany",
            "France", "Australia", "India", "China", "Japan", "Brazil", "South Africa",
            "Bangladesh", "Pakistan", "Nepal", "Sri Lanka", "Bhutan", "Maldives",
            "Afghanistan", "Myanmar", "Thailand", "Vietnam", "Indonesia", "Malaysia",
            "Singapore", "Philippines", "Egypt", "Nigeria", "Argentina", "Italy", "Spain",
            "Russia", "Saudi Arabia", "United Arab Emirates", "Qatar", "Turkey", "Iran",
            "Iraq", "Syria", "Israel", "Palestine", "Lebanon", "Jordan", "Kuwait",
            "Bahrain", "Oman", "Yemen", "Kazakhstan", "Uzbekistan", "Turkmenistan",
            "Kyrgyzstan", "Tajikistan", "Greece", "Portugal", "Netherlands", "Belgium",
            "Switzerland", "Austria", "Sweden", "Norway", "Denmark", "Finland", "Ireland",
            "New Zealand", "Fiji", "Samoa", "Tonga", "Papua New Guinea", "Solomon Islands",
            "Vanuatu", "Nauru", "Kiribati", "Tuvalu", "Marshall Islands", "Micronesia",
            "Palau", "Algeria", "Morocco", "Tunisia", "Libya", "Sudan", "Ethiopia",
            "Kenya", "Tanzania", "Uganda", "Rwanda", "Burundi", "Somalia", "Eritrea",
            "Djibouti", "South Sudan", "Congo (DRC)", "Congo (Republic)", "Gabon",
            "Cameroon", "Chad", "Niger", "Mali", "Mauritania", "Senegal", "Gambia",
            "Guinea-Bissau", "Guinea", "Sierra Leone", "Liberia", "Ivory Coast", "Ghana",
            "Togo", "Benin", "Burkina Faso", "Central African Republic", "Equatorial Guinea",
            "Sao Tome and Principe", "Comoros", "Madagascar", "Mauritius", "Seychelles",
            "Zimbabwe", "Zambia", "Malawi", "Mozambique", "Botswana", "Namibia",
            "Lesotho", "Eswatini", "Angola", "Cape Verde", "Cuba", "Dominican Republic",
            "Haiti", "Jamaica", "Trinidad and Tobago", "Bahamas", "Barbados", "Belize",
            "Costa Rica", "El Salvador", "Guatemala", "Honduras", "Nicaragua", "Panama",
            "Colombia", "Venezuela", "Ecuador", "Peru", "Bolivia", "Chile", "Paraguay",
            "Uruguay", "Guyana", "Suriname", "French Guiana", "Greenland", "Iceland",
            "Faroe Islands", "Monaco", "San Marino", "Vatican City", "Andorra", "Liechtenstein",
            "Luxembourg", "Malta", "Cyprus", "Albania", "Bosnia and Herzegovina", "Croatia",
            "Kosovo", "Montenegro", "North Macedonia", "Serbia", "Slovenia", "Bulgaria",
            "Romania", "Moldova", "Ukraine", "Belarus", "Lithuania", "Latvia", "Estonia",
            "Poland", "Czech Republic", "Slovakia", "Hungary", "Slovenia", "Ireland",
            "Northern Ireland", "Scotland", "Wales", "England" // More comprehensive list
        };

        public List<string?> StateOptions { get; set; } = new List<string?>
        {
            "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut",
            "Delaware", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa",
            "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan",
            "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire",
            "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio",
            "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota",
            "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia",
            "Wisconsin", "Wyoming"
        };

        public List<string?> OccupationOptions { get; set; } = new List<string?>
        {
            "Accountant", "Engineer", "Doctor", "Teacher", "Software Developer",
            "Designer", "Marketing Specialist", "Nurse", "Salesperson", "Customer Service Rep",
            "Artist", "Writer", "Chef", "Electrician", "Plumber", "Manager", "Analyst"
        };
        // Add more specific option lists for other predefined labels as needed.

        public string? SelectedOption { get; set; } // Stores the selected value on preview/submission
    }
}