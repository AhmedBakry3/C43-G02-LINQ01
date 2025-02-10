using Assignment_Session_1_LINQ.Classes;
using Assignment_Session_1_LINQ.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.Arm;
using System.Threading;
using System.Xml.Linq;
using static Assignment_Session_1_LINQ.Classes.ListGenerators;
namespace Assignment_Session_1_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators

            #region Question 1 :Find all products that are out of stock. 

            //Fluent Syntax 
            var Result = productsList.Where(P => P.UnitsInStock == 0);


            //Query Syntax
            var Result = from P in productsList
                         where P.UnitsInStock == 0
                         select P;


            foreach (var item in Result)
                Console.WriteLine(item);
            //Output:
            //ProductID:5,ProductName:Chef Anton's Gumbo Mix,CategoryCondiments,UnitPrice:21.3500,UnitsInStock:0
            // ProductID: 17,ProductName: Alice Mutton, CategoryMeat/ Poultry,UnitPrice: 39.0000,UnitsInStock: 0
            //ProductID: 29,ProductName: Thüringer Rostbratwurst, CategoryMeat/ Poultry,UnitPrice: 123.7900,UnitsInStock: 0
            //ProductID: 31,ProductName: Gorgonzola Telino, CategoryDairy Products,UnitPrice: 12.5000,UnitsInStock: 0
            //ProductID: 53,ProductName: Perth Pasties, CategoryMeat/ Poultry,UnitPrice: 32.8000,UnitsInStock: 0

            #endregion

            #region Question 2 : Find all products that are in stock and cost more than 3.00 per unit.

            //Fluent Syntax
            var Result = productsList.Where(P => P.UnitsInStock > 0 && P.UnitPrice > 3.00M);

            //Query Syntax
            var Result = from P in productsList
                         where P.UnitsInStock > 0 && P.UnitPrice > 3.00M
                         select P;

            foreach (var item in Result)
                Console.WriteLine(item);
            #endregion

            #region Question 3 : Returns digits whose name is shorter than their value.

            //String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            ////Fluent Syntax 
            var Result = Arr.Where((C, I) => C.Length < I);
            ////Indexed Syntax Works Only with Fluent Syntax , it can't be used with Query Syntax

            foreach (var item in Result)
                Console.WriteLine(item);
            //Output:
            //five
            //six
            //seven
            //eight
            //nine
            #endregion

            #endregion

            #region LINQ - Element Operators

            #region Question 1 : Get first Product out of Stock 

            //Fluent Syntax 
            var Result = productsList.Where(P => P.UnitsInStock == 0).FirstOrDefault();


            //Element Operators only works with Fluent Syntax , but it can be used with Query Syntax Throught Fluent Syntax [Hybird Syntax]
            //Element Operators can be used as Query Syntax when it applied to filtering, projecting
            // Hybird Syntax = Query Syntax + Fluent Syntax
            // Hybird Syntax = (Query Syntax).Fluent Syntax

            //Hybird Syntax

            var Result = (from p in productsList
                          where p.UnitsInStock == 0
                          select p).FirstOrDefault();

            if (Result is not null)
            {
                Console.WriteLine(Result);
            }
            else
            {
                Console.WriteLine("No Products Found that is  out of stock");
            }

            //Output:
            //ProductID: 5,ProductName: Chef Anton's Gumbo Mix,CategoryCondiments,UnitPrice:21.3500,UnitsInStock:0
            #endregion


            #region Question 2 : Return the first product whose Price > 1000, unless there is no match, in which case null is returned.

            //Fluent Syntax
            var Result = productsList.FirstOrDefault(P => P.UnitPrice > 1000);


            //Hybird Syntax

            var Result = (from p in productsList
                          where p.UnitPrice > 1000
                          select p).FirstOrDefault();

            if (Result is not null)
            {
                Console.WriteLine(Result);

            }
            else
            {
                Console.WriteLine("No Products Found that its price > 1000");
            }

            //Output:
            //No Products Found that its price > 1000
            //if there is no matching => FirstOrDefault will return Null
            //Otherwise it will return the Result 
            #endregion

            #region Question 3 : Retrieve the second number greater than 5 

            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Fluent Syntax

            var Result = Arr.Where(P => P > 5)
                            .ElementAtOrDefault(1);


            //Hybird Syntax

            var Result = (from P in Arr
                          where P > 5
                          select P).ElementAtOrDefault(1);

            Console.WriteLine(Result); 
            //Output :
            // 8


            #endregion

            #endregion

            #region LINQ - Aggregate Operators

            #region Question 1 : Uses Count to get the number of odd numbers in the array

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Fluent Syntax 

            var Result = Arr.Count(O => O % 2 == 1);

            //Aggregate Operators only works with Fluent Syntax , but it can be used with Query Syntax Throught Fluent Syntax [Hybird Syntax]
            //Aggregate Operators can be used as Query Syntax when it applied to filtering, projecting
            // Hybird Syntax = Query Syntax + Fluent Syntax
            // Hybird Syntax = (Query Syntax).Fluent Syntax

            //Hybird Syntax

            var Result = (from O in Arr
                          where O % 2 == 1
                          select O).Count();


            Console.WriteLine(Result);

            //Output : 
            //5

            #endregion

            #region Question 2 : Return a list of customers and how many orders each has.

            //Fluent Syntax
            var Result = CustomersList.Select(C => new
                                            {
                                                CusomterName = C.CustomerName,
                                                OrderCount = C.Orders.Count()
                                            });


            //Query Syntax
            var Result = from C in CustomersList
                         select new
                         {
                             C.CustomerName,
                             OrderCount = C.Orders.Count()
                         };

            foreach(var i in Result)
            //    Console.WriteLine(i);

            #endregion

                
            #region Question 3 : Return a list of categories and how many products each has

            //Fluent Syntax
            var Result = productsList.Select(P => new
                                            {
                                                P.Category,
                                                ProductCount = productsList.Count()
                                            });
                                                                      

            //Query Syntax

            var result = (from P in productsList
                          select new
                          {
                              P.Category,
                              ProductCount = productsList.Count()
                          });

            foreach (var i in Result)
                Console.WriteLine(i);

            #endregion
            #region Question 4 : Get the total of the numbers in an array.

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Fluent Syntax
            var Result = Arr.Sum();


            ////Hybird Syntax

            var Result = (from A in Arr
                          select A).Sum();


            //Console.WriteLine(Result);
            //Output:
            //45

            #endregion

            #region Question 5 : Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            //Read dictionary_english.txt into Array of String First
            string FilePath = "dictionary_english.txt";
            string[] EnglishDictionary = File.ReadAllLines(FilePath);

            ////Fluent Syntax
            var Result = EnglishDictionary.Sum(E => E.Length);

            ////Hybird Syntax
            var Result = (from E in EnglishDictionary
                          select E.Length).Sum();

            Console.WriteLine(Result);
            //Output : 
            //3494688

            #endregion

            #region Question 6 :  Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            ////Fluent Syntax 
            var Result = EnglishDictionary.Min(E => E.Length);


            ////Hybird Syntax
            var Result = (from E in EnglishDictionary
                          select E.Length).Min();


            Console.WriteLine(Result);
            //Output : 1

            #endregion

            #region Question 7 : Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            ////Fluent Syntax 
            var Result = EnglishDictionary.Max(E => E.Length);


            ////Hybird Syntax
            var Result = (from E in EnglishDictionary
                          select E.Length).Max();


            Console.WriteLine(Result);
            //Output : 31
            #endregion

            #region Question 8 :  Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            ////Fluent Syntax
            var Result = EnglishDictionary.Average(E => E.Length);


            ////Hybird Syntax
            var Result = (from E in EnglishDictionary
                          select E.Length).Average();


            Console.WriteLine(Result);
            //Output: 9.442576175563836

            #endregion
            #endregion


            #region LINQ - Ordering Operators

            #region Question 1 : Sort a list of products by name

            //Fluent Syntax

            var Result = productsList.OrderBy(P => P.ProductName);

            //Query Syntax

            var Result = from P in productsList
                         orderby P.ProductName
                         select P;


            foreach (var item in Result)
                Console.WriteLine(item);

            #endregion

            #region Question 2 : Uses a custom comparer to do a case-insensitive sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //Fluent Syntax

            var Result = Arr.OrderBy(W => W, new WordsComparer());


            //Custom Comparer Can be used Only with Fluent Syntax

            //Custom Comparer Can't Be used in Query Syntax , but we can get the same Result without Custom Comparer in Query Syntax by using ToLower()

            //Query Syntax

            var Result = from W in Arr
                         orderby W.ToLower()
                         select W;
            foreach (var item in Result)

             Console.WriteLine(item);
            //Output:

            //AbAcUs
            //aPPLE
            //BlUeBeRrY
            //bRaNcH
            //cHeRry
            //ClOvEr

            #endregion

            #region 3. Sort a list of products by units in stock from highest to lowest.

            //Fluent Syntax

            var Result = productsList.OrderByDescending(P => P.UnitsInStock);


            //Query Syntax

            var Result = from P in productsList
                         orderby P.UnitsInStock descending
                         select P;

            foreach (var item in Result)
                Console.WriteLine(item);

            #endregion
            #region Question 4 : Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //Fluent Syntax

            var Result = Arr.OrderBy(W => W.Length).ThenBy(W => W);


            //Hybir Syntax

            var Result = (from W in Arr
                          orderby W.Length
                          select W).ThenBy(W => W);

            foreach (var item in Result)
                Console.WriteLine(item);

            //Output : 

            //one
            //six
            //two
            //five
            //four
            //nine
            //zero
            //eight
            //seven
            //three
            #endregion

            #region Question 5 : Sort first by-word length and then by a case-insensitive sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //Fluent Syntax

            var Result = Arr.OrderBy(W => W.Length).ThenBy(W => W.ToLower());

            ////Hybird Syntax
            ///
            var Result = (from W in Arr
                          orderby W.Length
                          select W).ThenBy(W => W.ToLower());

            foreach (var item in Result)
                Console.WriteLine(item);

            //Output:

            //aPPLE
            //AbAcUs
            //bRaNcH
            //cHeRry
            //ClOvEr
            //BlUeBeRrY
            #endregion

            #region Question 6 : Sort a list of products, first by category, and then by unit price, from highest to lowest.

            //Fluent Syntax
            var Result = productsList.OrderBy(P => P.Category).ThenByDescending(P => P.UnitPrice);


            //Hybird Syntax
            var Result = (from P in productsList
                          orderby P.Category
                          select P).ThenByDescending(P => P.UnitPrice);




            foreach (var item in Result)
                Console.WriteLine(item);
            #endregion

            #region Question 7 : Sort first by-word length and then by a case -insensitive descending sort of the words in an array.

            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            //Fluent Syntax

            var Result = Arr.OrderBy(W => W.Length).ThenByDescending(W => W.ToLower());

            //Hybird Syntax

            var Result = (from W in Arr
                          orderby W.Length
                          select W).ThenByDescending(W => W.ToLower());

            foreach (var item in Result)
                Console.WriteLine(item);

            //Output:

            //aPPLE
            //ClOvEr
            //cHeRry
            //bRaNcH
            //AbAcUs
            //BlUeBeRrY

            #endregion
            #region Question 8 : Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //Fluent Syntax

            var Result = Arr.Where(W => W.Length > 1 && W[1] == 'i').Reverse();

            //Hybird Syntax

            var Result = (from W in Arr
                          where W.Length > 0 && W[1] == 'i'
                          select W).Reverse();

            foreach (var item in Result)
                Console.WriteLine(item);

            //Output :

            //nine
            //eight
            //six
            //five

            #endregion
            #endregion

            #region LINQ – Transformation Operators

            #region Question 1 : Return a sequence of just the names of a list of products.

            //Fluent Syntax 
            var Result = productsList.Select(P => P.ProductName);


            //Query Syntax
            var Result = from P in productsList
                         select P.ProductName;

            foreach (var item in Result)
                Console.WriteLine(item);

            #endregion
            #region Question 2 : Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            //Fluent Syntax
            var Result = words.Select(W => new
            {
                UpperCaseWord = W.ToUpper(),
                LowerCaseW = W.ToLower(),
            });

            //Query Syntax
            var Result = from W in words
                         select new
                         {
                             UpperCaseWord = W.ToUpper(),
                             LowerCaseW = W.ToLower(),
                         };

            foreach (var item in Result)
                Console.WriteLine(item);

            //Output :
            //{ UpperCaseWord = APPLE, LowerCaseW = apple }
            //{ UpperCaseWord = BLUEBERRY, LowerCaseW = blueberry }
            //{ UpperCaseWord = CHERRY, LowerCaseW = cherry }
            #endregion


            #region Question 3 : Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            //Fluent Syntax

            var Result = productsList.Select(P => new
            {
                P.ProductID,
                P.ProductName,
                Price = P.UnitPrice,
            });

            //Query Syntax

            var Result = from P in productsList
                         select new
                         {
                             P.ProductID,
                             P.ProductName,
                             Price = P.UnitPrice,

                         };

            foreach (var item in Result)
                Console.WriteLine(item);
            #endregion


            #region Question 4 :  Determine if the value of int in an array matches their position in the array. 

            int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //Fluent Syntax 

            Console.WriteLine("Number : InPlace?");

            var Result = Arr.Select((W, I) => $"{W} : {(W == I)}");

            ////Indexed select is valid only with Fluent Syntax , Can't be used with Query Syntax
        
            foreach (var item in Result)
                Console.WriteLine(item);

            //Output : 

            //Number: InPlace ?
            //5 : False
            //4 : False
            //1 : False
            //3 : True
            //9 : False
            //8 : False
            //6 : True
            //7 : True
            //2 : False
            //0 : False

            #endregion
            #region Question 5 : Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.

            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            Console.WriteLine("Pairs where a < b");

            //Fluent Syntax

            var Result = numbersA.SelectMany(a => numbersB, (a, b) => new { a, b })
                             .Where(pair => pair.a < pair.b)
                             .Select(pair => $"{pair.a} is less than {pair.b}");



            //Query Syntax
            var Result = from a in numbersA
                         from b in numbersB
                         where a < b
                         select $"{a} is less than {b}";

            foreach (var item in Result)
                Console.WriteLine(item);

            //Output:

            //Pairs where a < b
            //0 is less than 1
            //0 is less than 3
            //0 is less than 5
            //0 is less than 7
            //0 is less than 8
            //2 is less than 3
            //2 is less than 5
            //2 is less than 7
            //2 is less than 8
            //4 is less than 5
            //4 is less than 7
            //4 is less than 8
            //5 is less than 7
            //5 is less than 8
            //6 is less than 7
            //6 is less than 8
            #endregion

            #region Question 6 : Select all orders where the order total is less than 500.00.

            //Fluent Syntax
            var Result = CustomersList.SelectMany(C => C.Orders).Where(O => O.Total < 500.00M);

            //Query Syntax
            var Result = from C in CustomersList
                         from O in C.Orders
                         where O.Total < 500.00M
                         select O;

            foreach (var item in Result)
                Console.WriteLine(item);

            #endregion

            #region Question 7 : Select all orders where the order was made in 1998 or later.

            //Fluent Syntax
            var Result = CustomersList.SelectMany(C => C.Orders).Where(O => O.OrderDate >= new DateTime(1998, 1, 1));

            //Query Syntax
            var Result = from C in CustomersList
                         from O in C.Orders
                         where O.OrderDate >= new DateTime(1998, 1, 1)
                         select O;

            foreach (var item in Result)
                Console.WriteLine(item);

            #endregion
            #endregion
        }
    }
}
