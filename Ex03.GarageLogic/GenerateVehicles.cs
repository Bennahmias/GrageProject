using System;


namespace Ex03.GarageLogic
{
    public class GenerateVehicles
    {
        /*TODO: עושה רק שני דברים:
         1.מחזיקה את רשימת האופציות של רכבים (5 אופציות)
        אם נרצה להוסיף טרקטור נוסיף רק אופציה אחת
        2. מייצרת את האובייקטים
        עושה NEW
        אם נרצה להוסיף טרקטור רק נעשה עוד איף אלס ונוסיף טרקטור
         */
        //TODO: הפניה למחלקה זו לייצר אובייקט מתבצעת אחרי שהמשתמש הזין איזה כלי רכב הוא רוצה
        //ולפני שהוא הזין את הפרטים
        //בעולם האמיתי קודם מייצרים מכונית ואז מוסיפים לה אוויר בגלגלים וכו וכו


        public static Vehicle CreateNewVehicle(string i_LicenseNumber, VehicleType.eVehicleType i_VehicleType)
        {
            //TODO: exception if not in range

            EnergyType energyType = CreateEnergyType(i_VehicleType);
            Vehicle vehicle = BuildNewVehicle(i_LicenseNumber, i_VehicleType, energyType);

            return vehicle;
        }

        public static EnergyType CreateEnergyType(VehicleType.eVehicleType i_VehicleType)
        {
            EnergyType energyType;

            switch (i_VehicleType)
            {
                case VehicleType.eVehicleType.GasolineCar:
                    energyType = new Gasoline(GasType.eGasType.Octan95, 52.0f);
                    break;
                case VehicleType.eVehicleType.GasolineMotorcycle:
                    energyType = new Gasoline(GasType.eGasType.Octan98, 6.5f);
                    break;
                case VehicleType.eVehicleType.GasolineTruck:
                    energyType = new Gasoline(GasType.eGasType.Soler, 125.0f);
                    break;
                case VehicleType.eVehicleType.ElectricCar:
                    energyType = new Electric(5.4f);
                    break;
                case VehicleType.eVehicleType.ElectricMotorcycle:
                    energyType = new Electric(2.9f);
                    break;
                default:
                    throw new ArgumentException(); //TODO: add args to this exception
            }

            return energyType;
        }

        public static Vehicle BuildNewVehicle(string i_LicenseNumber, VehicleType.eVehicleType i_VehicleType,
            EnergyType i_EnergyType)
        {
            Vehicle newVehicle;

            switch (i_VehicleType)
            {
                case VehicleType.eVehicleType.GasolineCar:
                case VehicleType.eVehicleType.ElectricCar:
                    newVehicle = new Car(i_LicenseNumber, i_EnergyType);
                    break;
                case VehicleType.eVehicleType.GasolineMotorcycle:
                case VehicleType.eVehicleType.ElectricMotorcycle:
                    newVehicle = new Motorcycle(i_LicenseNumber, i_EnergyType);
                    break;
                case VehicleType.eVehicleType.GasolineTruck:
                    newVehicle = new Truck(i_LicenseNumber, i_EnergyType);
                    break;
                default:
                    throw new ArgumentException(); //TODO: add args to this exception
            }

            return newVehicle;
        }

    }
}


