using System.Collections.Generic;

namespace NovawebDesafio.Model
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> PhoneNumber { get; set; }
    }
}
