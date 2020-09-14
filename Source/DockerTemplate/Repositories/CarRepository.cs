namespace DockerTemplate.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using DockerTemplate.Data;
    using DockerTemplate.Models;
    using Microsoft.EntityFrameworkCore;

    public class CarRepository : ICarRepository
    {
        private readonly CarsDbContext context;

        public CarRepository(CarsDbContext context) => this.context = context;

        public Task<Car> AddAsync(Car car, CancellationToken cancellationToken)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            this.context.Cars.Add(car);
            car.CarId = this.context.Cars.Max(x => x.CarId) + 1;
            return Task.FromResult(car);
        }

        public Task DeleteAsync(Car car, CancellationToken cancellationToken)
        {
            if (this.context.Cars.Contains(car))
            {
                this.context.Cars.Remove(car);
            }

            return Task.CompletedTask;
        }

        public Task<Car> GetAsync(int carId, CancellationToken cancellationToken)
        {
            var car = this.context.Cars.FirstOrDefault(x => x.CarId == carId);
            return Task.FromResult(car);
        }

        public Task<List<Car>> GetCarsAsync(
            int? first,
            DateTimeOffset? createdAfter,
            DateTimeOffset? createdBefore,
            CancellationToken cancellationToken) =>
            Task.FromResult(this.context.Cars
                .If(createdAfter.HasValue, x => x.Where(y => y.Created > createdAfter.Value))
                .If(createdBefore.HasValue, x => x.Where(y => y.Created < createdBefore.Value))
                .If(first.HasValue, x => x.Take(first.Value))
                .ToList());

        public Task<List<Car>> GetCarsReverseAsync(
            int? last,
            DateTimeOffset? createdAfter,
            DateTimeOffset? createdBefore,
            CancellationToken cancellationToken) =>
            Task.FromResult(this.context.Cars
                .If(createdAfter.HasValue, x => x.Where(y => y.Created > createdAfter.Value))
                .If(createdBefore.HasValue, x => x.Where(y => y.Created < createdBefore.Value))
                .If(last.HasValue, x => x.TakeLast(last.Value))
                .ToList());

        public Task<bool> GetHasNextPageAsync(
            int? first,
            DateTimeOffset? createdAfter,
            CancellationToken cancellationToken) =>
            Task.FromResult(this.context.Cars
                .If(createdAfter.HasValue, x => x.Where(y => y.Created > createdAfter.Value))
                .Skip(first.Value)
                .Any());

        public Task<bool> GetHasPreviousPageAsync(
            int? last,
            DateTimeOffset? createdBefore,
            CancellationToken cancellationToken) =>
            Task.FromResult(this.context.Cars
                .If(createdBefore.HasValue, x => x.Where(y => y.Created < createdBefore.Value))
                .SkipLast(last.Value)
                .Any());

        public Task<int> GetTotalCountAsync(CancellationToken cancellationToken) => this.context.Cars.CountAsync(cancellationToken: cancellationToken);

        public Task<Car> UpdateAsync(Car car, CancellationToken cancellationToken)
        {
            if (car is null)
            {
                throw new ArgumentNullException(nameof(car));
            }

            var existingCar = this.context.Cars.FirstOrDefault(x => x.CarId == car.CarId);
            existingCar.Cylinders = car.Cylinders;
            existingCar.Make = car.Make;
            existingCar.Model = car.Model;
            return Task.FromResult(car);
        }
    }
}
