using System;

namespace Week6
{
    abstract class Animal
    {
        public string Name;
        public Animal(string name)
        {
            this.Name = name;
        }
        public abstract string SayYourName();   
    }
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
                
        public override string SayYourName()
        {
            return "I'm Dog!";
        }
    }
    class Cat : Animal
    {
        public string TailColor;
        public Cat(string name, string tailColor) : base(name)
        {
            this.TailColor = tailColor;
        }
        public void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
        public override string  SayYourName()
        {
            return"I'm cat!";
        }
    }
}
