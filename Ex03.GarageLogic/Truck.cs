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

        public Truck(String i_LicenseNumber, EnergyType i_EnergyType) : base(i_LicenseNumber, i_EnergyType)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                VehicleWheels.Add(new Wheel(k_MaxAirPressureTruck));
            }
        }
        public bool TransportingRefrigeratedMaterials { get; set; }
        public float CargoVolume { get; set ; } 

    }
}
