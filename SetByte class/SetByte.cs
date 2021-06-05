using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetByte_class
{
    class SetByte
    {
        public byte[] elements; public int size;
        public SetByte()//default constructor
        {
            size = 0;
            elements = new byte[256];
        }
        public static byte[] InsertionSort(byte[]b)
        {
            int size = b.Length;
            for (int i = 1; i < size; i++)
            {
                byte tmp = b[i];
                int j = i - 1;
                while (j>=0&&b[j]>tmp)
                {
                    b[j + 1] = b[j];                    
                    j--;
                    b[j + 1] = tmp;
                }                
               
            }
            return b;
        }
        public SetByte(byte[] e)
        {
            this.size = e.Length;
            this.elements = new byte[size];            
            if (this.size!=0 )
            {
                for (int i = 0; i < size; i++)
                {
                    elements[i] = e[i];
                }
            }
            elements = InsertionSort(elements);
        }
        public SetByte(SetByte m)
        {
            this.size = m.size;
            for (int i = 0; i < size; i++)
            {
                this.elements[i] = m.elements[i];
            }
        }
        public void Print()
        {
            if (size!=0)
            {
                int i;
                Console.Write("{ ");
                for ( i = 0; i < this.size - 1; i++)
                {
                    Console.Write(elements[i] + ", ");
                }
                Console.Write(elements[i] + "}");
            }
            else
            {
                Console.WriteLine("No elements in the set");
            }
        }
        public SetByte Intersection(SetByte A)
        {
            SetByte IntersectedSet = new SetByte();           
            int n1 = 0;
            int n2 = 0;
            int n = -1;
            while (n1<this.size&&n2<A.size)
            {
                if (this.elements[n1]<A.elements[n2])
                {
                    n1++;
                }
                else if (this.elements[n1]>A.elements[n2])
                {
                    n2++;
                }
                else
                {
                    IntersectedSet.elements[++n] = this.elements[n1++];n2++;
                }
            }
            IntersectedSet.size = n + 1;
            return IntersectedSet;
            
        }
    }
}
