using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetByte_class
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] arr = {2,1,5,3,0};            
            SetByte MyByte = new SetByte(arr);
            MyByte.Print();
            
        }
    }
}
