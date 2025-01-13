using System;
using System.Collections.Generic;


namespace Ex03.ConsoleUI
{
    public class GarageConsoleUI
    {
        public static void PrintWelcome()
        {
            Console.WriteLine("Welcome to the Garage System!\nPress Enter to see the menu");
            Console.ReadLine();
            Console.Clear();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("==== Garage Menu ====");
            Console.WriteLine("1. Add a New Vehicle");
            Console.WriteLine("2. Show License Numbers Of Vehicles In The Garage");
            Console.WriteLine("3. Change Vehicle Status");
            Console.WriteLine("4. Inflate Wheels To Maximum");
            Console.WriteLine("5. Refuel a Gasoline Vehicle");
            Console.WriteLine("6. Charging an Electric Vehicle");
            Console.WriteLine("7. Show All Vehicles Details");
            Console.WriteLine("8. Exit The System");
            Console.Write("Please select an option: ");
        }
    }
}
