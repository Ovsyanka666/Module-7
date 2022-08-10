//Создайте классы для следующих объектов компьютера: процессор (Processor), материнская карта (MotherBoard), видеокарта (GraphicCard).
//Унаследуйте их от класса ComputerPart.

//Добавьте в класс ComputerPart абстрактный метод Work без параметров и с типом void.

namespace Unit73
{
    abstract class ComputerPart
    {
        public abstract void Work();
    }

    class Processor : ComputerPart
    {
        public override void Work()
        {
            Console.WriteLine("Processor is working");
        }
    }

    class MotherBoard : ComputerPart
    {
        public override void Work()
        {
            Console.WriteLine("MotherBoard is working");
        }
    }

    class GraphicCard : ComputerPart
    {
        public override void Work()
        {
            Console.WriteLine("GraphicCard is working");
        }
    }
}

namespace Unit5
{
    //Создайте класс Obj, определите в нем поля Name, Description (тип строки) и статическое поле MaxValue типа int, равное 2000.
    class Obj
    {
        public string Name;
        public string Description;

        public static string Parent;
        public static int DaysInWeek;
        public static int MaxValue;

        static Obj()
        {
            Parent = "System.Object";
            DaysInWeek = 7;
            MaxValue = 2000;
        }

    }

    //Создайте класс Helper и определите в нем статический метод Swap типа void, который принимает 2 переменные типа int и меняет их значения местами.

    class Helper
    {
        public static void Swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }

    class Program
    {
        static void Main()
        {
            int a = 5;
            int b = 12;
            Console.WriteLine("Число а {0}, число б {1}", a, b);
            Helper.Swap(ref a, ref b);

            Console.WriteLine("Число а {0}, число б {1}", a, b);

            int num1 = 7;
            int num2 = -13;
            int num3 = 0;

            Console.WriteLine(num1.GetNegative()); //-7
            Console.WriteLine(num1.GetPositive()); //7
            Console.WriteLine(num2.GetNegative()); //-13
            Console.WriteLine(num2.GetPositive()); //13
            Console.WriteLine(num3.GetNegative()); //0
            Console.WriteLine(num3.GetPositive()); //0
        }
    }

    static class GetNumbers
    {
        //Для класса int создайте 2 метода расширения: GetNegative() и GetPositive().

        public static int GetNegative(this int source)
        {
            if (source <= 0)
                return source;
            else
            {
                int res = source * -1;
                return res;
            }
        }

        public static int GetPositive(this int source)
        {
            if (source >= 0)
                return source;
            else
            {
                int res = source * -1;
                return res;
            }
        }
    }
}