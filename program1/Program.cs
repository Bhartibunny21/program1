using System;
using System.Threading;

class VirtualPet
{
    public string Type { get; set; }
    public string Name { get; set; }
    public int Hunger { get; set; }
    public int Happiness { get; set; }
    public int Health { get; set; }

    public VirtualPet(string type, string name)
    {
        Type = type;
        Name = name;
        Hunger = 5;
        Happiness = 5;
        Health = 5;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Pet Status - {Type} {Name}");
        Console.WriteLine($"Hunger: {Hunger}/10 | Happiness: {Happiness}/10 | Health: {Health}/10");
    }

    public bool IsStatusCritical()
    {
        return Hunger <= 2 || Happiness <= 2 || Health <= 2 || Hunger >= 8 || Happiness >= 8 || Health >= 8;
    }

    public void SimulateTimePassage()
    {
        Hunger++;
        Happiness--;
        // Add more time-based changes as needed
    }

    public void Feed()
    {
        Hunger = Math.Max(0, Hunger - 2);
        Health = Math.Min(10, Health + 1);
        Console.WriteLine($"{Name} is fed. Hunger decreased, health increased.");
    }

    public void Play()
    {
        Happiness = Math.Min(10, Happiness + 2);
        Hunger = Math.Min(10, Hunger + 1);
        Console.WriteLine($"{Name} is happy after playing. Happiness increased, hunger increased.");
    }

    public void Rest()
    {
        Health = Math.Min(10, Health + 2);
        Happiness = Math.Max(0, Happiness - 1);
        Console.WriteLine($"{Name} is resting. Health increased, happiness decreased slightly.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Virtual Pet Simulator!");

        Console.Write("Enter the type of pet (e.g., cat, dog, rabbit): ");
        string petType = Console.ReadLine();

        Console.Write("Enter the pet's name: ");
        string petName = Console.ReadLine();

        VirtualPet pet = new VirtualPet(petType, petName);

        Console.WriteLine($"Welcome, {pet.Name} the {pet.Type}!");

        while (true)
        {
            Console.WriteLine("\nMain Menu:");
            Console.WriteLine("1. Feed the Pet");
            Console.WriteLine("2. Play with the Pet");
            Console.WriteLine("3. Let the Pet Rest");
            Console.WriteLine("4. Check Pet Status");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    pet.Feed();
                    break;

                case "2":
                    pet.Play();
                    break;

                case "3":
                    pet.Rest();
                    break;

                case "4":
                    pet.DisplayStats();
                    if (pet.IsStatusCritical())
                    {
                        Console.WriteLine("Warning: Pet is in critical condition. Take immediate action!");
                    }
                    break;

                case "5":
                    Console.WriteLine("Exiting Virtual Pet Simulator. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option (1-5).");
                    break;
            }

            pet.SimulateTimePassage();

            // Pause to simulate the passage of time
            Thread.Sleep(1000);
        }
    }
}

