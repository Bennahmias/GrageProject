using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected String m_ModelName;
        protected String m_LicenseNumber;
        protected EnergyType m_EnergyType;
        protected float m_PercentLeftEnergy;
        protected List<Wheel> m_VehicleWheels; //האם ליסט או מערך בעצם?

        public Vehicle(String i_ModelName, String i_LicenseNumber, float i_PercentLeftEnergy,float i_CurrentAirPressure, float i_MaxAirPressure,
            int i_NumberOfWheels, String i_ManufacturerName)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_PercentLeftEnergy = i_PercentLeftEnergy;
            m_VehicleWheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                m_VehicleWheels.Add(new Wheel(i_CurrentAirPressure,i_MaxAirPressure, i_ManufacturerName));
            }
        }
    }
}
