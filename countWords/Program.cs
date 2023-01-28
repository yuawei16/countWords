using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    /// <summary>
    /// A console class which takes one command line argument for the file and prints
    /// out the occurrences of matched result of the file name.
    /// </summary>

    public class Program
    {
        /// <value>
        /// The <c>arg</c> property represent the file
        /// for this instance.
        /// </value>
        public static string? arg;

        public Program(string arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(nameof(arg));
            }

            Program.arg = arg;
        }

        /// <summary>
        /// Gets the file name for search.
        /// </summary>
        /// <returns>
        /// A file name.
        /// </returns>
        /// <exception cref="Exception">
        /// Throw when file is not provided.
        /// </exception>
        public String getSearchWord()
        {
            if (string.IsNullOrEmpty(Program.arg)) {
                throw new Exception("There is no file path!"); 
            }
            String fileFName = Path.GetFileNameWithoutExtension(Program.arg);

            return fileFName;
        }

        /// <summary>
        /// Get the counts of matched file name in the file.
        /// </summary>
        /// <param name="keyWord">
        /// The file name which is used for search.
        /// </param>
        /// <returns>
        /// The number of counts matched.
        /// </returns>
        /// <exception cref="Exception">
        /// Throw when file is not provided.
        /// </exception>
        public int getCounts(String keyWord)
        {
            string line;
            int counter = 0;

            if (string.IsNullOrEmpty(Program.arg))
            {
                throw new Exception("There is no file path!");
            }
            FileStream file = File.Open(Program.arg, FileMode.Open);
            StreamReader reader = new StreamReader(file);
            
            while (true)
            {
                line = reader.ReadLine();

                if (line == null)
                {
                    break;
                }
                else
                {
                    // Use Regex to match the exact file name.
                    String pattern = keyWord;
                    Regex rg = new Regex(pattern);
                    var count = rg.Matches(line).Count;
                    counter += count;

                    ////This is another approach which needs to exhaust the splitters.
                    ////Convert the string into an array of words
                    //string[] searchSource = line.Split('.', '?', '!', ' ', ';', ':', ',', '"', '-', '@', '\n');

                    //// Create the query and make it case insensitive.
                    //var matchQuery = from word in searchSource
                    //                 where word.Equals(keyWord, StringComparison.InvariantCultureIgnoreCase)
                    //                 select word;

                    //int lineOccurances = matchQuery.Count();
                    //counter += lineOccurances;
                }
            }
            return counter;
        }

        /// <summary>
        /// The entry to run the program.
        /// </summary>
        /// <param name="args">
        /// The argument of the provided file.
        /// </param>
        public static void Main(string[] args)
        {
            // Add Error handling when file not provided or provided file is not existed.
            try
            {
                Program program = new Program(args[0]);
                string searchWord = program.getSearchWord();
                Console.WriteLine("THe search word is: " + searchWord);
        
                int result = program.getCounts(searchWord);
                Console.WriteLine("Found: {0}", result);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please provide a file argument!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not existed!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
        }
    }
}