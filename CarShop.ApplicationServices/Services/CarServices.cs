using CarShop.Core.Domain;
using CarShop.Core.ServiceInterface;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;

namespace CarShop.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly ShopContext _context;

        public CarServices(ShopContext context)
        {
            _context = context;
        }

        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }
    }
}
