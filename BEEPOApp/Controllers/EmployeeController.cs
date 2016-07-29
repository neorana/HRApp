using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using BEEPOApp.DAL;
using BEEPOApp.Models;
using BEEPOApp.Persistence;
using PagedList;


namespace BEEPOApp.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly HRISContext _context;
        private readonly IUnitofWork _unitofWork;

        public EmployeeController()
        {
            _context = new HRISContext();
            _unitofWork = new UnitofWork(_context);
        }

        // GET: Employee
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "firstname_desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "lastname_desc" : "";
            ViewBag.MiddleNameSortParm = String.IsNullOrEmpty(sortOrder) ? "middlename_desc" : "";
            ViewBag.BirthDateSortParm = "birthdate_desc";
            ViewBag.DateHiredSortParm = "datehired_desc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

     
            var employees = _unitofWork.Employee.GetEmployees();

            //Filtering input search
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(e => e.Lastname.Contains(searchString)
                                       || e.FirstName.Contains(searchString)
                                       || e.MiddleName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstname_desc":
                    employees = employees.OrderByDescending(e => e.FirstName);
                    break;

                case "lastname_desc":
                    employees = employees.OrderByDescending(e => e.Lastname);
                    break;

                case "middlename_desc":
                    employees = employees.OrderByDescending(e => e.MiddleName);
                    break;

                case "birthdate_desc":
                    employees = employees.OrderByDescending(e => e.BirthDate);
                    break;

                case "datehired_desc":
                    employees = employees.OrderByDescending(e => e.DateHired);
                    break;

                default:
                    employees = employees.OrderBy(e => e.Lastname);
                    break;
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
      
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DateHired,FirstName,Lastname,MiddleName,BirthDate")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitofWork.Employee.Add(employee);
                    _unitofWork.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*ex*/)
            {
                ModelState.AddModelError("", "Unable to save changes.");
            }
            

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employeeToUpdate = _context.Employees.Find(id);
            if (TryUpdateModel(employeeToUpdate, "",
               new[] { "FirstName","Lastname","MiddleName","BirthDate","DateHired" }))
            {
                try
                {
                    _unitofWork.Commit();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* ex */)
                {
                    ModelState.AddModelError("", "Unable to save changes.");
                }
            }
            return View(employeeToUpdate);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed.";
            }
            Employee employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Employee employee = _context.Employees.Find(id);
                _context.Employees.Remove(employee);
                _unitofWork.Commit();
            }
            catch (DataException /* ex */)
            {
                return RedirectToAction("Delete", new {id, saveChangesError = true });
            }
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
