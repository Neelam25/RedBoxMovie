using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedBox.Models;
using RedBox.ViewModel;

namespace RedBox.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
              _context = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomerViewModel = new CustomerMembershipViewModel
            {
                Customer = new CustomerModel(),
                MembershipTypes  = membershipTypes
            };
            return View("CustomerFormView", newCustomerViewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            var customerFormData = new CustomerMembershipViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerFormView", customerFormData); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerModel customer)
        {
            Console.Write("Parameter");
            if (!ModelState.IsValid)
            {
                var custMembershipViewModel = new CustomerMembershipViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerFormView", custMembershipViewModel);
            }
            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var custInDb = _context.Customers.SingleOrDefault(c => c.ID == customer.ID);
                custInDb.Name = customer.Name;
                custInDb.DOB = customer.DOB;
                custInDb.IsSubscribedToMembership = customer.IsSubscribedToMembership;
                custInDb.MembershipTypeId = customer.MembershipTypeId;
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index","Customer");
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(cust=>cust.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c=>c.ID == id);
            if (customer == null) return HttpNotFound();

            return View(customer);
        }

        public IEnumerable<CustomerModel> GetCustomerModels()
        {
            return new List<CustomerModel>
            {
                new CustomerModel{ID=1,Name="Neelam"},
                new CustomerModel{ID=2,Name="Advait "},
                new CustomerModel{ID=3,Name="Rajan"},
                new CustomerModel{ID=4,Name="Prachi"},
            };
        }
    }
}