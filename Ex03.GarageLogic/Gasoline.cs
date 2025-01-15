using System;

namespace Ex03.GarageLogic
{
    public class Gasoline : EnergyType
    {
        private GasType.eGasType m_GasType;
        
        public Gasoline(GasType.eGasType i_GasType, float i_MaxFuleTank) : base (i_MaxFuleTank)
        {
            GasType = i_GasType;
        }

        public GasType.eGasType GasType
        {
            get { return m_GasType; }
            set { m_GasType = value; } 
        }
        
        public void Refueling(float i_gasolineToAdd, GasType.eGasType i_GasType)
        {
            if (i_GasType == m_GasType && (i_gasolineToAdd + m_CurrentCapacity <= MaxCapacity))
            {
                m_CurrentCapacity += i_gasolineToAdd;
                SetEnergyPercentage();
            }
            else
            {
                //TODO: trow exception of ValueOutOfRangeException
            }
        }
    }
}

