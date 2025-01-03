using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected String m_ModelName;
        protected String m_LicenseNumber;
        protected float m_LeftEnergy;
        protected List<Wheel> m_VehicleWheels;
        protected EnergyType m_EnergyType;

        public Vehicle(String i_ModelName, String i_LicenseNumber, float i_LeftEnergy)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_LeftEnergy = i_LeftEnergy;
            m_VehicleWheels = new List<Wheel>();
        }
    }
}
