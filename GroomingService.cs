using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace GroomingService__With_Text_FIle_
{
    class GroomingService
    {
        public static double DogAmount { get; set; }
        public static double CatAmount { get; set; }
        public static double MouseAmount { get; set; }
        public static void Welcome(Owner owner)
        {
            Console.WriteLine("Welcome to the grooming center. Are you an admin or a user? (type admin/user)");
            string adminOrUser = Console.ReadLine();
            // password is 12321
            if (adminOrUser == "admin")
            {
                Console.WriteLine("Enter the password.");
                int password = 12321;
                int userinput = Convert.ToInt32(Console.ReadLine());
                if (userinput == password)
                {
                    Admin();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Seems like you are a user.\n");
                }
            }

            else if (adminOrUser == "user")
            {
                
            }

                Console.WriteLine("Please enter your name:");
                string name = Console.ReadLine();
                owner.Name = name;
                Console.WriteLine("Enter your ID:");
                int id = Convert.ToInt32(Console.ReadLine());
                owner.ID = id;
                Console.WriteLine("Enter your private phone number:");
                int phoneNum = Convert.ToInt32(Console.ReadLine());
                owner.PrivatePhoneNumber = phoneNum;
                using (FileStream info = new FileStream(@"CustomerInfo.txt", FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(info))
                    {
                        sw.WriteLine($"Name: {name}");
                        sw.WriteLine($"ID: {id}");
                        sw.WriteLine($"Phone Number: {phoneNum}");
                    }
                }

        }

    
        public static void GroomerAvailabilityChecker(Owner owner)
        {
            
            if (Groomer.isFree == true)
            {
                Console.WriteLine("It seems like our groomer is available. Have a nice stay.");
                Grooming(owner);
            }
            else
            {
                Console.WriteLine($"Sorry, our groomer is not available. Come back later!");
            }
        }
        public static string Admin()
        {
            int orderCount = 0;
            int customerCount = 0;
            int deathCount = 0;
            foreach (string line in File.ReadLines("CustomerInfo.txt"))
            {
                if (line.Contains("ID"))
                {
                    customerCount++;
                }
            }
            foreach (string line in File.ReadLines("CustomerFile.txt"))
            {
                if (line.Contains("Dog") || line.Contains("Cat") || line.Contains("Mouse"))
                {
                    orderCount++;
                }
            }
            foreach (string line in File.ReadLines("CustomerFile.txt"))
            {
                if (line.Contains("groomer"))
                {
                    deathCount++;
                }
            }
            Console.WriteLine($"Amount of customers: {customerCount}, amount of orders: {orderCount} ({deathCount} animals were accidentally killed!).");
            Console.WriteLine("Do you want to clear the file infos?(y/n) (if you type yes, admins won't be able to see the customer and order amounts)");
            char answer = Convert.ToChar(Console.ReadLine());
            if (answer == 'y')
            {
                File.Delete(@"CustomerInfo.txt");
                File.Delete(@"CustomerFile.txt");
                return "Have a nice day";

            }
            return "Have a nice day";



        }
        public static void Grooming(Owner owner)
        {
            Random rand = new Random();

            List<Animal> dogs = new List<Animal>();
            List<Animal> cats = new List<Animal>();
            List<Animal> mice = new List<Animal>();
            Console.Write("Welcome. How many dogs do you want to groom?: ");
            DogAmount = Convert.ToInt32(Console.ReadLine());
            if (20 >= DogAmount & DogAmount >= 0)
            {
                Console.Write("How many cats do you want to groom?: ");
                CatAmount = Convert.ToInt32(Console.ReadLine());
                if (20 >= CatAmount & CatAmount >= 0)
                {
                    Console.Write("How many mice do you want to groom?: ");
                    MouseAmount = Convert.ToInt32(Console.ReadLine());
                    if (20 >= MouseAmount & MouseAmount >= 0)
                    {
                        Console.WriteLine("Thank you");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient amount of mice.");
                    }
                }
                else
                {
                    Console.WriteLine("Insufficient amount of cats.");
                }
            }
            else
            {
                Console.WriteLine("Insufficient amount of dogs.");
            }

            for (int i = 1; i <= DogAmount; i++)
            {
                string? name;
                string? breed;
                Animal dog = new Animal();
                Console.WriteLine($"What is the name of your dog? (Dog number {i})");
                dog.Name = Console.ReadLine();
                Console.WriteLine($"What breed is your dog? (Dog number {i})");
                dog.Breed = Console.ReadLine();
                dog.Type = "Dog";
                dogs.Add(dog);
            }
            for (int i = 1; i <= CatAmount; i++)
            {
                string? name;
                string? breed;
                Animal cat = new Animal();
                Console.WriteLine($"What is the name of your cat? (Cat number {i})");
                cat.Name = Console.ReadLine();
                Console.WriteLine($"What breed is your cat? (Cat number {i})");
                cat.Breed = Console.ReadLine();
                cat.Type = "Cat";
                cats.Add(cat);
            }
            for (int i = 1; i <= MouseAmount; i++)
            {
                string? name;
                string? breed;
                Animal mouse = new Animal();
                Console.WriteLine($"What is the name of your mouse? (mouse number {i})");
                mouse.Name = Console.ReadLine();
                Console.WriteLine($"What breed is your mouse? (mouse number {i})");
                mouse.Breed = Console.ReadLine();
                mouse.Type = "Mouse";
                mice.Add(mouse);
            }
            using (FileStream stream = new FileStream(@"CustomerFile.txt", FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    int i = 1;
                    foreach (var dog in dogs)
                    {
                        int chance = rand.Next(1, 11);
                        if (chance == 1)
                        {
                            sw.WriteLine($"Dog {i}: Name: {dog.Name}, Breed: {dog.Breed} (The groomer accidentally drowned this dog, our apologies.)");
                            i++;
                        }
                        else 
                        {
                            sw.WriteLine($"Dog {i}: Name: {dog.Name}, Breed: {dog.Breed}");
                            i++;
                        }
                    }
                    sw.WriteLine();
                    i = 1;
                    foreach (var cat in cats)
                    {
                        int chance = rand.Next(1, 10);
                        if (chance == 1)
                        {
                            sw.WriteLine($"Cat {i}: Name: {cat.Name}, Breed: {cat.Breed} (The groomer accidentally shaved too deep and sent this cat to the afterlife, our apologies.)");
                            i++;
                        }
                        else
                        {
                            sw.WriteLine($"Cat {i}: Name: {cat.Name}, Breed: {cat.Breed}");
                            i++;
                        }
                    }
                    sw.WriteLine();
                    i = 1;
                    foreach (var mouse in mice)
                    {
                        int chance = rand.Next(1, 10);
                        if (chance == 1)
                        {
                            sw.WriteLine($"Mouse {i}: Name: {mouse.Name}, Breed: {mouse.Breed} (The groomer accidentally brushed too hard and squashed this mouse to death, our apologies.)");
                            i++;
                        }
                        else
                        {
                            sw.WriteLine($"Mouse {i}: Name: {mouse.Name}, Breed: {mouse.Breed}");
                            i++;
                        }
                    }
                }
            }
            
            foreach (var dog in dogs)
            {
                Console.WriteLine($"Your dog {dog.Name}, breed {dog.Breed} is ready.");
            }
            Console.WriteLine("\n\n\n");
            foreach (var cat in cats)
            {
                Console.WriteLine($"Your cat {cat.Name}, breed {cat.Breed} is ready.");
            }
            Console.WriteLine("\n\n\n");
            foreach (var mouse in mice)
            {
                Console.WriteLine($"Your mouse {mouse.Name}, breed {mouse.Breed} is ready.");
            }

            string read1 = File.ReadAllText(@"CustomerInfo.txt");
            string read = File.ReadAllText(@"CustomerFile.txt");
            Console.WriteLine(read1);
            Console.WriteLine(read);
            Console.WriteLine("Do you want to clear the file infos?(y/n) (if you type yes, admins won't be able to see the customer and order amounts)");
            char answer = Convert.ToChar(Console.ReadLine());
            if (answer == 'y')
            {
                File.Delete(@"CustomerInfo.txt");
                File.Delete(@"CustomerFile.txt");
            }
            else
            {
                Console.WriteLine("Have a nice day");
            }


        }
    }
}
