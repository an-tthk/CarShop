using CarShop.Core.Domain;

namespace CarShop.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> GetAsync(Guid id);
    }
}
