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
            if (String.IsNullOrEmpty(i_LicenseNumber))
            {
                throw new ArgumentException("License number cannot be null or empty");
            }
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyType = i_EnergyType;
            m_VehicleWheels = new List<Wheel>();
        }

        public string LicenseNumber { get; set; }
        public EnergyType EnergyType { get;}

        public string ModelName
        {
            get { return m_ModelName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Model Name cannot be null or empty");
                }
                m_ModelName = value;
            }
        }
        public float PercentLeftEnergy
        {
            get { return m_PercentageLeftEnergy; }
            set
            {
                //TODO: implement at the norashim?
            }
        }




    }
}
