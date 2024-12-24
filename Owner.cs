using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroomingService__With_Text_FIle_
{
    class Owner
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int PrivatePhoneNumber { get; set; }
        public List<Animal> dogs { get; set; }
        public List<Animal> cats { get; set; }
        public List<Animal> mice { get; set; }
        public int Id { get; set; }
    }
}
