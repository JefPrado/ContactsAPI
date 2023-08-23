using System;
namespace ContactsAPI.Entities
{

	public class contact
	{
        public contact()
        {
            CreatedAt = DateTime.Now;
        }

        protected void Update(string fullName, string email, long phone, string address)
        {
            
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        internal void Update(string email, long phone, string address, string fullName)
        {
            FullName = fullName;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public int Id { get; set; }

		public string FullName { get; set; }

		public string Email { get; set; }

		public long Phone { get; set; }

		public string Address { get; set; }

		public DateTime CreatedAt { get; set; }

	}
}

