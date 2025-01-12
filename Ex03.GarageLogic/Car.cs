using System;
using System.Dynamic;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private Color.eColor m_Color;
        private DoorsNumber.eDoorsNumber m_DoorsNumber;
        public const int k_NumberOfWheels = 5;
        private const float k_MaxAirPressureCar = 34.0f;
        public Car(string i_LicenseNumber, EnergyType i_EnergyType) : base(i_LicenseNumber, i_EnergyType)
        {
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(k_MaxAirPressureCar));
            }
        }
        public Color.eColor Color {get; set;}
        public DoorsNumber.eDoorsNumber DoorsNumber {get; set;}
        


    }
}
