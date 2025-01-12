using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private Garage m_Garage;
        private bool m_ExitFromSystem;

        public GarageUI()
        {
            m_Garage = new Garage();
            m_ExitFromSystem = false;
        }


    }
}
