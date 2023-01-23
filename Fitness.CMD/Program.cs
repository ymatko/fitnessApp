using System;
using System.Globalization;
using Fitness.BL.Controller;
using Fitness.BL.Model;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Enter user name");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("date of birthday");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);



            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("E - enter food intake");
                Console.WriteLine("A - enter activity");
                Console.WriteLine("Q - exit");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();

                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} from {item.Start.ToShortTimeString()} to {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter Name exercise");

            var name = Console.ReadLine();

            var energy = ParseDouble("energy consumption per minute");

            var begin = ParseDateTime("start exercise");
            var end = ParseDateTime("end exercise");

            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var prots = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");

            var weight = ParseDouble("portion weight");
            var product = new Food(food, calories, prots, fats, carbs);


            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter {value} (MM.dd.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Invalid format {value}");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid format {name}");
                }
            }
        }
    }
}
