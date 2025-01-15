namespace Ex03.GarageLogic
{
    public abstract class EnergyType
    {
        protected float m_MaxCapacity;
        protected float m_CurrentCapacity = 0.0f;
        protected float m_EnergyPercentage;

        public EnergyType(float i_MaxCapacity)
        {
            MaxCapacity = i_MaxCapacity;
        }
        public float MaxCapacity
        {
            get {return m_MaxCapacity;}
            set { m_MaxCapacity = value;} //TODO dont like that its not readonly and delete the set

        }
        public float CurrentCapacity
        {
            get {return m_CurrentCapacity ;}
            set
            {
                if (value <= MaxCapacity)
                {
                    m_CurrentCapacity = value;
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
            set { SetEnergyPercentage(); }
        }
        public void SetEnergyPercentage()
        {
            m_EnergyPercentage = (CurrentCapacity / MaxCapacity) * 100;
        }
    }
}
