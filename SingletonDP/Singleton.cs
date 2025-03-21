﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDP
{
    //thread safe version
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static Singleton(){}
        private Singleton(){}

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public void HelloWorld()
        {
            Console.WriteLine("Hello world!");
        }
    }
}
