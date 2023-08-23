using System;
using ContactsAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContactsAPI.Persistence
{
	public class ContactsDbContext : DbContext
	{

		public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
		{ }

		public DbSet<contact> Contact { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{

            builder.Entity<contact>(o =>
			{ 
				o.HasKey(c => c.Id);
            });
        }
    }
}










//public BooksDbContext(DbContextOptions<BooksDbContext> options) : base(options)

//        { }

//public DbSet<Book> Books { get; set; }


//protected override void OnModelCreating(ModelBuilder builder)
//{

//    builder.Entity<Book>(o =>
//    {
//        o.HasKey(j => j.Id);

//    });