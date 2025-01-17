using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Gasoline : EnergyType
    {
        private GasType.eGasType m_GasType;

        public Gasoline(GasType.eGasType i_GasType, float i_MaxFuleTank) : base(i_MaxFuleTank)
        {
            GasType = i_GasType;
        }
        public GasType.eGasType GasType
        {
            get { return m_GasType; }
            set { m_GasType = value; }
        }
        public void Refueling(float i_gasolineToAdd, GasType.eGasType i_GasType)
        {
            if (i_GasType != GasType)
            {
                throw new ArgumentException("The fuel type does not match the vehicle type.");
            }
            else if (!(i_gasolineToAdd + CurrentCapacity <= MaxCapacity))
            {
                throw new ValueOutOfRangeException(0.0f, MaxCapacity - CurrentCapacity);
            }
            else
            {
                CurrentCapacity += i_gasolineToAdd;
                SetEnergyPercentage();
            }
        }
        public override Dictionary<String, String> ShowEnergyType()
        {
            Dictionary<String, String> energyTypeDetails =
                new Dictionary<String, String>(4);
            energyTypeDetails.Add("Current fuel amount: ", CurrentCapacity.ToString());
            energyTypeDetails.Add("Maximum fuel amount: ", MaxCapacity.ToString());
            energyTypeDetails.Add("Percentage of fuel remaining: ", EnergyPercentage.ToString() + "%");
            energyTypeDetails.Add("The gas type is: ", GasType.ToString());

            return energyTypeDetails;
        }
    }
}

