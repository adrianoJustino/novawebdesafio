using Microsoft.EntityFrameworkCore;
using NovawebDesafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovawebDesafio.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public readonly ContactContext _context;
        public ContactRepository(ContactContext context) 
        {
            _context = context;
        }
        public async Task<Contact> Create(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return contact;
        }

        public async Task Delete(int id)
        {
            var contactToDelete = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contactToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contact>> Get()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> Get(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task Update(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
