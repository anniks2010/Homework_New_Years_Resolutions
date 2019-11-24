using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Homework_New_Years_Resolutions
{
    class Resolution
    {
        public string Description;
        public List<Resolution> listOfResolutsionsObjects = new List<Resolution>();

        public Resolution(string _description)
        {
            Description = _description;
        }


        public void PutNewYearsResolutionsToFile(string descrition)
        {
            String[] listOfUserInput = descrition.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            ///To use WriteAllLines to file, firstly you have to create txt file and then you can run this project.
            File.WriteAllLines(@"C:\Users\Kodu\Desktop\New_Years_Resolutions_List.txt", listOfUserInput);
            
            
            ///To use bellowed solution, then you do not have to create txt file, system is doing it for you where you want!!!
            /*string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "New_Years_Resolutions_List.txt")))
            {
                foreach (string line in listOfUserInput)
                {
                    outputFile.WriteLine(line);
                }
                
            }*/
            Console.Clear();
        }
        public void ReadItemsFromFileToList()
        {
            string filePath = @"C:\Users\Kodu\Desktop\New_Years_Resolutions_List.txt";
            List<string> listOfNewYearResolutions = File.ReadAllLines(filePath).ToList();

            List<Resolution> listOfResolutsionsObjects = new List<Resolution>();

            foreach (string line in listOfNewYearResolutions)
            {

                string[] tempArray = line.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
                Resolution newDescriptions = new Resolution(tempArray[0]); 
                listOfResolutsionsObjects.Add(newDescriptions);
            }

            foreach (Resolution lines in listOfResolutsionsObjects)
            {
                Console.WriteLine($"{lines.Description}");
            }
        }

        public void AddNewUserResolutionToFile()
        {
            bool newYearResolutionIsDone = false;

            while (newYearResolutionIsDone != true)
            {
                Console.WriteLine("Would you like to add something else to New Year Resolution List? Y/N");
                string userAnswer = Console.ReadLine().ToUpper();


                if (userAnswer == "Y")
                {
                    Console.WriteLine("Please name new resolution:");
                    string userNewResolution = Console.ReadLine();
                    listOfResolutsionsObjects.Add(new Resolution(userNewResolution));
                    File.AppendAllText(@"C:\Users\Kodu\Desktop\New_Years_Resolutions_List.txt", userNewResolution + Environment.NewLine);
                    Console.Clear();
                    ReadItemsFromFileToList();

                }
                else if (userAnswer == "N")
                {
                    Console.WriteLine("Would you like to remove something from the Resoulution? Y/N");
                    string userAnwerToRemove = Console.ReadLine().ToUpper();
                    if (userAnwerToRemove == "Y")
                    {
                        Console.WriteLine("Please name resolution what is needed to remove:");
                        string removeableResolution = Console.ReadLine();
                        listOfResolutsionsObjects.Remove(new Resolution(removeableResolution));

                        var file = File.ReadAllLines(@"C:\Users\Kodu\Desktop\New_Years_Resolutions_List.txt").Where(resolution => resolution != removeableResolution);
                        File.WriteAllLines(@"C:\Users\Kodu\Desktop\New_Years_Resolutions_List.txt", file);
                        Console.Clear();
                        ReadItemsFromFileToList();

                    }
                    else if(userAnwerToRemove=="N")
                    {
                        newYearResolutionIsDone = true;
                        
                    }
                    
                }
                
            }
        Console.Clear();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Please add your New Years Resolutsions by comma");
            string userInput = Console.ReadLine();

            Resolution userInputForNewYear = new Resolution(userInput);
            userInputForNewYear.PutNewYearsResolutionsToFile(userInput);

            userInputForNewYear.ReadItemsFromFileToList();
            userInputForNewYear.AddNewUserResolutionToFile();

            Console.WriteLine($"Your final New Year's Resolutions List is:");
            userInputForNewYear.ReadItemsFromFileToList();


            Console.ReadLine();
            
        }
    }
}
