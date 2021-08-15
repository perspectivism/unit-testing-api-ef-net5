using CustomerApi.Controllers;
using CustomerApi.Models;
using CustomerApi.Tests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CustomerApi.Tests
{
    public class TestCustomersController
    {
        [Fact]
        public async Task Get_all_customers_succeeds()
        {
            var ctx = CreateDbContextWithCustomers();
            var sut = new CustomersController(ctx);

            var task = await sut.GetCustomers();

            Assert.Equal(task.Value.Count(), ctx.Customers.Count());
        }

        [Fact]
        public async Task Get_customer_with_valid_id_succeeds()
        {
            long id = 1;
            var ctx = CreateDbContextWithCustomers();
            var cust = ctx.Customers.FirstOrDefault(c => c.Id == id);
            var sut = new CustomersController(ctx);

            var task = await sut.GetCustomer(id);
            
            Assert.Equal(task.Value.Id, cust.Id);
        }

        [Fact]
        public async Task Get_customer_with_invalid_id_fails()
        {
            var ctx = CreateDbContextWithCustomers();
            var sut = new CustomersController(ctx);

            var task = await sut.GetCustomer(int.MaxValue);

            var result = task.Result as NotFoundResult;
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Updating_customer_with_valid_id_succeeds()
        {
            var ctx = CreateDbContextWithCustomers();
            var cust = ctx.Customers.FirstOrDefault();
            var sut = new CustomersController(ctx);

            cust.Name = System.Guid.NewGuid().ToString();
            var result = (await sut.PutCustomer(cust.Id, cust)) as NoContentResult;

            var updatedCust = ctx.Customers.SingleOrDefault(c => c.Id == cust.Id);
            Assert.NotNull(result);
            Assert.Equal(cust.Name, updatedCust.Name);
        }

        [Fact]
        public async Task Updating_customer_with_mismatched_id_fails()
        {
            var ctx = CreateDbContextWithCustomers();
            var cust = ctx.Customers.FirstOrDefault();
            var sut = new CustomersController(ctx);

            var result = (await sut.PutCustomer(cust.Id + 1, cust)) as BadRequestResult;

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Adding_a_new_customer_succeeds()
        {            
            var ctx = CreateDbContextWithCustomers();
            var cust = new Customer { Id = int.MaxValue, Name = "George" };
            var sut = new CustomersController(ctx);

            var task = await sut.PostCustomer(cust);
            
            var result = task.Result as CreatedAtActionResult;
            Assert.NotNull(result);
            Assert.Equal((result.Value as Customer).Id, cust.Id);
        }

        [Fact]
        public async Task Deleting_existing_customer_succeeds()
        {
            var ctx = CreateDbContextWithCustomers();
            var cust = ctx.Customers.FirstOrDefault();
            var sut = new CustomersController(ctx);

            var result = (await sut.DeleteCustomer(cust.Id)) as NoContentResult;

            Assert.NotNull(result);
            Assert.Null(ctx.Customers.SingleOrDefault(c => c.Id == cust.Id));
        }

        [Fact]
        public async Task Deleting_non_existing_customer_fails()
        {
            var ctx = CreateDbContextWithCustomers();
            var sut = new CustomersController(ctx);

            var result = (await sut.DeleteCustomer(int.MaxValue)) as NotFoundResult;

            Assert.NotNull(result);
        }

        private TestCustomerContext CreateDbContextWithCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Bob" },
                new Customer { Id = 2, Name = "Mary" },
                new Customer { Id = 3, Name = "Joe" }
            };

            var ctx = new TestCustomerContext();
            customers.ForEach(c => ctx.Customers.Add(c));

            return ctx;
        }
    }
}
