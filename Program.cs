// Add data from file to array
string file = "characterFile.txt";
string id = "";
using (StreamReader sr = new StreamReader(file)) {
    while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            // convert string to array
            id = line.Substring(0, line.IndexOf(","));
        }
}
    
string? choice;

do
{
    // ask user a question
    Console.WriteLine("1) Display characters in file.");
    Console.WriteLine("2) Add character to file.");
    Console.WriteLine("Enter any other key to exit.");
    // input response
    choice = Console.ReadLine();

    if (choice == "1")
    {
        // TODO: read data from file
        using (StreamReader sr = new StreamReader(file)){
            while (!sr.EndOfStream)
            {
                string? line = sr.ReadLine();
                // convert string to array
                string[] arr = String.IsNullOrEmpty(line) ? [] : line.Split(',');
                // display array data
                Console.WriteLine("ID: {0}, Name: {1}, Relationship to Mario: {2}", arr[0], arr[1], arr[2]);
            }
            sr.Close();
        }
           
    }
    else if (choice == "2")
    {
        using (StreamWriter sw = new StreamWriter("characterFile.txt", true)) {
            Console.WriteLine("What is the character's name?");
            // Gather data
            string? name = Console.ReadLine();
            Console.WriteLine("What is the character's relationship to Mario?");
            string? relationship = Console.ReadLine();

            // // Add character
            int tempID = int.Parse(id) + 1;
            string character = tempID + "," + name + "," + relationship;
            sw.WriteLine(character);
            Console.WriteLine("Character added.");
            id = tempID + "";
            sw.Close();
        }
        
    }
} while (choice == "1" || choice == "2");
