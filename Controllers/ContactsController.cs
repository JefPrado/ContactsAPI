using System;
using ContactsAPI.Entities;
using ContactsAPI.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsAPI.Controllers
{
	[ApiController]
	[Route("Contact/api")]


	public class ContactsController : ControllerBase
	{
		private readonly ContactsDbContext _context;

        public ContactsController(ContactsDbContext context)
		{
			_context = context; 
		}


		[HttpGet]
		public IActionResult GetAll()
		{

			var contact = _context.Contact.ToList();
			return Ok(contact);
		}

		[HttpGet("id")]
		public IActionResult GetById(int id)
		{

            var contact = _context.Contact.SingleOrDefault(c => c.Id == id);

                if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
		}

		[HttpPost]
		public IActionResult Post(contact contact)
		{

			_context.Contact.Add(contact);
			_context.SaveChanges();

			return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);

		}

		[HttpPut("id")]
		public IActionResult Put(int id, contact input)
		{

			var contact = _context.Contact.SingleOrDefault(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

			contact.Update(input.Email, input.Phone, input.Address, input.FullName);

			_context.Contact.Update(contact);
			_context.SaveChanges();

            return NoContent();


		}


		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var contact = _context.Contact.SingleOrDefault(c => c.Id == id);

                if (contact == null)
            {
                return NotFound();
            }

			_context.Contact.Remove(contact);
			_context.SaveChanges();


			return NoContent();

		}


	}
}








