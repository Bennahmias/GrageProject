using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private Color.e_Color m_Color;
        private DoorsNumber.e_DoorsNumber m_DoorsNumber;
        private EnergyType m_EnergyType;
        public Car(Color.e_Color i_Color, DoorsNumber.e_DoorsNumber i_DoorsNumber, Gasoline i_GasoLine, String i_ModelName,
            String i_LicenseNumber, float i_LeftEnergy, float i_CurrentAirPressure, float i_MaxAirPressure)
            : base(i_ModelName, i_LicenseNumber, (i_GasoLine.CurrentFuelLeft/i_GasoLine.MaxFuelTank),i_CurrentAirPressure,
                i_MaxAirPressure,5,"MICHLEN")
        {
            // Exeptions for gasoline
            m_Color = i_Color;
            m_DoorsNumber = i_DoorsNumber;
        }
    }
}
