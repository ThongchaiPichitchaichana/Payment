
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentAPI.Models
{
    public class PaymentContext : DbContext
    {
       // public PaymentContext(DbContextOptions<PaymentContext> options) : base(options)
       // {

       // }
       public void OnConfiguring(DbContextOptionsBuilder ob) 
        {
            ob.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
            //base.OnConfiguring(ob);
        }
        public DbSet<Payment> Payment { get; set; }
    }
}
