namespace DockerTemplate.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        [Key]
        public int CarId { get; set; }

        public DateTimeOffset Created { get; set; }

        public int Cylinders { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public DateTimeOffset Modified { get; set; }
    }
}
