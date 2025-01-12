using System;

namespace Ex03.GarageLogic
{
    public class Wheel // TODO: change to class?
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; set; }
        
        public void inflating(float i_AddAirToWheel) 
        {
            if (CurrentAirPressure + i_AddAirToWheel <= MaxAirPressure)
            {
                CurrentAirPressure += i_AddAirToWheel;
            }
            else
            {
                //TODO: comment ot exception?
            }
        }
        
    }
}
