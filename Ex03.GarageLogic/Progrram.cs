using System;

namespace Ex03.GarageLogic
{
    class Progrram
    {
        public static void Main()
        {
            Gasoline gasoline = new Gasoline(Gasoline.e_GasType.Octan95, 15.0f, 30.0f); // Problema 1
            Car c1 = new Car(Color.e_Color.black, DoorsNumber.e_DoorsNumber.Four, gasoline, "BYD", "335Bd5E", 50.0f,34.0f,
                34.0f); // Problema 2
        }
    }
}
