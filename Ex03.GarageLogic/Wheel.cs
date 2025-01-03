using System;

namespace Ex03.GarageLogic
{
    public struct Wheel
    {
        private String m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        //methods:
        public String ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }
        public float CurrentAirPressure
        {
            get {return m_CurrentAirPressure;}
            set {m_CurrentAirPressure = value ; }
        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }


    }
}
