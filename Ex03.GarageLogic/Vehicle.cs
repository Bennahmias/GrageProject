using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        //אין צורך לשים בקונסטרטור אתחול לכל המשתנים יש לזה גם חסרונות אלא רק הדברים שלא הולכים להשתנות מררגע היצירה עד הסוף
        protected string m_ModelName;
        protected string m_LicenseNumber;
        protected EnergyType m_EnergyType;
        protected float m_PercentageLeftEnergy;
        protected List<Wheel> m_VehicleWheels;

        public Vehicle(string i_LicenseNumber, EnergyType i_EnergyType)
        {
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyType = i_EnergyType;
        }

    }
}
