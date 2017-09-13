using System;
using System.Collections.Generic;

namespace EnumerateItems
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] daysOfWeek =
            //{
            //    "Monday",
            //    "Tuesday",
            //    "Wednesday",
            //    "Thursday",
            //    "Friday",
            //    "Saturday",
            //    "Sunday"
            //};

            //String implements IEnumerable<char> which why the code works
            string myName = "Andrei";

            DisplayItems(myName);
            Console.WriteLine();

            //works the same as the custom method
            foreach (char letter in myName)
            {
                Console.WriteLine(letter);
            }
        }

        /// <summary>
        /// This is what a code iterating through a collection might look like
        ///     You never look ahead
        ///     You never attempt to count items
        ///     So it can work with steamed data from outside source
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        public static void DisplayItems<T>(IEnumerable<T> collection)
        {
            //the using block recognizes that IEnumerator implements IDisposable
            //so resources will be cleaned up once it is done
            using (IEnumerator<T> enumerator = collection.GetEnumerator())
            {
                //checking if there are more items
                bool moreItems = enumerator.MoveNext();
                //executing based on the above bool
                while (moreItems)
                {
                    //retrieving current item in the collection
                    T item = enumerator.Current;
                    Console.WriteLine(item);
                    moreItems = enumerator.MoveNext();
                }
            }
        }
    }
}
