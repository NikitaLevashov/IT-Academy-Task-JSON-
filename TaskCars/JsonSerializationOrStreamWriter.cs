using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace HomeWork_3
{

    static public class JsonSerializationOrStreamWriter
    {
        private static readonly string path = Path.Combine(Directory.GetCurrentDirectory(),"Cars.json");

        private static readonly string writePath = Path.Combine(Directory.GetCurrentDirectory(),"Cars.txt");

        public static void ShowConsole()
        {
            JsonSerializer serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                var newCars = serializer.Deserialize<List<Car>>(reader);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект десериализован");
                Console.ResetColor();

                double _years =Car.NumberOfYears();
              
                foreach(var item in newCars)
                {
                    double _cheaperYear = Car.CheaperYear(item);

                    double _mileage = Car.MileageYear(item);

                    if (_cheaperYear * _years > item.Price)
                    {
                        Console.WriteLine($"Ваша машина {item.Brand} {item.Model} утилизирована");

                        Console.WriteLine($"Пробег в {item.Data + _years} году составил бы {string.Format("{0:C2}", item.Mileage + (_mileage * _years))}км\n");
                    }

                    else
                    {
                        Console.WriteLine($"{item.Brand} {item.Model} подешевеет через {_years } лет на {String.Format("{0:C2}", Car.CheaperYear(item) * _years)}$");

                        Console.WriteLine($"Пробег {item.Brand} {item.Model} через {_years} лет составит {String.Format("{0:C2}", item.Mileage + (_mileage * _years))} км\n");
                    }
                   
                }

            };
            
        }

        public static void ShowStreamWriter()
        {
            JsonSerializer serializer = new JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            using (StreamReader sr = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sr))
            
            {
                var newCars = serializer.Deserialize<List<Car>>(reader);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект десериализован");
                Console.ResetColor();

                double _years = Car.NumberOfYears();

                foreach (var item in newCars)
                {
                    double _cheaperYear = Car.CheaperYear(item);

                    double _mileage = Car.MileageYear(item);

                    if (_cheaperYear * _years > item.Price)
                    {
                        string str = $"Ваша машина {item.Brand} {item.Model} утилизирована";
                     
                        string str1 = $"Пробег в {item.Data + _years} году составил бы {String.Format("{0:C2}", item.Mileage + (_mileage * _years))}км\n";

                        using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                        {
                            sw.WriteLine(str + "\n" + str1);
                        }  
                    }

                    else
                    {
                        string str = $"{item.Brand} {item.Model} подешевеет через {_years } лет на {String.Format("{0:C2}", Car.CheaperYear(item) * _years)}$";

                        string str1 = $"Пробег {item.Brand} {item.Model} через {_years} лет составит {String.Format("{0:C2}", item.Mileage + (_mileage * _years))}км\n";

                        using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                        {
                            sw.WriteLine(str +"\n"+ str1);
                        }

                    }

                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Объект записан");
                Console.ResetColor();

            };

        }
    }
}
