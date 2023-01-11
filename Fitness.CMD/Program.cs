﻿using System;
using Fitness.BL.Controller;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Enter user name");
            var name = Console.ReadLine();

            Console.WriteLine("Enter gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter birth date");
            var birthdate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthdate, weight, height);
            userController.Save();
        }
    }
}
