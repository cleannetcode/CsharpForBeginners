using System;

namespace BlackJack
{
    public class Game
    {
        public void Start()
        {
            //_player = new User();
            //_player.GetScore();

            //User player = new Player("Maksims Sol");
            //User computer = new Computer();

            //Console.WriteLine(player.GetScoreInfo());
            //Console.WriteLine(computer.GetScoreInfo());

            //Console.WriteLine(player.GetName());
            //Console.WriteLine(computer.GetName());
            Test<int>.MyProperty = 124;
            Test<int>.MyProperty2 = 124;
            Test<string>.MyProperty = "sdfds";
            Test<string>.MyProperty2 = 124;
            Console.WriteLine(Test<int>.MyProperty);
            Console.WriteLine(Test<string>.MyProperty);
            Console.WriteLine(Test<int>.MyProperty2);
            Console.WriteLine(Test<string>.MyProperty2);
        }
    }

    public abstract class User
    {
    }

    public class Player : User
    {
        
    }

    public class Computer : User
    {
       
    }

    public class Test<T>
    {
        public static T MyProperty { get; set; }
        public static int MyProperty2 { get; set; }
    }
}
