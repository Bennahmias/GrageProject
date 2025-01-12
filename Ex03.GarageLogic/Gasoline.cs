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
        
        public override void FillEnergy()
        {
            //TODO: to change
            Console.WriteLine("Fill energy");
        }
    }

    public class GasType
    {
        public enum eGasType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }
    }
}

