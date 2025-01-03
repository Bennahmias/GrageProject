using System;

namespace Ex03.GarageLogic
{
    public class Gasoline : EnergyType
    {
        private GasType.e_GasType m_GasType;
        private float m_CurrentFuleLeft;
        private float m_MaxFuleTank;

        public Gasoline(GasType.e_GasType i_GasType, float i_CurrentFuleLeft, float i_MaxFuleTank)
        {
            m_GasType = i_GasType;
            m_CurrentFuleLeft = i_CurrentFuleLeft;
            m_MaxFuleTank = i_MaxFuleTank;
        }
        public GasType.e_GasType GasType
        {
            get { return m_GasType; }
        }
        public float CurrentFuelLeft
        {
            get { return m_CurrentFuleLeft; }
        }
        public float MaxFuleTank
        {
            get { return m_MaxFuleTank; }
        }

        public override void FillEnergy()
        {
            Console.WriteLine("Fill energy");
        }
    }
}
