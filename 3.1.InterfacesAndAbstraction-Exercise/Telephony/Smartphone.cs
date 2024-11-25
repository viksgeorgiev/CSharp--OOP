using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony;

public class Smartphone : IBrowsing, ICalling
{
    
    public string Browse(string url)
    {
        return $"Browsing: {url}!";
    }

    public string Call(string number)
    {
        return $"Calling... {number}";
    }
}
