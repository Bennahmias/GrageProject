using System;


namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        protected readonly float r_MaxCapacity;
        protected float m_CurrentCapacity = 0.0f;
        protected float m_EnergyPercentage;

        public EnergyType(float i_MaxCapacity)
        {
            r_MaxCapacity = i_MaxCapacity;
        }

        public float MaxCapacity { get; }
        public float CurrentCapacity { get; set; }

        public void SetEnergyPercentage()
        {
            m_EnergyPercentage = (m_CurrentCapacity / r_MaxCapacity) * 100;
        }
    }
}
