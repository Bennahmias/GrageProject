using System;

namespace Ex03.GarageLogic
{
    public struct Wheel
    {
        public String ManufacturerName { get; set; }
        public float CurrentAirPressure { get; set; }
        public float MaxAirPressure { get; set; }

        public Wheel(float i_CurrentAirPressure, float i_MaxAirPressure, String i_ManufacturerName)
        {
            CurrentAirPressure = i_CurrentAirPressure;
            MaxAirPressure = i_MaxAirPressure;
            ManufacturerName = i_ManufacturerName;
        }

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
