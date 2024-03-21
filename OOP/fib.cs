using System.Collections.Generic;
using System;
class Program
{

    static List<int> fibo(int n)
    {
        List<int> list = new List<int>() { 0, 1, 1 };
        int a = 1;
        int b = 1;
        int f;
        for (int i = 3; i <= n; i++)
        {
            f = a + b;
            b = a;
            a = f;
            list.Add(f);
        }
        return list;

    }

    static void Main()
    {
        List<int> list = new List<int>();
        list = fibo(10);

        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }

    }
}