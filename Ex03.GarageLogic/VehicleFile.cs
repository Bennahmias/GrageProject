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
            OwnerName = i_OwnerName; 
            PhoneNumber = i_PhoneNumber; 
            Status = VehicleStatus.eVehicleStatus.InRepair;
        }
        public string OwnerName
        {
            get { return m_OwnerName;}
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Owner name cannot be null or empty.");
                }
                m_OwnerName = value;
            }
        }
        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Phone number cannot be null or empty.");
                }
                m_PhoneNumber = value;
            }
        }
        public Vehicle Vehicle
        {
            get { return m_Vehicle;}
            set { m_Vehicle = value;}
        }
        public VehicleStatus.eVehicleStatus Status
        {
            get { return m_Status;}
            set { m_Status = value;}
        }
        public void ChangeVehicleStatus(VehicleStatus.eVehicleStatus i_NewStatus)
        {
            Status = i_NewStatus;
        }
    }
}
