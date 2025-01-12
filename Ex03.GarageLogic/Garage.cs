using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private List<VehicleFile> m_VehicleFilesList;

        public Garage()
        {
            m_VehicleFilesList = new List<VehicleFile>();
        }

        public void AddVehicleToGarage(string i_LicenseNumber, int i_VehicleTypeNumber, string i_OwnerName, string i_PhoneNumber)
        {
            VehicleFile newFile = new VehicleFile(i_OwnerName, i_PhoneNumber);
            VehicleType.eVehicleType vehicleType = (VehicleType.eVehicleType)i_VehicleTypeNumber; //TODO:check if converting works
            GenerateVehicles.CreateNewVehicle(//TODO:continue here);
        }

        private bool checkIfVehicleInGarage(string i_LicenseNumber)
        {
            bool vehicleInGarage = false;
            foreach (VehicleFile file in m_VehicleFilesList)
            {
                if (String.Equals(file.Vehicle.LicenseNumber, i_LicenseNumber))
                {
                    vehicleInGarage = true;
                }
            }

            return vehicleInGarage;
        }
    }
}
