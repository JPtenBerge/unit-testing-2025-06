using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject;

class Lambda
{
    public void Doe()
    {
        // delegates

        Func<string, bool> action = delegate (string name)
        {
            return true;
        }
        
        // bovenstaand kan ook worden vertaald naar:
        // Func<string, bool> action = name => true;

        // en dat lijkt dan al heel erg op wat hier gebeurt:
        //new List<int>() { }.Where(x => x > 4);
        // Assert.Throws<...>(() => sut.Doe());

        action("JP");


    }
}
