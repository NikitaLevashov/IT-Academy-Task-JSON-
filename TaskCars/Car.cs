using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork_3
{
    [Serializable]
   public class Car
    { 

        [JsonProperty("machine_brand")]
        public string Brand { get; set; }


        [JsonProperty("model_car")]
        public string Model { get; set; }
       
        [JsonProperty("data")]
        public double Data { get; set; }


        [JsonProperty("mileage")]
        public int Mileage { get; set; }


        [JsonProperty("starting_price")]
        public double Starting_Prace { get; set; }


        [JsonProperty("price")]
        public double Price { get; set; }

        public static double CheaperYear(Car car)
        {
            return (car.Starting_Prace - car.Price) / (DateTime.Now.Year - car.Data);
        }

        public static double NumberOfYears()
        {
            Console.WriteLine("Введите количество n-лет для расчета: ");

            double.TryParse(Console.ReadLine(), out double year);

            return year;

        }

        public static double MileageYear(Car car)
        {
            return car.Mileage / (DateTime.Now.Year - car.Data);
        }

    }
}
