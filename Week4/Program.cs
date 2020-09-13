using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat[] cats = new Cat[3];
            cats[0] = new Cat(2, "Tom");
            cats[1] = new Cat(3, "Jack", "White");
            cats[2] = new Cat(1, "Daizy", "Red");

            Cat youngestCat = FindTheYoungestCat(cats);
            Console.WriteLine(youngestCat.name);

            Console.ReadLine();
        }
        static Cat FindTheYoungestCat(Cat[] cats)
        {
            Cat result = cats[0];
            for (int i = 1; i < cats.Length; i++)
            {
                if (cats[i].age < result.age)
                    result = cats[i];
            }

            return result;
        }
        static void Print(string name)
        {
            name = "Hello " + name;
            Console.WriteLine(name);
        }

        static void Print(Cat cat)
        {
            if (cat == null)
                return;

            cat.age = cat.age + 1;
            Console.WriteLine(cat.age);
            Console.WriteLine(cat.name);
            Console.WriteLine(cat.color);
        }

        static void Print(int age)
        {
            age = age + 1;
            Console.WriteLine(age);
        }
    }

    class Cat
    {
        public Cat(int age, string name, string color)
        {
            this.age = age;
            this.name = name;
            this.color = color;
        }
        public Cat(int age, string name)
        {
            this.age = age;
            this.name = name;
            this.color = "black";
        }
        public Cat() { }

        public int age;
        public string name;
        public string color;

    }
}
