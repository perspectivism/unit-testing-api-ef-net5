using CustomerApi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Tests.Mocks
{
    public class TestCustomerDbSet : TestDbSet<Customer>
    {
        public override ValueTask<Customer> FindAsync(params object[] keyValues)
        {            
            var customer = this.SingleOrDefault(product => product.Id == (long)keyValues.Single());
            return new ValueTask<Customer>(customer);
        }
    }
}
