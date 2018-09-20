using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPCS
{
    
    class Person
    {
        private string personName;
        
        private int onFloor;
        private int toFloor;
       public Person(string personName,Building destination, int onFloor, int toFloor)
        {
            this.personName = personName;
            this.onFloor = onFloor;
            this.toFloor = toFloor;
            
        }

        public string PersonName
        {
            get { return personName; }
        }

        public int OnFloor
        {
            get { return onFloor; }
        }

        public int ToFloor
        {
            get { return toFloor; }
        }

        public override string ToString()
        {
            return string.Format("{0}", personName);
        }
    }
}
