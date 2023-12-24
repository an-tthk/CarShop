using CarShop.Core.Domain;
using CarShop.Core.Dto;
using CarShop.Core.ServiceInterface;

namespace CarShop.CarTest
{
    public class CarTest : TestBase
    {
        [Fact]
        public async Task ShouldNot_AddEmptyCar_WhenReturnResult()
        {
            var dto = new CarDto()
            {
                Brand = "BMW",
                Model = "X5",
                ModelYear = 2011,
                Price = 1000000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var result = await Svc<ICarServices>().Create(dto);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_DeleteByIdCar_WhenDeleteCar()
        {
            CarDto car = MockCarData();

            var addCar = await Svc<ICarServices>().Create(car);
            var result = await Svc<ICarServices>().Delete(car.Id.GetValueOrDefault());

            Assert.Equal(result, addCar);
        }

        [Fact]
        public async Task ShouldNot_UpdateCar_WhenNotUpdateData()
        {
            CarDto dto = MockCarData();
            await Svc<ICarServices>().Create(dto);

            CarDto nullUpdate = MockNullCarData();
            await Svc<ICarServices>().Update(nullUpdate);

            var nullId = nullUpdate.Id;

            Assert.True(dto.Id == nullId);
        }

        private CarDto MockCarData()
        {
            return new CarDto()
            {
                Brand = "BMW",
                Model = "X5",
                ModelYear = 2011,
                Price = 1000000,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
        }

        private CarDto MockNullCarData()
        {
            var car = MockCarData();
            car.Id = null;

            return car;
        }
    }
}
