using DynamicFormBuilder.Data;
using DynamicFormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic; // Add this using directive

namespace DynamicFormBuilder.Controllers
{
    public class FormBuilderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormBuilderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormBuilder/Create - Displays the form builder page
        public IActionResult Create()
        {
            var model = new FormViewModel();
            // Add at least one default field for demonstration if desired
            // model.FormFields.Add(new FormFieldViewModel { Label = "Level 1", Options = new List<string> { "Option 1", "Option 2", "Option 3" } });
            return View(model);
        }

        // POST: FormBuilder/SaveForm - Handles saving the form (via AJAX)
        [HttpPost]
        public async Task<IActionResult> SaveForm([FromBody] FormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var form = new Form
                {
                    Title = model.Title,
                    FormFields = model.FormFields.Select(fvm => new FormField
                    {
                        Label = fvm.Label,
                        IsRequired = fvm.IsRequired,
                        FieldType = fvm.FieldType, // NEW: Map FieldType
                        SelectedOption = fvm.SelectedOption // This will be null initially, populated on preview save
                    }).ToList()
                };

                _context.Forms.Add(form);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Form saved successfully!" });
            }

            // If model state is not valid, return errors
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "Validation errors", errors = errors });
        }

        // GET: FormBuilder/GetFormFieldPartial - Returns a partial view for a new dropdown field
        public IActionResult GetFormFieldPartial()
        {
            return PartialView("_FormFieldPartial", new FormFieldViewModel());
        }


        // GET: FormBuilder - Displays the list of saved forms
        public async Task<IActionResult> Index()
        {
            var forms = await _context.Forms.ToListAsync();
            return View(forms);
        }

        // ... (existing code)

        // GET: FormBuilder/Preview/5 - Displays a saved form for preview
        public async Task<IActionResult> Preview(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .Include(f => f.FormFields)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (form == null)
            {
                return NotFound();
            }

            var formViewModel = new FormViewModel
            {
                Id = form.Id,
                Title = form.Title,
                FormFields = form.FormFields.Select(ff => new FormFieldViewModel
                {
                    Id = ff.Id,
                    Label = ff.Label,
                    IsRequired = ff.IsRequired,
                    SelectedOption = ff.SelectedOption,
                    FieldType = ff.FieldType, // NEW: Pass FieldType to ViewModel for preview rendering
                    // Ensure options are available for display based on FieldType
                    Options = new List<string> { "Option 1", "Option 2", "Option 3" }, // Generic options
                    CountryOptions = new FormFieldViewModel().CountryOptions // All possible country options
                }).ToList()
            };

            return View(formViewModel);
        }

        // POST: FormBuilder/SubmitPreview - Handles saving selected options on the preview page (via AJAX)
        [HttpPost]
        public async Task<IActionResult> SubmitPreview([FromBody] FormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var formToUpdate = await _context.Forms
                    .Include(f => f.FormFields)
                    .FirstOrDefaultAsync(f => f.Id == model.Id);

                if (formToUpdate == null)
                {
                    return Json(new { success = false, message = "Form not found." });
                }

                foreach (var fieldViewModel in model.FormFields)
                {
                    var existingField = formToUpdate.FormFields.FirstOrDefault(ff => ff.Id == fieldViewModel.Id);
                    if (existingField != null)
                    {
                        existingField.SelectedOption = fieldViewModel.SelectedOption;
                    }
                }

                _context.Forms.Update(formToUpdate);
                await _context.SaveChangesAsync();
                return Json(new { success = true, message = "Form data saved successfully!" });
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return Json(new { success = false, message = "Validation errors", errors = errors });
        }
    }
}
    