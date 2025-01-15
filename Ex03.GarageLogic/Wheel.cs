using System;

namespace Ex03.GarageLogic
{
    public class Wheel 
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
        }
        public string ManufacturerName
        {
            get { return m_ManufacturerName;}
            set { m_ManufacturerName = value;}
        }
        public float CurrentAirPressure
        {
            get {return m_CurrentAirPressure;}
            set
            {
                if (value <= MaxAirPressure)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(0.0f, MaxAirPressure);
                }
            }
        }
        public float MaxAirPressure
        {
            get { return r_MaxAirPressure;}
            //set { m_MaxAirPressure = value; } //TODO: i dont like it that its not readonly
        }
        public void Inflating(float i_AddAirToWheel) 
        {
            if (CurrentAirPressure + i_AddAirToWheel <= MaxAirPressure)
            {
                CurrentAirPressure += i_AddAirToWheel;
            }
            else
            {
                throw new ValueOutOfRangeException(0.0f, MaxAirPressure);
            }
        }
        public void InflatingToMax(float i_MaxAirPressure)
        {
            CurrentAirPressure = i_MaxAirPressure;
        }
        
    }
}
