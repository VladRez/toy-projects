using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCS
{
    class Building : Object
    {
        private Floor lobby;
        private Floor currentFloor;
        private string buildingName;
        private int numberOfFloors;
        private int numberOfElevators;
        private Elevator curElevator;
        private Person curPerson;
        public Building(String buildingName,int numberOfFloors, int numberOfElevators)
        {
            this.buildingName = buildingName;
            this.numberOfFloors = numberOfFloors;
            this.numberOfElevators = numberOfElevators;
        }

        
        public void addElevators()
        {
            curElevator = new Elevator(currentFloor, 1);
            currentFloor.CurElevator = curElevator;
            currentFloor.HasElevator = true;
            curElevator.HasPassanger = false;
        }

        public void AddGuest(Person Guest)
        {
            this.curPerson = Guest;
      
        }

        public void GoToRequestedFloor()
        {
            int requestedFloor = curPerson.OnFloor;
            int requestFloor = curPerson.ToFloor;

            int currElevatorFloorNumber = curElevator.CurrentFloor.FloorNumber;
            
            while (currElevatorFloorNumber != requestedFloor)
            {
                currentFloor.CurElevator = null;
                currentFloor.HasElevator = false;
                curElevator.CurrentFloor = null;
                currentFloor = currentFloor.NextFloor;

                curElevator.CurrentFloor = currentFloor;
                currentFloor.CurElevator = curElevator;
                currentFloor.HasElevator = true;

                currElevatorFloorNumber = CurrentFloor.FloorNumber;
            }

            curElevator.Passanger = curPerson;
            curElevator.HasPassanger = true;
            Console.WriteLine("\n------\nPicked up " + curPerson.PersonName + " on floor " + currElevatorFloorNumber + "\n------\n");

            while (currElevatorFloorNumber != requestFloor)
            {
                currentFloor.CurElevator = null;
                currentFloor.HasElevator = false;
                curElevator.CurrentFloor = null;

                currentFloor = currentFloor.NextFloor;

                curElevator.CurrentFloor = currentFloor;
                currentFloor.CurElevator = curElevator;
                currentFloor.HasElevator = true;

                currElevatorFloorNumber = CurrentFloor.FloorNumber;
            }

            Console.WriteLine("\n------\n Dropped off " + curPerson.PersonName + " on floor " + currElevatorFloorNumber + "\n------\n");

        }

        //Linked list of elevators
        public void BuildFloors()
        {
            Floor prevFloor;
            
            Floor current = new Floor(this, 0);
            lobby = current;

            for (int i = 1; i <= NumberOfFloors; i++)
            {

                current.NextFloor = new Floor(this, i);
                prevFloor = current;
                
                current = current.NextFloor;
                current.PrevFloor = prevFloor;
            }

            this.currentFloor = lobby;

        }


        public Building BuildingInfo
        {
            get { return this; }
        }

        

        public void PrintAllFloors()
        {
            Floor printFloor = lobby;   
            while (printFloor != null )
            {

               


                Console.WriteLine(printFloor.ToString());
                try
                {
                    if (printFloor.NextFloor != null)
                        Console.WriteLine("NEXT:{0}", printFloor.NextFloor.FloorNumber);
                }
                catch (SystemException)
                {
                    Console.WriteLine("NEXT FLOOR ERROR");
                    break;

                }

                try
                {
                    if (printFloor.PrevFloor != null)
                        Console.WriteLine("PREV:{0}", printFloor.PrevFloor.FloorNumber);

                }
                catch (SystemException)
                {
                    Console.WriteLine("PREVIOUS FLOOR ERROR");


                }

               


                printFloor = printFloor.NextFloor;
            }

            printFloor = null;
        }

        public Floor CurrentFloor
        {
            get { return this.currentFloor; }
        }
        
        public string BuildingName
        {
            get { return buildingName; }
        }

        public int NumberOfFloors
        {
            get { return numberOfFloors; }
        }

        public int NumberOfElevators
        {
            get { return numberOfElevators; }
        }

       
        public override string ToString()
        {
            return string.Format(
            "{0} : {1}\n{2} : {3}\n","Building Name", BuildingName, "Number of Floors", NumberOfFloors);
        }
    }
}
