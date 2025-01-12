using System;

namespace Ex03.GarageLogic
{
    public class VehicleFile
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private VehicleStatus.eVehicleStatus m_Status;
        private Vehicle m_Vehicle;

        public VehicleFile(string i_OwnerName, string i_PhoneNumber)
        {
            //TODO : Exceptions.
            m_OwnerName = i_OwnerName;
            m_PhoneNumber = i_PhoneNumber;
            m_Status = VehicleStatus.eVehicleStatus.InRepair;
        }

        public string OwnerName { get; }
        public string PhoneNumber { get; set; }
        public Vehicle Vehicle { get; set; }
        public VehicleStatus.eVehicleStatus Status { get; set; }

        public void ChangeVehicleStatus(VehicleStatus.eVehicleStatus i_NewStatus)
        {
            m_Status = i_NewStatus;
        }
    }
}
