/*
 Program was made Thu Apr 25, 2024 1:03AM
 Author: Dervin Altenor
 This program is made to organize the files on my computer. I had a very unorganized
 desktop and made this program to sort each file into a folder by their extension.
 
 Program was made Thu Apr 25, 2024 1:03AM
 Author: Dervin Altenor
 
 Used YouTube and Chatgpt as assistance to write and fix errors in program.
 */


using static System.Console;

class FileSorter
{
    static void Main()
    {
        WriteLine("This is a program to organize your files by their extension.");
        
        string directoryToOrganize = @"_________"; // <---- enter directory that you want to sort between quotes
        
        
        if (!Directory.Exists(directoryToOrganize)) // stops program if directory doesn't exist
        {
            WriteLine($"Directory '{directoryToOrganize}' does not exist.");
            return;
        }
        
        SortFiles(directoryToOrganize); // calls method
        
        WriteLine("Finished storing files");

    }

    static void SortFiles(string directoryToOrganize)
    {
        try
        {
            string[] files = Directory.GetFiles(directoryToOrganize);  // to get all files in directory

            foreach (string file in files)
            {
                string extension = Path.GetExtension(file);  // gets extension of file
                
                string extensionDirectory = Path.Combine(directoryToOrganize, extension.TrimStart('.'));
                Directory.CreateDirectory(extensionDirectory); // creates directory if one doesn't exist for extension

                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(extensionDirectory, fileName);
                File.Move(file,destinationPath); // moves file to extension directory
            }
        }
        catch (Exception ex)
        {
            WriteLine($"Error organizing files: {ex.Message}");
        }
    }
}