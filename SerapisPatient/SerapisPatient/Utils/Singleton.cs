using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisPatient.Utils
{
    class Singleton
    {
        private static int counter = 0;
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
        }

        private Singleton()
        {
            counter++;
            Console.WriteLine("Counter Value " + counter.ToString());
        }


    }
}

