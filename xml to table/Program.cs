using System;

namespace xml_to_table
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvData = "Publication Date,Title,Authors,28/11/2008,Learning C# 3.0,Jesse Liberty & Brian MacDonald,16/09/2013,Head First C#,Jennifer Greene & Andrew Stellman,27/10/2015,Learn C# in One Day and Learn It Well: C# for Beginners with Hands-on Project: Volume 3,Jamie Chan";

            var maxLength = 30;
            
            var data = csvData.Split(',');
            for (var i = 0; i <= data.Length / 3; i++)
            {
                //skip duplicate rows
                if (i>0 && i%3==0) continue;

                //format string to table with calculated string (truncate if necessary)
                //i % 3 gives the column count
                //i * 2 gives the row count
                //second and third column have a constant of +1 and +2 respectivly
                Console.WriteLine(String.Format("|{0,30}|{1,30}|{2,30}|", NormalizeString(data[(i % 3) + (i * 2)], maxLength), NormalizeString(data[1 + ((i % 3) + (i * 2))], maxLength), NormalizeString(data[2 + ((i % 3) + (i * 2))], maxLength)));
            }
            //waits for user to exit
            Console.ReadKey();
        }

        static string NormalizeString(string str, int maxLength)
        {
            //if strings length is larger than maxLength given the tring is returned truncated
            return str.Length > maxLength ? str.Substring(0, maxLength - 3) + "..." : str;
        }
    }
}
