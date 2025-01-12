using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string,VehicleFile> m_VehicleFilesList;

        public Garage()
        {
            m_VehicleFilesList = new Dictionary<string,VehicleFile>();
        }

        public void AddVehicleToGarage(string i_LicenseNumber, int i_VehicleTypeNumber, string i_OwnerName, string i_PhoneNumber)
        {
            VehicleFile vehicleFile = new VehicleFile(i_OwnerName, i_PhoneNumber);
            VehicleType.eVehicleType vehicleType = (VehicleType.eVehicleType)i_VehicleTypeNumber; //TODO:check if converting works
            Vehicle newVehicle = GenerateVehicles.CreateNewVehicle(i_LicenseNumber, vehicleType);
            vehicleFile.Vehicle = newVehicle;
            m_VehicleFilesList.Add(i_LicenseNumber,vehicleFile);
        }

        private bool checkIfVehicleInGarage(string i_LicenseNumber)
        {
            return m_VehicleFilesList.ContainsKey(i_LicenseNumber);
        }

        public void SetEnergyOfVehicle()
        {
            //TODO:fill, problem with polymorphism
        }

        public void SetWheelsDetails(string i_LicenseNumber, string i_ManufacturerName, float i_CurrentAirPressure)
        {
            foreach (Wheel wheel in m_VehicleFilesList[i_LicenseNumber].Vehicle.VehicleWheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.Inflating(i_CurrentAirPressure);
            }
        }

        public void SetWheelsPressureToMax(string i_LicenseNumber)
        {
            foreach (Wheel wheel in m_VehicleFilesList[i_LicenseNumber].Vehicle.VehicleWheels)
            {
                wheel.InflatingToMax(wheel.MaxAirPressure);
            }
        }

        public void SetNewStatus(string i_LicenseNumber, int i_newStatusNumber)
        {
            VehicleStatus.eVehicleStatus newStatus = (VehicleStatus.eVehicleStatus)i_newStatusNumber; //TODO:Check if converting ok
            m_VehicleFilesList[i_LicenseNumber].Status = newStatus;
        }

        public List<string> GetListOfFilteredLicensesNumbers(int i_StatusNumber)
        {
            List<string> resultList = new List<string>();
            if (i_StatusNumber == 3) //TODO: in UI to implement that this number means no filter or think better way
            {
                foreach (string licenseNumberKey in m_VehicleFilesList.Keys)
                {
                    resultList.Add(licenseNumberKey);
                }
            }
            else
            {
                VehicleStatus.eVehicleStatus status = (VehicleStatus.eVehicleStatus)i_StatusNumber;
                foreach (KeyValuePair<string,VehicleFile> vehicleFile in m_VehicleFilesList )
                {
                    if (vehicleFile.Value.Status == status)
                    {
                        resultList.Add(vehicleFile.Key);
                    }
                }
            }
            
            return resultList;
        }

        //TODO: תדלוק רכב דלק
        //TODO:טעינת רכב חשמלי

        
    }
}
