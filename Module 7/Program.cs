class Car
{
	public double Fuel;

	public int Mileage;

	public Car()
	{
		Fuel = 50;
		Mileage = 0;
	}

	public void Move()
	{
		// Move a kilometer
		Mileage++;
		Fuel -= 0.5;
	}

	public void FillTheCar()
	{
		Fuel = 50;
	}
}

enum FuelType
{
	Gas = 0,
	Electricity
}

class HybridCar : Car
{
	public FuelType FuelType;

	public void ChangeFuelType(FuelType type)
	{
		FuelType = type;
	}
}

class Employee
{
	public string Name;
	public int Age;
	public int Salary;
}

//Класс ProjectManager должен содержать строковое поле ProjectName, а класс Developer — строковое поле ProgrammingLanguage.

class ProjectManager : Employee
{
	string ProjectName;
}

class Developer : Employee
{
	string ProgrammingLanguage;
}

class Obj
{
	public int Value;

	public Obj(int value)
    {
		Value = value;
    }

	public Obj()
	{
	}

	public static Obj operator +(Obj first, Obj second)
	{
		return new Obj { Value = first.Value + second.Value };
	    
    }
}


class SmartHelper
{
	private string name;

	public SmartHelper(string name)
	{
		this.name = name;
	}

	public void Greetings(string name)
	{
		Console.WriteLine("Привет, {0}, я интеллектуальный помощник {1}", name, this.name);
	}
}
class Program
{
    static void Main(string[] args)
    {
        SmartHelper helper = new SmartHelper("Олег");
        helper.Greetings("Грег сука");

		Obj obj1 = new Obj(5);
		Obj obj2 = new Obj(10);

		Console.WriteLine((obj1 + obj2).Value);
	}

}

class BaseClass
{
	protected string Name;

	public BaseClass(string name)
	{
		Name = name;
	}

	public virtual void Display()
    {		
		Console.WriteLine("Метод класса BaseClass");
    }

	public virtual int Counter
	{
		get;
		set;
	}
}

class DerivedClass : BaseClass
{
	public string Description;

	private int counter;

    public override int Counter
	{
        get
        {
			return counter;
        }
		set
		{
			if (value <= 0)
				Console.WriteLine("Введите число больше 0");
			else
				counter = value;
		}
	}


    public override void Display()
	{
		base.Display();
		Console.WriteLine("Метод класса DerivedClass");
	}

	public DerivedClass(string name, string Description) : base(name)
    {
		this.Description = Description;
    }

	public DerivedClass(string name, string Description, int Counter) : base(name)
	{
		this.Description = Description;
		this.Counter = Counter;
	}

	class IndexingClass
	{
		private int[] array;

		public IndexingClass(int[] array)
		{
			this.array = array;
		}

		public int? this [int index]
        {
			get
            {
				if (index >= 0 && index < array.Length)
				{
					return array[index];
				}
				else return null;
            }

			set
            {
				if (index >= 0 && index < array.Length)
				{
					array[index] = (int)value;
				}
			}
        }
	}
}