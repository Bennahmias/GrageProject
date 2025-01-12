using System;

namespace Ex03.GarageLogic
{
    class Progrram
    {
        public static void Main()
        {
            //Gasoline gasoline = new Gasoline(Gasoline.eGasType.Octan95, 15.0f, 30.0f); // Problema 1
            //Car c1 = new Car(Color.eColor.black, DoorsNumber.eDoorsNumber.Four, gasoline, "BYD", "335Bd5E", 50.0f,34.0f,
            //  34.0f); // Problema 2
            //Vehicle c1 = new Car("L45E80", new Gasoline(GasType.eGasType.Octan95, 80.8f));
            GenerateVehicles.CreateNewVehicle("12345", VehicleType.eVehicleType.ElectricCar);
        }
    }
}
