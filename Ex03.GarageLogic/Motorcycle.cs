namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private LicenseType.eLicenseType m_LicenseType;
        private int m_EngineDisplacement;
        public const int k_NumberOfWheels = 2;
        public const float k_MaxAirPressure = 32.0f;

        public Motorcycle(string i_LicenseNumber, EnergyType i_EnergyType)
            : base(i_LicenseNumber, i_EnergyType, k_NumberOfWheels, k_MaxAirPressure) { }
        public LicenseType.eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }
        public int EngineDisplacement
        {
            get { return m_EngineDisplacement; }
            set { m_EngineDisplacement = value; }
        }
    }
}
