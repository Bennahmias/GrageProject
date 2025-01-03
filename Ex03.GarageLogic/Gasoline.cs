using System;

namespace Ex03.GarageLogic
{
    public class Gasoline : EnergyType
    {
        private e_GasType m_GasType;
        private float m_CurrentFuleLeft;
        private float m_MaxFuleTank;
        public enum e_GasType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        public Gasoline(e_GasType i_GasType, float i_CurrentFuleLeft, float i_MaxFuleTank)
        {
            m_GasType = i_GasType;
            m_CurrentFuleLeft = i_CurrentFuleLeft;
            m_MaxFuleTank = i_MaxFuleTank;
        }
        public e_GasType GasType { get; set;}
        public float CurrentFuelLeft { get; set; }
        public float MaxFuelTank { get; set; }

        public override void FillEnergy()
        {
            Console.WriteLine("Fill energy");
        }
    }
}
