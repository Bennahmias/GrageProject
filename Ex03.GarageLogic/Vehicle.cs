using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected EnergyType m_EnergyType;
        protected List<Wheel> m_VehicleWheels;

        public Vehicle(string i_LicenseNumber, EnergyType i_EnergyType, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            LicenseNumber = i_LicenseNumber;
            EnergyType = i_EnergyType;
            AddWheelsToVehicle(i_NumberOfWheels, i_MaxAirPressure);
        }
        
        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("License number cannot be null or empty.");
                }
                m_LicenseNumber = value;
            }
        }
        
        public EnergyType EnergyType
        {
            get { return m_EnergyType; }
            set { m_EnergyType = value; }
        }
       
        public string ModelName
        {
            get { return m_ModelName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model Name cannot be null or empty.");
                }
                m_ModelName = value;
            }
        }
        
        public List<Wheel> VehicleWheels
        {
            get { return m_VehicleWheels; }
            set { m_VehicleWheels = value; }
        }
        
        private void AddWheelsToVehicle(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            VehicleWheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                VehicleWheels.Add(new Wheel(i_MaxAirPressure));
            }
        }
        
        public Dictionary<String, String> ShowVehicle()
        {
            Dictionary<String, String> vehicleDetails =
                new Dictionary<String, String>(6);

            vehicleDetails.Add("Model name: ", ModelName);
            vehicleDetails.Add("License number: ", LicenseNumber);
            vehicleDetails.Add("There are ", VehicleWheels.Count.ToString() + " wheels.");
            vehicleDetails.Add("Manufacrurer name: ", VehicleWheels[0].ManufacturerName);
            vehicleDetails.Add("Current air pressure ", VehicleWheels[0].CurrentAirPressure.ToString());
            vehicleDetails.Add("Maximum air pressure: ", VehicleWheels[0].MaxAirPressure.ToString());

            return vehicleDetails;
        }
        
        public abstract Dictionary<String, String> ShowDetails();
    }
}
