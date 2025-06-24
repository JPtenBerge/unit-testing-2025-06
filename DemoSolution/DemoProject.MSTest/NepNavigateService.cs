using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.MSTest
{
    class NepNavigateService : INavigateService
    {
        public bool HasNextBeenCalled { get; set; }

        public void Next<T>(List<T> data, int? currentActiveIndex)
        {
            HasNextBeenCalled = true;
            //return 14;
        }
    }
}
