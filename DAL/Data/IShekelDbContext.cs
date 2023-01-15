using Microsoft.EntityFrameworkCore;
using ShekelAPI.Entities.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ShekelAPI.DAL.Data
{
    public interface IShekelDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Factory> Factories { get; set; }
        DbSet<FactoriesToCustomer> FactoriesToCustomers { get; set; }
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
