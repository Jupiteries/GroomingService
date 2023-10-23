using System;
using System.IO;
using System.Text;

namespace GroomingService
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
