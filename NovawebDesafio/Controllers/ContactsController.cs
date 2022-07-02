using Microsoft.AspNetCore.Mvc;
using NovawebDesafio.Model;
using NovawebDesafio.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NovawebDesafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Contact>> Get() 
        {
            return await _contactRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContacts(int id) 
        {
            return await _contactRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> PostContacts([FromBody] Contact contact) 
        {
            var newContact = await _contactRepository.Create(contact);
            return CreatedAtAction(nameof(GetContacts), new { id = newContact.Id }, newContact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> Delete(int id) 
        {
            var contactToDelete = await _contactRepository.Get(id);
            if (contactToDelete == null)
                return NotFound();

            await _contactRepository.Delete(contactToDelete.Id);
            return NoContent();

        }

        [HttpPut]
        public async Task<ActionResult> PutContacts(int id, [FromBody] Contact contact) 
        {
            if (id != contact.Id)
                return BadRequest();

                await _contactRepository.Update(contact);
            return NoContent();
        }
    }
}
