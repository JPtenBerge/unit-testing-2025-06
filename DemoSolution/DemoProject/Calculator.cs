using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject
{
    //[InternalsVisibleTo("DemoProject.MSTest")]
    public class Calculator
    {
        public int Result { get; set; }

        public void Add(int n)
        {
            Result += n;
        }

        public void Multiply(int n)
        {
            Result *= n;
        }

        private void DoeIets()
        {

        }
    }
}
