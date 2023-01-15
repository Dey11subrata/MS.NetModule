
using System.Collections;

namespace HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("here sorting would be based upon the value of vlaue");
            Console.WriteLine("HashTable");
            Console.WriteLine("-----------------------------");
            Hashtable dict = new Hashtable();
            dict.Add(1, "subrata");
            dict.Add(2, "suresh");
            dict.Add(3, "sumit");
            dict.Add(4, "raghu");
            //dict.Add(4, "raghu");

            foreach(DictionaryEntry item in dict)
            {
                Console.WriteLine($"key value is {item.Key} and value of name is {item.Value}");
            }

            Console.WriteLine("-----------------------------");

            /*Same content with sortedset*/
            Console.WriteLine("here sorting would be based upon the value of keys");
            Console.WriteLine("SortedSet");
            Console.WriteLine("-----------------------------");
            SortedList dict2 = new SortedList();
            dict2.Add(2, "subrata");
            dict2.Add(9, "raghu");
            dict2.Add(4, "suresh");
            dict2.Add(1, "sumit");

            foreach (DictionaryEntry item in dict2)
            {
                Console.WriteLine($"key value is {item.Key} and value of name is {item.Value}");
            }
            Console.WriteLine("-----------------------------");

            dict2[5] = "padmakar";
            dict2[4] = "tushar";
            dict2[4] = "timy"; // overriding above one
            dict2[6] = "Akash";
            dict2[7] = "Chaundu";
            dict2[8] = "Nikhil";
            foreach (DictionaryEntry item in dict2)
            {
                Console.WriteLine($"key value is {item.Key} and value of name is {item.Value}");
            }

            
        } 

            
    }
}