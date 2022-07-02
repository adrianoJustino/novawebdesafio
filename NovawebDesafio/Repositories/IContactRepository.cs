using NovawebDesafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovawebDesafio.Repositories
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> Get();

        Task<Contact> Get(int id);

        Task<Contact> Create(Contact contact);

        Task Update(Contact contact);

        Task Delete(int id);
     }
}
