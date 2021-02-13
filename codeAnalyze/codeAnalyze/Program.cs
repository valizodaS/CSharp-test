using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeAnalyze
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyValuePair<int, string>[] a = new KeyValuePair<int, string>[0];
            Console.WriteLine("Using the given functions\n");
            Func2(ref a, 2, "Hello");
            Func2(ref a, 5, "world");
            Func2(ref a, 3, "done");
            Func2(ref a, 2, "what");
            Func2(ref a, 10, "Good buy");
            Func2(ref a, 505, "Good buy");
            ShowA(a);


            KeyValuePair<int, string>[] b = new KeyValuePair<int, string>[0];
            Console.WriteLine("\n\n\nThe same thing with the eddited functions\n");
            Func2Edited(ref b, 2, "Hello");
            Func2Edited(ref b, 5, "world");
            Func2Edited(ref b, 3, "done");
            Func2Edited(ref b, 2, "what");
            Func2Edited(ref b, 10, "Good buy");
            Func2Edited(ref b, 505, "Good buy");
            ShowA(a);
            Console.ReadLine();
        }

 
        static int Func1(KeyValuePair<int, string>[] a, int low, int high, int key)
        {
            int middle = low + ((high - low) / 2);  //здесь можно было бы  написать так ==>  int middle = (high + low) / 2;

            if (low == high)
                return low;

            if (key > a[middle].Key)
                return Func1(a, middle + 1, high, key);

            return Func1(a, low, middle, key);
        }

        static void Func2(ref KeyValuePair<int, string>[] a, int key, string value)
        {
            int pos;
            KeyValuePair<int, string> keyValuePair;

            if (a.Length == 0)
            {
                Array.Resize(ref a, 1);
                keyValuePair = new KeyValuePair<int, string>(key, value);
                a[0] = keyValuePair;
                return;
            }

            if (key < a[0].Key)
                pos = 0;
            else if (key > a[a.Length - 1].Key)
                pos = a.Length;
            else
                pos = Func1(a, 0, a.Length - 1, key);

            Array.Resize(ref a, a.Length + 1);
            for (int i = a.Length - 1; i > pos; i--)
                a[i] = a[i - 1];

            keyValuePair = new KeyValuePair<int, string>(key, value);
            a[pos] = keyValuePair;
        }

        static void Func2Edited(ref KeyValuePair<int, string>[] a, int key, string value)
        {
            int pos;
            KeyValuePair<int, string> keyValuePair;

            if (a.Length == 0)
            {
                Array.Resize(ref a, 1);
                keyValuePair = new KeyValuePair<int, string>(key, value);
                a[0] = keyValuePair;
                return;
            }

            if (key < a[0].Key)
                pos = 0;
            else if (key > a[a.Length - 1].Key)
                pos = a.Length;
            else
                pos = AdderWithoutRecursion(a, 0, a.Length - 1, key);

            Array.Resize(ref a, a.Length + 1);
            for (int i = a.Length - 1; i > pos; i--)
                a[i] = a[i - 1];

            keyValuePair = new KeyValuePair<int, string>(key, value);
            a[pos] = keyValuePair;
        }

        static int AdderWithoutRecursion(KeyValuePair<int, string>[] a, int low, int high, int key)
        {
            int middle;
            int index = -1;

            while (index == -1) {
                if (low == high)
                {
                    index = low;
                }
                else
                {
                    middle = (low + high) / 2;
                    if (key == a[middle].Key)
                    {
                        index = middle;
                        break;
                    }
                    else if (key > a[middle].Key)
                    {
                        low = middle + 1;
                    }
                    else
                    {
                        high = middle - 1;
                    }
                }

            }

            return index;
        }

        public static void ShowA(KeyValuePair<int, string>[] a){
            for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine("key:{0}{1}value:{2}",a[i].Key,new string(' ', 10-a[i].Key.ToString().Length), a[i].Value);
                }
        }
    }
}
