namespace DockerTemplate
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DockerTemplate.Models;

    public static class CarData
    {
        public static List<Car> Get() => new List<Car>()
                        {
                            new Car()
                            {
                                CarId = 1,
                                Created = DateTimeOffset.UtcNow.AddDays(-8),
                                Cylinders = 8,
                                Make = "Lambourghini",
                                Model = "Countach",
                                Modified = DateTimeOffset.UtcNow.AddDays(-8),
                            },
                            new Car()
                            {
                                CarId = 2,
                                Created = DateTimeOffset.UtcNow.AddDays(-7),
                                Cylinders = 10,
                                Make = "Mazda",
                                Model = "Furai",
                                Modified = DateTimeOffset.UtcNow.AddDays(-6),
                            },
                            new Car()
                            {
                                CarId = 3,
                                Created = DateTimeOffset.UtcNow.AddDays(-7),
                                Cylinders = 6,
                                Make = "Honda",
                                Model = "NSX",
                                Modified = DateTimeOffset.UtcNow.AddDays(-3),
                            },
                            new Car()
                            {
                                CarId = 4,
                                Created = DateTimeOffset.UtcNow.AddDays(-5),
                                Cylinders = 6,
                                Make = "Lotus",
                                Model = "Esprit",
                                Modified = DateTimeOffset.UtcNow.AddDays(-3),
                            },
                            new Car()
                            {
                                CarId = 5,
                                Created = DateTimeOffset.UtcNow.AddDays(-4),
                                Cylinders = 6,
                                Make = "Mitsubishi",
                                Model = "Evo",
                                Modified = DateTimeOffset.UtcNow.AddDays(-2),
                            },
                            new Car()
                            {
                                CarId = 6,
                                Created = DateTimeOffset.UtcNow.AddDays(-4),
                                Cylinders = 12,
                                Make = "McLaren",
                                Model = "F1",
                                Modified = DateTimeOffset.UtcNow.AddDays(-1),
                            },
                        };
    }
}
