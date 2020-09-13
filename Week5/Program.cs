using System;
using Week5.Models;
using MyLibrary;
using Newtonsoft.Json;

namespace Week5
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Dog myDog = new Dog();
            Cat myCat = new Cat();
            myCat.age = 2;

            string json = JsonConvert.SerializeObject(myCat);
            Console.WriteLine(json);

            Cat myNewCat = JsonConvert.DeserializeObject<Cat>(json);
            Console.WriteLine(myNewCat.age);
        }
    }
}