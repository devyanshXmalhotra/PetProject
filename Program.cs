using System;

class Program
{
    static void Main()
    {
        string[,] ourAnimals = new string[10, 6];

        ourAnimals[0, 0] = "1";
        ourAnimals[0, 1] = "dog";
        ourAnimals[0, 2] = "2";
        ourAnimals[0, 3] = "brown, medium, short hair";
        ourAnimals[0, 4] = "friendly, energetic";
        ourAnimals[0, 5] = "Buddy";

        ourAnimals[1, 0] = "2";
        ourAnimals[1, 1] = "cat";
        ourAnimals[1, 2] = "3";
        ourAnimals[1, 3] = "black, small, long hair";
        ourAnimals[1, 4] = "quiet, shy";
        ourAnimals[1, 5] = "Shadow";

        ourAnimals[2, 0] = "3";
        ourAnimals[2, 1] = "dog";
        ourAnimals[2, 2] = "1";
        ourAnimals[2, 3] = "white, large, short hair";
        ourAnimals[2, 4] = "playful, loyal";
        ourAnimals[2, 5] = "Max";

        int animalCount = 3;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nContoso Pets - Main Menu");
            Console.WriteLine("1. List all of our current pet information.");
            Console.WriteLine("2. Assign values to the ourAnimals array fields.");
            Console.WriteLine("3. Ensure animal ages and physical descriptions are complete.");
            Console.WriteLine("4. Ensure animal nicknames and personality descriptions are complete.");
            Console.WriteLine("5. Edit an animal’s age.");
            Console.WriteLine("6. Edit an animal’s personality description.");
            Console.WriteLine("7. Display all cats with a specified characteristic.");
            Console.WriteLine("8. Display all dogs with a specified characteristic.");
            Console.WriteLine("Type \"Exit\" to exit the program.");
            Console.Write("Enter menu item selection: ");
            string selection = Console.ReadLine();

            if (selection.ToLower() == "exit")
            {
                exit = true;
                continue;
            }

            switch (selection)
            {
                case "1":
                    Console.WriteLine("\nCurrent Pet Information:");
                    for (int i = 0; i < animalCount; i++)
                    {
                        Console.WriteLine($"ID: {ourAnimals[i, 0]}, Species: {ourAnimals[i, 1]}, Age: {ourAnimals[i, 2]}, Physical: {ourAnimals[i, 3]}, Personality: {ourAnimals[i, 4]}, Nickname: {ourAnimals[i, 5]}");
                    }
                    break;

                case "2":
                    if (animalCount >= ourAnimals.GetLength(0))
                    {
                        Console.WriteLine("No more space to add new animals.");
                        break;
                    }

                    Console.Write("Enter species (cat or dog): ");
                    string species = Console.ReadLine().ToLower();
                    if (species != "cat" && species != "dog")
                    {
                        Console.WriteLine("Invalid species.");
                        break;
                    }

                    string newId = (animalCount + 1).ToString();
                    ourAnimals[animalCount, 0] = newId;
                    ourAnimals[animalCount, 1] = species;

                    Console.Write("Enter age (years, or leave blank if unknown): ");
                    string age = Console.ReadLine();
                    ourAnimals[animalCount, 2] = string.IsNullOrWhiteSpace(age) ? "unknown" : age;

                    Console.Write("Enter physical description (or leave blank if unknown): ");
                    string physical = Console.ReadLine();
                    ourAnimals[animalCount, 3] = string.IsNullOrWhiteSpace(physical) ? "unknown" : physical;

                    Console.Write("Enter personality (or leave blank if unknown): ");
                    string personality = Console.ReadLine();
                    ourAnimals[animalCount, 4] = string.IsNullOrWhiteSpace(personality) ? "unknown" : personality;

                    Console.Write("Enter nickname (or leave blank if unknown): ");
                    string nickname = Console.ReadLine();
                    ourAnimals[animalCount, 5] = string.IsNullOrWhiteSpace(nickname) ? "unknown" : nickname;

                    animalCount++;
                    Console.WriteLine("New animal added.");
                    break;

                case "3":
                    for (int i = 0; i < animalCount; i++)
                    {
                        // Age
                        if (string.IsNullOrWhiteSpace(ourAnimals[i, 2]) || ourAnimals[i, 2].ToLower() == "unknown")
                        {
                            Console.WriteLine($"\nAnimal ID {ourAnimals[i, 0]} ({ourAnimals[i, 1]}) is missing age.");
                            Console.Write("Enter age (years): ");
                            string newAge = Console.ReadLine();
                            ourAnimals[i, 2] = string.IsNullOrWhiteSpace(newAge) ? "unknown" : newAge;
                        }
                        if (string.IsNullOrWhiteSpace(ourAnimals[i, 3]) || ourAnimals[i, 3].ToLower() == "unknown")
                        {
                            Console.WriteLine($"\nAnimal ID {ourAnimals[i, 0]} ({ourAnimals[i, 1]}) is missing physical description.");
                            Console.Write("Enter physical description: ");
                            string newPhysical = Console.ReadLine();
                            ourAnimals[i, 3] = string.IsNullOrWhiteSpace(newPhysical) ? "unknown" : newPhysical;
                        }
                    }
                    Console.WriteLine("All animal ages and physical descriptions are now complete (or marked as unknown).");
                    break;

                case "4":
                    for (int i = 0; i < animalCount; i++)
                    {
                        if (string.IsNullOrWhiteSpace(ourAnimals[i, 5]) || ourAnimals[i, 5].ToLower() == "unknown")
                        {
                            Console.WriteLine($"\nAnimal ID {ourAnimals[i, 0]} ({ourAnimals[i, 1]}) is missing nickname.");
                            Console.Write("Enter nickname: ");
                            string newNickname = Console.ReadLine();
                            ourAnimals[i, 5] = string.IsNullOrWhiteSpace(newNickname) ? "unknown" : newNickname;
                        }
                        if (string.IsNullOrWhiteSpace(ourAnimals[i, 4]) || ourAnimals[i, 4].ToLower() == "unknown")
                        {
                            Console.WriteLine($"\nAnimal ID {ourAnimals[i, 0]} ({ourAnimals[i, 1]}) is missing personality description.");
                            Console.Write("Enter personality description: ");
                            string newPersonality = Console.ReadLine();
                            ourAnimals[i, 4] = string.IsNullOrWhiteSpace(newPersonality) ? "unknown" : newPersonality;
                        }
                    }
                    Console.WriteLine("All animal nicknames and personality descriptions are now complete (or marked as unknown).");
                    break;

                case "5":
                    Console.Write("Enter the ID of the animal to edit age: ");
                    string editAgeId = Console.ReadLine();
                    bool foundAge = false;
                    for (int i = 0; i < animalCount; i++)
                    {
                        if (ourAnimals[i, 0] == editAgeId)
                        {
                            Console.WriteLine($"Current age: {ourAnimals[i, 2]}");
                            Console.Write("Enter new age: ");
                            string newAge = Console.ReadLine();
                            ourAnimals[i, 2] = string.IsNullOrWhiteSpace(newAge) ? ourAnimals[i, 2] : newAge;
                            Console.WriteLine("Age updated.");
                            foundAge = true;
                            break;
                        }
                    }
                    if (!foundAge)
                    {
                        Console.WriteLine("Animal ID not found.");
                    }
                    break;

                case "6":
                    Console.Write("Enter the ID of the animal to edit personality: ");
                    string editPersId = Console.ReadLine();
                    bool foundPers = false;
                    for (int i = 0; i < animalCount; i++)
                    {
                        if (ourAnimals[i, 0] == editPersId)
                        {
                            Console.WriteLine($"Current personality: {ourAnimals[i, 4]}");
                            Console.Write("Enter new personality description: ");
                            string newPers = Console.ReadLine();
                            ourAnimals[i, 4] = string.IsNullOrWhiteSpace(newPers) ? ourAnimals[i, 4] : newPers;
                            Console.WriteLine("Personality description updated.");
                            foundPers = true;
                            break;
                        }
                    }
                    if (!foundPers)
                    {
                        Console.WriteLine("Animal ID not found.");
                    }
                    break;

                case "7":
                    Console.Write("Enter a physical characteristic to search for in cats: ");
                    string catCharacteristic = Console.ReadLine().ToLower();
                    bool foundCat = false;
                    for (int i = 0; i < animalCount; i++)
                    {
                        if (ourAnimals[i, 1] == "cat" && ourAnimals[i, 3].ToLower().Contains(catCharacteristic))
                        {
                            Console.WriteLine($"ID: {ourAnimals[i, 0]}, Species: {ourAnimals[i, 1]}, Age: {ourAnimals[i, 2]}, Physical: {ourAnimals[i, 3]}, Personality: {ourAnimals[i, 4]}, Nickname: {ourAnimals[i, 5]}");
                            foundCat = true;
                        }
                    }
                    if (!foundCat)
                    {
                        Console.WriteLine("No cats found with that characteristic.");
                    }
                    break;

                case "8":
                    Console.Write("Enter a physical characteristic to search for in dogs: ");
                    string dogCharacteristic = Console.ReadLine().ToLower();
                    bool foundDog = false;
                    for (int i = 0; i < animalCount; i++)
                    {
                        if (ourAnimals[i, 1] == "dog" && ourAnimals[i, 3].ToLower().Contains(dogCharacteristic))
                        {
                            Console.WriteLine($"ID: {ourAnimals[i, 0]}, Species: {ourAnimals[i, 1]}, Age: {ourAnimals[i, 2]}, Physical: {ourAnimals[i, 3]}, Personality: {ourAnimals[i, 4]}, Nickname: {ourAnimals[i, 5]}");
                            foundDog = true;
                        }
                    }
                    if (!foundDog)
                    {
                        Console.WriteLine("No dogs found with that characteristic.");
                    }
                    break;

                default:
                    Console.WriteLine($"You selected option: {selection}");
                    break;
            }
        }
    }
}