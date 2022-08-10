namespace Unit6
{
	class Order
	{
		public int Number;

		public string Description;

		// ... Другие поля
	}

	abstract class Car<TEngine>
		where TEngine : Engine
    {
		public TEngine Engine;
		public virtual void ChangePart<TPart>(TPart newPart) where TPart : CarPart
        {

        }

	}

	class ElectricCar : Car<ElectricEngine>		
	{
		public override void ChangePart<TPart>(TPart newPart)
		{

		}
	}

	class GasCar : Car<GasEngine>
	{
		public override void ChangePart<TPart>(TPart newPart)
		{

		}
	}

	abstract class Engine { }

	class ElectricEngine : Engine { }

	class GasEngine : Engine { }

	abstract class CarPart { }
	class Battery : CarPart { }
	class Differential : CarPart { }
	class Wheel : CarPart { }

	//Добавьте к схеме классов автомобиля следующие классы частей автомобиля: Battery, Differential, Wheel.
	//Также добавьте в класс Car виртуальный обобщённый метод без реализации — ChangePart, который будет принимать один параметр — newPart универсального типа.

	//Реализуйте класс-обобщение Record, у которого будут два универсальных параметра: один — для идентификатора записи (Id), другой — для значения записи (Value).
	//Также в классе реализуйте поле Date типа DateTime.

	class Record<T1, T2>
    {
		public T1 Id;
		public T2 Value;

		public DateTime Date;
    }

	class Obj
	{
		public void Display<T>(T param)
		{
			Console.WriteLine(param.ToString());
		}
	}

	class Program
	{
		public static void Swap<T>(ref T x, ref T y)
		{
			T t = x;
			x = y;
			y = t;
		}


		static void Main(string[] args)
		{
			Obj obj = new Obj();
			obj.Display<int>(345);

			int num1 = 4;
			int num2 = 10;
			Swap<int>(ref num1, ref num2);

			Console.WriteLine("{0} {1}", num1, num2);

			Console.ReadKey();
		}
	}
}
