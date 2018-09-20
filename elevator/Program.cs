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
            
            Building sfBuilding = new Building("SalesForce",10,1);
            Console.Write(sfBuilding.ToString());
            sfBuilding.BuildFloors();
            sfBuilding.PrintAllFloors();
            


        }
    }
}
