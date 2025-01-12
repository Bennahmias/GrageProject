using System;


namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        protected float m_MaxCapacity;
        protected float m_CurrentCapacity = 0.0f;

        public EnergyType(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
        }

        public float MaxCapacity { get; }
        public float CurrentCapacity { get; set; }


    }
}
