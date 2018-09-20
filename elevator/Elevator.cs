using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCS
{
    class Elevator
    {
        private int elevatorNumber;
        private Floor curFloor;
        private Person currPerson = null;
        private bool hasPerson = false;
        public Elevator(Floor curFloor, int elevatorNumber)
        {
            this.curFloor = curFloor;
            this.elevatorNumber = elevatorNumber;
        }

       

        public bool HasPassanger
        {
            get { return hasPerson; }
            set { hasPerson = value; }
        }

        public Floor CurrentFloor
        {
            set { curFloor = value;}
            get { return curFloor; }
        }
        public string FloorInfo
        {
            get { return curFloor.ToString(); }
        }

        public Person Passanger
        {
            get { return currPerson; }
            set { currPerson = value; }
        }

        public string PassangerName()
        {
            if (currPerson != null)
            {
                return currPerson.ToString();
            }

            return "No passangers";
        }
    }
}
