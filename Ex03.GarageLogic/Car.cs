using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private Color.eColor m_Color;
        private DoorsNumber.eDoorsNumber m_DoorsNumber;
        public const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressure = 34.0f;
        public Car(string i_LicenseNumber, EnergyType i_EnergyType)
            : base(i_LicenseNumber, i_EnergyType, k_NumberOfWheels, k_MaxAirPressure) {}
        public Color.eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }
        public DoorsNumber.eDoorsNumber DoorsNumber
        {
            get { return m_DoorsNumber;}
            set { m_DoorsNumber = value;}
        }



    }
}
