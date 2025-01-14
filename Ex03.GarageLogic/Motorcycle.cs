using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private LicenseType.eLicenseType m_LicenseType;
        private int m_EngineDisplacement;
        public const int k_NumberOfWheels = 2;
        public const float k_MaxAirPressureMotorcycle = 32.0f;

        public Motorcycle(string i_LicenseNumber, EnergyType i_EnergyType) : base(i_LicenseNumber, i_EnergyType)
        {
            //TODO: check if need to do here somthing
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                VehicleWheels.Add(new Wheel(k_MaxAirPressureMotorcycle));
            }
        }

        public LicenseType.eLicenseType LicenseType { get; set; }
        public int EngineDisplacement { get; set; }


    }
}
