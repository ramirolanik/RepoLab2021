using ProyectoMVC.Data;
using ProyectoMVC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMVC.Logic
{
    public class CustomersLogic
    {
        private readonly Model1 context;

        public CustomersLogic()
        {
            context = new Model1();

        }

        public List<Customers> GetAll()
        {

            return context.Customers.ToList();

        }

        public void Add(Customers newCustomer)
        {
            context.Customers.Add(newCustomer);

            context.SaveChanges();


        }

        public void Delete(string id)
        {
            var customerEliminar = context.Customers.First(c => c.CustomerID == id);

            context.Customers.Remove(customerEliminar);

           
        }

        public void Update(Customers customers)
        {
            var customerUpdate = context.Customers.Find(customers.CustomerID);

            customerUpdate.ContactName = customers.ContactName;

            context.SaveChanges();




        }

    }
}
