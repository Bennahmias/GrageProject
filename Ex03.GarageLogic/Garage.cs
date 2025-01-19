using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, VehicleFile> m_VehicleFilesDict;

        public Garage()
        {
            m_VehicleFilesDict = new Dictionary<string, VehicleFile>();
        }

        public Dictionary<string, VehicleFile> VehicleFilesDict
        {
            get { return m_VehicleFilesDict; }
        }

        public void AddVehicleToGarage(string i_LicenseNumber, VehicleType.eVehicleType i_VehicleTypeNumber, string i_OwnerName, string i_PhoneNumber)
        {
            VehicleFile vehicleFile = new VehicleFile(i_OwnerName, i_PhoneNumber);
            vehicleFile.Vehicle = GenerateVehicles.CreateNewVehicle(i_LicenseNumber, i_VehicleTypeNumber);
            
            VehicleFilesDict.Add(i_LicenseNumber, vehicleFile);
        }
        
        public bool VehicleInGarage(string i_LicenseNumber)
        {
            return VehicleFilesDict.ContainsKey(i_LicenseNumber);
        }
        
        public void SetWheelsDetails(string i_LicenseNumber, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in m_VehicleFilesDict[i_LicenseNumber].Vehicle.VehicleWheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.CurrentAirPressure = i_CurrentAirPressure;
            }
        }
        
        public void SetWheelsPressureToMax(string i_LicenseNumber)
        {
            foreach (Wheel wheel in m_VehicleFilesDict[i_LicenseNumber].Vehicle.VehicleWheels)
            {
                wheel.InflatingToMax(wheel.MaxAirPressure);
            }
        }
        
        public void SetNewStatus(string i_LicenseNumber, VehicleStatus.eVehicleStatus i_newStatusNumber)
        {
            VehicleFilesDict[i_LicenseNumber].Status = i_newStatusNumber;
        }
        
        public List<string> GetListOfFilteredLicensesNumbers(VehicleStatus.eVehicleStatus i_StatusNumber)
        {
            List<string> resultList = new List<string>();

            foreach (KeyValuePair<string, VehicleFile> vehicleFile in m_VehicleFilesDict)
            {
                if (vehicleFile.Value.Status == i_StatusNumber)
                {
                    resultList.Add(vehicleFile.Key);
                }
            }

            return resultList;
        }
        
        public List<string> GetListOfAllLicensesNumbers()
        {
            List<string> resultList = new List<string>();

            foreach (string licenseNumberKey in m_VehicleFilesDict.Keys)
            {
                resultList.Add(licenseNumberKey);
            }

            return resultList;
        }
        
        public void refuelVehicle(Vehicle i_Vehicle, float i_EnergyToAdd, GasType.eGasType i_GasTypeChoice)
        {
            ((Gasoline)i_Vehicle.EnergyType).Refueling(i_EnergyToAdd, i_GasTypeChoice);
        }
        
        public void refuelVehicle(Vehicle i_Vehicle, float i_EnergyToAdd)
        {
            ((Electric)i_Vehicle.EnergyType).BatteryCharging(i_EnergyToAdd);
        }
    }
}
