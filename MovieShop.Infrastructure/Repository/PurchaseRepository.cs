using MovieShop.ApplicationCore.Contracts.Repository;
using MovieShop.ApplicationCore.Entities;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repository
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieDbContext _context) : base(_context)
        {
        }
    }
}
