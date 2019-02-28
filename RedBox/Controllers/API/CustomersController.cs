using AutoMapper;
using RedBox.Dtos;
using RedBox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RedBox.Controllers.API
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        //GET api/customers
        public /*IEnumerable<CustomerDTO>*/ IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.ToList().Select(Mapper.Map<CustomerModel,CustomerDTO>));
        }
        //GET api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null) return NotFound(); //throw new HttpResponseException(HttpStatusCode.NotFound);
            
            return Ok(Mapper.Map<CustomerModel,CustomerDTO>(customer));
        }
        //Post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDTO, CustomerModel>(customerDTO);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDTO.ID = customer.ID;
            return Created(new Uri(Request.RequestUri+"/"+customerDTO.ID),customerDTO);
        }
        //Put api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);
           
            var custInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (custInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDTO,custInDb);
           
            _context.SaveChanges();
        }

        // DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var custInDb = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (custInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(custInDb);
            _context.SaveChanges();
        }
    }
}
