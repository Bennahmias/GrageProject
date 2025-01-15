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
            get { return m_TransportingRefrigeratedMaterials;}
            set { m_TransportingRefrigeratedMaterials = value; }
        }
        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }
    } 
}
