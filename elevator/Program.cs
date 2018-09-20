using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCS
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Building sfBuilding = new Building("SalesForce",5,1);
            Console.Write(sfBuilding.ToString());
            sfBuilding.BuildFloors();
            sfBuilding.addElevators();
            sfBuilding.PrintAllFloors();
            Person vlad = new Person("Vlad", sfBuilding,2,3);
            sfBuilding.AddGuest(vlad);
            sfBuilding.GoToRequestedFloor();
            sfBuilding.PrintAllFloors();
            


        }
    }
}
