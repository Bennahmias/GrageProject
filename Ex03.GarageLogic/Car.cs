using System;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        Color.e_Color m_Color;
        DoorsNumber.e_DoorsNumber m_DoorsNumber;

        public Car(Color.e_Color i_Color, DoorsNumber.e_DoorsNumber i_DoorsNumber, Gasoline i_GasoLine, String i_ModelName, String i_LicenseNumber, float i_LeftEnergy)
            : base(i_ModelName, i_LicenseNumber, i_LeftEnergy)
        {
            // Exeptions
            m_Color = i_Color;
            m_DoorsNumber = i_DoorsNumber;
            m_EnergyType = new Gasoline(i_GasoLine.GasType, i_GasoLine.CurrentFuelLeft, i_GasoLine.MaxFuleTank);
        }
    }
}
