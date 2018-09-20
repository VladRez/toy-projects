using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCS
{
     
    class Floor
    {
        private Building curBuilding;
        private Elevator curElevator;
        private int floorNumber;
        private Floor nextFloor;
        private Floor prevFloor;
        private bool hasElevator;
       
        public Floor(Building curBuilding, int floorNumber)
            
        {
            this.floorNumber = floorNumber;
            this.curBuilding = curBuilding;
        }

        public Elevator CurElevator
        {
            set { curElevator = value; }
            get { return curElevator; }
        }

        public int FloorNumber
        {
            get { return floorNumber; }
        }

        public bool HasElevator
        {
            set { hasElevator = value; }
            get { return hasElevator; }
        }

        public Floor NextFloor
        {
            set
            {
                nextFloor = value;
            }
            get { return nextFloor; }
        }

        public Floor PrevFloor
        {
            set
            {
                prevFloor = value;
            }
            get { return prevFloor; }
        }


        public override string ToString()
        {
            Console.WriteLine();
            return string.Format("{0} {1}:\n{2} - {3} - {4}","Floor of building ", curBuilding.BuildingName, FloorNumber.ToString()
            , hasElevator ? "Has elevator" : "", hasElevator ? curElevator.HasPassanger ? "passanger name: " + curElevator.PassangerName() : "No Passangers" : "");
        }
    }
}
