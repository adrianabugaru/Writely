using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Writely.Models;

namespace Writely.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly WritelyContext _context;

        public DocumentsController(WritelyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var allDocumentModel = new AllDocument
            {
                QuickNotes = _context.QuickNotes.ToList(),
                Notebooks = _context.Notebooks.ToList()
            };

            return View(allDocumentModel);
        }


        public ActionResult Create()
        {
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string documentType)
        {
            if (string.IsNullOrWhiteSpace(documentType))
            {
                // Handle invalid input by displaying a message or returning to the form.
                // You can add a message to TempData and display it on the Create view.
                TempData["ErrorMessage"] = "Please select a document type.";
                return RedirectToAction("Create");
            }

            if (documentType == "QuickNote")
            {
                // Redirect to the "Create Quick Note" page
                return RedirectToAction("Create", "QuickNotes");
            }
            else if (documentType == "Notebook")
            {
                // Redirect to the "Create Notebook" page
                return RedirectToAction("Create", "Notebooks");
            }
            else
            {
                // Handle unsupported document type (e.g., display an error message)
                // You can add a message to TempData and display it on the Create view.
                TempData["ErrorMessage"] = "Unsupported document type selected.";
                return RedirectToAction("Create");
            }
        }
    }
}
