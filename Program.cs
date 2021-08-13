using System;
using System.Collections.Generic;


namespace Lab5_2
{


    

    enum CarMake
    {
        Ford, 
        Chevrolet, 
        Chrysler, 
        Honda, 
        Toyota
    }


    class Car
    {
        protected CarMake Make;
        protected string Model;
        protected int Year;
        protected decimal Price;



        public Car(CarMake _Make, string _Model, int _Year, decimal _Price)
        {
            Make = _Make;
            Model = _Model;
            Year = _Year;
            Price = _Price;
        }

    }

    class NewCar : Car
    {
        public bool ExtendedWarranty;

        //constructor
        public NewCar (bool _ExtendedWarranty, CarMake _Make, string _Model, int _Year, decimal _Price) : base(_Make, _Model, _Year, _Price)
        {
            ExtendedWarranty = _ExtendedWarranty;
            
        }

        //tostring
        public override string ToString()
        {
        return $" Make: {Make}, Model: {Model}, Year: {Year}, Price: {Price}, Extended Warranty: {ExtendedWarranty}";
        }


    }

    class UsedCar : Car
    {
        public int NumberOfOwners;
        public int Mileage;

        public UsedCar (int _NumberOfOwners, int _Mileage,  CarMake _Make, string _Model, int _Year, decimal _Price) : base(_Make, _Model,_Year, _Price)
        {
            NumberOfOwners = _NumberOfOwners;
            Mileage = _Mileage;
        }

        public override string ToString()
        {
            return $" Make: {Make}, Model: {Model}, Year: {Year}, Price: {Price}, NumberofOwners: {NumberOfOwners}, Mileage: {Mileage}";
        }
    }






    class Program
    {

        static bool Continue()
        {
            while (true)
            {
                Console.WriteLine("Would you like to continue? (y/n)");
                string response = Console.ReadLine();
                response = response.ToLower();


                if (response == "y" || response == "yes")
                {
                    return true;
                }
                else if (response == "n" || response == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Please enter y or n");
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car Lot Inventory Manager");
            do
            {

                List<Car> mylist = new List<Car>();
                Car AddNewCar;
                AddNewCar = new NewCar(true, CarMake.Ford, "Bronco", 2021, 18000);
                mylist.Add(AddNewCar);
                AddNewCar = new NewCar(false, CarMake.Chevrolet, "Trail Blazer", 2019, 15000);
                mylist.Add(AddNewCar);
                AddNewCar = new NewCar(true, CarMake.Chrysler, "Pacifica", 2022, 30000);
                mylist.Add(AddNewCar);
                AddNewCar = new UsedCar(3, 65898, CarMake.Chrysler, "Sebring", 2015, 6000);
                mylist.Add(AddNewCar);
                AddNewCar = new UsedCar(1, 20000, CarMake.Honda, "Accord", 2019, 12000);
                mylist.Add(AddNewCar);
                AddNewCar = new UsedCar(2, 30000, CarMake.Toyota, "Runner", 2018, 16000);
                mylist.Add(AddNewCar);

               
                Console.WriteLine("Please enter one of the following options: ");
                Console.Write("Menu: (A)dd , (Q)uit, (V)iew Inventory: ");
                string response = Console.ReadLine().ToUpper();

                if (response == "A")
                {
                    Console.Write("Is this a new or used car? (Please enter new or used): ");
                    string carClass = Console.ReadLine().ToLower();



                    if (carClass == "new")

                    {
                        Console.Write("Enter Make: ");
                        string selectedMake = Console.ReadLine();
                        CarMake getParse;
                        bool checkParse = Enum.TryParse(selectedMake, out getParse);
                        //Console.WriteLine(getParse);


                        //CarMake _Make  = (Console.ReadLine());
                        Console.Write("Enter Model: ");
                        string _Model = Console.ReadLine();
                        Console.Write("Enter Year: ");
                        int _Year = int.Parse(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        decimal _Price = decimal.Parse(Console.ReadLine());
                        Console.Write("Extended Warranty? (true/false): ");
                        bool _ExtendedWarranty = bool.Parse(Console.ReadLine());


                        AddNewCar = new NewCar(_ExtendedWarranty, getParse, _Model, _Year, _Price);
                        mylist.Add(AddNewCar);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Your entry has been added to Car inventory.");
                        Console.WriteLine();
                        Console.WriteLine("Updated Inventory List: ");
                        foreach (var inventory in mylist)
                        {
                            Console.WriteLine(inventory);
                        }

                    }
                    else if (carClass == "used")
                    {
                        // int _NumberOfOwners, int _Mileage, CarMake _Make, string _Model, int _Year, decimal _Price) : base(_Make, _Model, _Year, _Price
                        Console.Write("Enter Make: ");
                        string selectedMake = Console.ReadLine();
                        CarMake getParse;
                        bool checkParse = Enum.TryParse(selectedMake, out getParse);
                        //Console.WriteLine(getParse);


                        //CarMake _Make  = (Console.ReadLine());
                        Console.Write("Enter Model: ");
                        string _Model = Console.ReadLine();
                        Console.Write("Enter Year: ");
                        int _Year = int.Parse(Console.ReadLine());
                        Console.Write("Enter Price: ");
                        decimal _Price = decimal.Parse(Console.ReadLine());

                        Console.Write("Enter Number of Previous Owners: ");
                        int _NumberOfOwners = int.Parse(Console.ReadLine());

                        Console.Write("Enter Mileage: ");
                        int _Mileage = int.Parse(Console.ReadLine());

                        AddNewCar = new UsedCar(_NumberOfOwners, _Mileage, getParse, _Model, _Year, _Price);
                        mylist.Add(AddNewCar);
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("Your entry has been added to Car inventory.");
                        Console.WriteLine("Updated Inventory List: ");
                        foreach (var inventory in mylist)
                        {
                            Console.WriteLine(inventory);
                        }



                    }
                    else
                    {
                        Console.WriteLine("Please be sure to enter 'new' or 'used'");
                    }







                }
                else if (response == "V")
                {
                    foreach (var inventory in mylist)
                    {
                        Console.WriteLine(inventory);
                    }

                }
                else if (response == "Q")
                {
                    return;
                }







            } while (Continue());


        }
     }
}
