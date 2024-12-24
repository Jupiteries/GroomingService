using System;
using System.IO;
using System.Text;

namespace GroomingService__With_Text_FIle_
{
    class Program
    {
        static void Main(string[] args)
        {
            Owner owner = new Owner();
            GroomingService.Welcome(owner);
            GroomingService.GroomerAvailabilityChecker(owner);
        }
    }
}
