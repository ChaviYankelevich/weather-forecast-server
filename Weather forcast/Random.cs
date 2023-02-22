using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;

namespace Weather_forcast
{
    
    public class GenerateRandom
    {
        public int getRandom()
        {
            int max,last;
            max=int.Parse(Console.ReadLine());
            last=int.Parse(Console.ReadLine());
            bool[] flags=new bool[max];
            int rand = getNum(max, last);
            while (flags[rand])
            {
               rand = getNum(max, last);
            }
            return rand;
        } 
        public int getNum(int max,int last)
        {
            DateTime dt = DateTime.Now;
            int ms = dt.Millisecond;
            last = (last * 32719 + 3) % 32749;
            return last % max;
        }
    }
}
