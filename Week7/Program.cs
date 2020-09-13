using System;
using System.IO;
using System.Text;

namespace Week7
{
    class Program
    {
        static void Main(string[] args)
        {
            //Player player1 = new Player("Alex");
            //Player player2 = new Player("Vital");


            //player1.SayYourName();
            //player2.SayYourName();

            //Player.Calculate(1, 1);
            //Player.InitialBonus = 100;
            //Player.Calculate(1, 1);
            //Player.InitialBonus = 200;
            //Player.Calculate(1, 1);

            //Cat tom = new Cat("Tom");
            //tom.SayYourName();
            ////tom.Name = "John";
            //Console.WriteLine(tom.Name);

            //Console.WriteLine("Hello World!");
            Cat tom = new Cat("Jerry");
            tom.Load("D:/Экспертизы/2020.09/tom.txt");
        }
        //static void DoSmth(Cat cat)
        //{
        //    //
        //}
    }
    //class Player
    //{
    //    public string Name;
    //    public static int InitialBonus;

    //    static Player() { InitialBonus = 300; }

    //    public Player(string name) { this.Name = name; }

    //    public void SayYourName()
    //    {
    //        Console.WriteLine(this.Name);
    //    }
    //    public static void Calculate(int a, int b)
    //    {
    //        Console.WriteLine(Player.InitialBonus + a + b);
    //    }
    //}
    //class Cat
    //{
    //    private string name;

    //    public string Name { get; set; }

    //    public Cat(string name)
    //    {
    //        this.Name = name;
    //    }
    //    public void SayYourName()
    //    {
    //        Display();
    //        Display();
    //        Display();
    //    }
    //    private void Display()
    //    {

    //    }
    //}
    class Cat
    {
        public string Name { get; set; }
        public Cat(string name)
        {
            this.Name = name;
        }
        public void Save(string filePath)
        {
            FileInfo myFile = new FileInfo(filePath);
            if (myFile.Exists)
            {
                myFile.Delete();
            }

            FileStream fileStream = myFile.OpenWrite();
            StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8);
            sw.WriteLine(this.Name);
            sw.Flush();
            sw.Close();
        }
        public void Load(string filePath)
        {
            FileInfo myFile = new FileInfo(filePath);
            FileStream fileStream = myFile.OpenRead();
            if (!myFile.Exists)
            {
                throw new FileNotFoundException();
            }

            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                try
                {
                    this.Name = sr.ReadLine();
                }
                catch (Exception)
                {
                    //
                }
            }
        }
    }
}
