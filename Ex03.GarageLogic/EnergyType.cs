using System;


namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        protected float m_maxCapacity;
        protected float m_CurrentCapacity;

        public EnergyType(float i_MaxCapacity)
        {
            m_maxCapacity = i_MaxCapacity;
        }
        public abstract void FillEnergy();
    }
}
