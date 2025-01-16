using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_TransportingRefrigeratedMaterials;
        private float m_CargoVolume;
        public const int k_NumberOfWheels = 14;
        public const float k_MaxAirPressure = 29.0f;

        public Truck(String i_LicenseNumber, EnergyType i_EnergyType)
            : base(i_LicenseNumber, i_EnergyType, k_NumberOfWheels, k_MaxAirPressure) { }
        public bool TransportingRefrigeratedMaterials
        {
            get { return m_TransportingRefrigeratedMaterials; }
            set { m_TransportingRefrigeratedMaterials = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }
        public override Dictionary<String, String> ShowDetails()
        {
            Dictionary<String, String> TruckDetails =
                new Dictionary<String, String>(6);
            TruckDetails.Add("Is transporting refrigerated materials? ", TransportingRefrigeratedMaterials? "Yes." : "No.");
            TruckDetails.Add("Cargo volume: ", CargoVolume.ToString());
            TruckDetails.Add("There are ", k_NumberOfWheels.ToString() + " wheels.");
            TruckDetails.Add("Manufacrurer name: ", VehicleWheels[0].ManufacturerName);
            TruckDetails.Add("Current air pressure ", VehicleWheels[0].CurrentAirPressure.ToString());
            TruckDetails.Add("Maximum air pressure: ", k_MaxAirPressure.ToString());

            return TruckDetails;
        }
    }
}
