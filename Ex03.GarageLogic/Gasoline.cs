using System;

namespace Ex03.GarageLogic
{
    public class Gasoline : EnergyType
    {
        private GasType.eGasType m_GasType;
        
        public Gasoline(GasType.eGasType i_GasType, float i_MaxFuleTank) : base (i_MaxFuleTank)
        {
            m_GasType = i_GasType;
        }

        public GasType.eGasType GasType { get; set;}
        
        public void Refueling(float i_gasolineToAdd, GasType.eGasType i_GasType)
        {
            if (i_GasType == m_GasType && (i_gasolineToAdd + m_CurrentCapacity <= r_MaxCapacity))
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

