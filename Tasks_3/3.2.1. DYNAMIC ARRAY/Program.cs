using System;


namespace _3._2._1.DYNAMIC_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] collecttion1 = { 1, 2, 4, 6, 8, 10 };
            int[] collecttion2 = { 3, 5, 7, 9};

            DynamicArray<int> array = new DynamicArray<int>(collecttion1);
            
            Console.WriteLine(new string('-', 45));
            Console.WriteLine("Примеры с коллекциями:");
            Console.WriteLine(new string('-', 45));
            Console.WriteLine("Collection initial:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("Capacity collection initial: " + array.Capacity);
            Console.WriteLine("Length collection initial: " + array.Length);
            Console.WriteLine(new string('-', 35));

            array.AddRange(collecttion2);

            Console.WriteLine("");
            Console.WriteLine("Capacity collection with AddRange(collecttion2 ): " + array.Capacity);
            Console.WriteLine("Length collection with AddRange(collecttion2 ): " + array.Length);
            Console.WriteLine(new string('-', 35));

            array.Remove(7);

            Console.WriteLine("");
            Console.WriteLine("Capacity collection with Remove(7): " + array.Capacity);
            Console.WriteLine("Length collection with Remove(7): " + array.Length);
            Console.WriteLine(new string('-', 35));

            array.Insert(22, 3);
            array.Insert(27, 6);

            Console.WriteLine("Insert(22, 3) & Insert(27, 6):");
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("Collection final:");

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("Capacity collection final: " + array.Capacity);
            Console.WriteLine("Length collection final: " + array.Length);
            Console.WriteLine(new string('-', 45));

            DynamicArray<int> array2 = new DynamicArray<int>() { 1, 2, 4, 6, 8, 10, 2, 4, 6, 8, 10 };

            Console.WriteLine("Примеры с массивом:");
            Console.WriteLine(new string('-', 45));
            Console.WriteLine("Array initial:");

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("Capacity array initial: " + array2.Capacity);
            Console.WriteLine("Length array initial: " + array2.Length);
            Console.WriteLine(new string('-', 35));

            array2.Add(7);
            
            Console.WriteLine("Capacity array with Add(7): " + array2.Capacity);
            Console.WriteLine("Length array with Add(7): " + array2.Length);
            Console.WriteLine(new string('-', 35));

            array2.Remove(2);

            Console.WriteLine("Capacity array with Remove(2):" + array2.Capacity);
            Console.WriteLine("Length array with Remove(2): " + array2.Length);
            Console.WriteLine(new string('-', 35));


            array2.Insert(11, 5);

            Console.WriteLine("Insert(11, 5):");
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("Array final:" );

            for (int i = 0; i < array2.Length; i++)
            {
                Console.Write(array2[i] + " ");
            }

            Console.WriteLine("");
            Console.WriteLine(new string('-', 35));
            Console.WriteLine("Capacity array final: " + array2.Capacity);
            Console.WriteLine("Length array final: " + array2.Length);
            
            Console.ReadLine();
        }
      
    }

    
}
