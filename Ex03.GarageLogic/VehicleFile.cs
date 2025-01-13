using System;

namespace Ex03.GarageLogic
{
    public class VehicleFile
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private VehicleStatus.eVehicleStatus m_Status;
        private Vehicle m_Vehicle; // TODO : Delete?

        public VehicleFile(string i_OwnerName, string i_PhoneNumber)
        {
            //TODO : Ask Ben what he think about it.
            if (String.IsNullOrEmpty(i_OwnerName) || String.IsNullOrEmpty(i_PhoneNumber))// TODO: if we want to upgrade this func (phone number).
            {
                throw new ArgumentException("License number cannot be null or empty");
            }
            else
            {
                OwnerName = i_OwnerName;
                PhoneNumber = i_PhoneNumber;
                Status = VehicleStatus.eVehicleStatus.InRepair;
            }
        }

        public string OwnerName { get; set; }
        public string PhoneNumber { get; set; }
        //{
            //get { return m_PhoneNumber; }
            //set { m_PhoneNumber = value; }
        //}
        public Vehicle Vehicle { get; set; }
        public VehicleStatus.eVehicleStatus Status { get; set; }

        public void ChangeVehicleStatus(VehicleStatus.eVehicleStatus i_NewStatus)
        {
            m_Status = i_NewStatus;
        }
    }
}
