using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //needs this for any system input / output
using System.Windows;

namespace COMP123_Lesson9_Part1
{
    class Program
    {
        static void Main(string[] args)
        {
            string appDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            //string pathName = "H:\\Winter 2015\\COMP123\\wk9\\COMP123-Lesson9-Part1\\COMP123-Lesson9-Part1\\";
            //string pathRoot = Path.GetFullPath(pathName);
            string fileName="testFile.txt";
            string delimeter = ",";
            //Console.WriteLine(pathRoot);
            Console.WriteLine(appDir);


            WriteFielMethod(appDir, fileName, delimeter);

            ReadFielMethod(appDir, fileName, delimeter);


            WaitForKey(); //wait key method
        }

       

        private static void WriteFielMethod(string pathName, string fileName, string delimeter)
        {
            try
            {
                FileStream outFile = new FileStream(pathName + fileName, FileMode.Create, FileAccess.Write); //create file named testFile.txt

                StreamWriter writer = new StreamWriter(outFile); //write file to the "outFile"

                for (int row = 0; row < 10; row++)
                {
                    writer.Write(row + " ");
                    for (int col = 0; col < 4; col++)
                    {
                        writer.Write("Hello World!"); //write hello world
                        if (col < 3)
                        {
                            writer.Write(delimeter); //write a ","
                        }

                    }
                    writer.WriteLine();
                    

                }


                writer.Close(); //close file

                outFile.Close(); //closes the file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("you code caused a darn error!!!");
                Console.WriteLine("Error: {0}", error.Message);
            }
        }

        private static void ReadFielMethod(string pathName, string fileName, string delimeter)
        {
            string fileData = "";
            string[] fileArray = new string[10];
            try
            {
                FileStream inFile = new FileStream(pathName + fileName, FileMode.Open, FileAccess.Read); //create file named testFile.txt

                StreamReader reader = new StreamReader(inFile); //write file to the "outFile"
                for (int row = 0; row < 10; row++)
                {
                    fileData = reader.ReadLine();
                    fileArray[row] = fileData;
                    Console.WriteLine("Your data: {0}", fileData);
                }// Read one record (line of data)



                reader.Close(); //close file

                inFile.Close(); //closes the file stream
            }
            catch (Exception error)
            {
                Console.WriteLine("you code caused a darn error!!!");
                Console.WriteLine("Error: {0}", error.Message);
            }
        }


        // UTILITY METHODS
        private static void WaitForKey()
        {
            Console.WriteLine();
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Press any key to continue...");
            Console.WriteLine("++++++++++++++++++++++++++++++++++");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
