using System;
using System.Collections.Generic;

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
        public float MaxCapacity
        {
            get { return r_MaxCapacity; }
        }
        public float CurrentCapacity
        {
            get { return m_CurrentCapacity; }
            set
            {
                if (value <= MaxCapacity)
                {
                    m_CurrentCapacity = value;
                    SetEnergyPercentage();
                }
                else
                {
                    throw new ValueOutOfRangeException(0.0f, MaxCapacity);
                }
            }
        }
        public float EnergyPercentage
        {
            get { return m_EnergyPercentage; }
        }
        public void SetEnergyPercentage()
        {
            m_EnergyPercentage = (CurrentCapacity / MaxCapacity) * 100;
        }
        public abstract Dictionary<String, String> ShowEnergyType();
    }
}
