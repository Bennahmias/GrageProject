using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_TransportingRefrigeratedMaterials;
        private float m_CargoVolume;
        public const int k_NumberOfWheels = 14;
        public const float k_MaxAirPressureTruck = 29.0f;

        public Truck(string i_LicenseNumber, EnergyType i_EnergyType) : base(i_LicenseNumber, i_EnergyType)
        {
            m_VehicleWheels = new List<Wheel>();
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(k_MaxAirPressureTruck));
            }
        }
    }
}
