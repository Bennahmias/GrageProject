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

        public float MaxCapacity { get; set;}
        public float CurrentCapacity { get; set; }
        public float EnergyPercentage { get; set; }

        public void SetEnergyPercentage()
        {
            EnergyPercentage = (CurrentCapacity / MaxCapacity) * 100;
        }
    }
}
