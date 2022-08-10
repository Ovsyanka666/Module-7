abstract class Delivery
{
    public string DName;
    protected double DPrice;

    protected double Dprice
    {
        get { return DPrice; }
        set
        {
            if (value > 0)
                DPrice = value;
            else
                Console.WriteLine("Введена неверная цена.");
        }

    }
    protected int DPeriod;
    protected string DPhone;

    public Delivery(string name, double price, int period, string phone)
    {
        DName = name;
        DPrice = price;
        DPeriod = period;
        DPhone = phone;
    }

    public abstract void ShowInfo();
}

struct Courier
{
    public string CName { get; }
    public string CPhone { get; }

    public Courier(string name, string phone)
    {
        CName = name;
        CPhone = phone;
    }
}

class HomeDelivery : Delivery
{
    Courier Courier;
    public HomeDelivery(string name, double price, int period, string phone, Courier courier) : base(name, price, period, phone)
    {        
        Courier = courier;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Служба доставки: {0}. Стоимость услуг: {1} рублей. Время доставки {2} дней.\nКонтактный телефон {3}.\n", DName, DPrice, DPeriod,DPhone);
    }
}

class PickPointDelivery : Delivery
{
    public string PickPointAddress;
    public TimeOnly OpeningTime = new TimeOnly(10, 00);
    public TimeOnly ClosingTime = new TimeOnly(19, 30);

    public PickPointDelivery(string name, double price, int period, string phone, string address) : base(name, price, period, phone)
    {
        PickPointAddress = address;        
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Доставка в пункты выдачи заказов: {0}. Стоимость услуг: {1} рублей. Время доставки {2} дней.", DName, DPrice, DPeriod);
        Console.WriteLine("Адрес пункта выдачи {0}. Время работы с {1} по {2}.\nКонтактный телефон {3}.\n", PickPointAddress, OpeningTime, ClosingTime, DPhone);
    }
}

class ShopDelivery : PickPointDelivery
{
    public string Comment;

    public ShopDelivery(string name, double price, int period, string phone, string address, string comment) : base(name, price, period, phone, address)
    {
        Comment = comment;
    }

    public override void ShowInfo()
    {
        Console.WriteLine("Доставка в магазин {0}. Стоимость услуг: {1} рублей. Время доставки {2} дней.", DName, DPrice, DPeriod);
        Console.WriteLine("Адрес магазина {0}. Время работы с {1} по {2}.\nКонтактный телефон {3}. {4}\n", PickPointAddress, OpeningTime, ClosingTime, DPhone, Comment);
    }
}

class Product
{
    public static Product operator + (Product a, Product b)
    {
        return new Product
        {
            price = a.price + b.price
        };
    }
        
    private double price;
    public string name;
    public string cathegory;
    public double Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
                Console.WriteLine("Введена неверная цена.\n");
            else
                price = value;
        }
    }   

    public Product(string name, double price, string cathegory)
    {
        this.name = name;
        Price = price;
        this.cathegory = cathegory;
    }
    public Product(){}

}

class Order<TDelivery> where TDelivery : Delivery
{
    public TDelivery Delivery;

    public static int Number;    

    public int number;
    public Product[] Contain;    
    public string Address;
    private double TotalPrice;


    public Order() { }
    public Order(string address, Product[] products, TDelivery delivery)
    {
        Number++;
        number = Number;
        Address = address;
        TotalPrice = TotalPriceCount(products);
        Contain = products;
        Delivery = delivery;

        OrderInfo();
        
        Console.WriteLine("Всего заказов " + delivery.DName + ": " + Number + "\n");
    }       

    public void OrderInfo()
    {
        Console.WriteLine("Заказ по адресу: {0}", Address);
        Console.WriteLine("Содержание заказа: ");
        foreach (Product el in Contain)
        {
            Console.Write(el.name + " ");
        }
        Console.WriteLine("\nОбщая стоимость: " + Math.Round(TotalPrice, 2));
    }

    public double TotalPriceCount(Product[] array)
    {
        double sum = 0;
        foreach (Product el in array)
        {
            sum += el.Price;
        }
        return sum;
    }

    public void DisplayAddress()
    {
        Console.WriteLine(Address);
    }
       
}

class Program
{
    public static void Main()
    {
        Courier Ivan = new Courier("Иван", "8(800)555-35-35");
        Courier Vasiliy = new Courier("Василий", "8(800)555-35-36");

        HomeDelivery DeloLinii = new HomeDelivery("Деловые линии", 3500.00, 3, "8(950)325-45-45", Ivan);
        PickPointDelivery Sdek = new PickPointDelivery("СДЭК", 1650.50, 5, "8(458)489-62-15", "ул. Пушкина, д. 13");
        ShopDelivery Magnit = new ShopDelivery("Магнит", 550.60, 6, "8(157)485-78-59", "ул. Тарутинская, д. 12", "Выдача заказов на кассе номер 5.");

        DeloLinii.ShowInfo();
        Sdek.ShowInfo();
        Magnit.ShowInfo();


        Product shave = new Product("бритва", 1.25, "красота");
        Product boot = new Product("ботинок", 5.23, "одежда");
        Product fork = new Product("вилка", -7, "инструменты");
        Product lamp = new Product("лампа", 13.78, "товары для дома");
         
        Product[] products = new Product[]
        {
            shave, boot, fork, lamp
        };

        Product[] products2 = new Product[]
        {
            boot, boot, lamp
        };

        Product[] products3 = new Product[]
        {
            lamp, lamp
        };

        Order<HomeDelivery> order = new Order<HomeDelivery>("Г. Москва, ул. Ленина, 60", products, DeloLinii);
        Order<ShopDelivery> order2 = new Order<ShopDelivery>("Г. Калуга, ул. Кирова, 13", products2, Magnit);
        Order<PickPointDelivery> order3 = new Order<PickPointDelivery>("Г. Калуга, ул. Кирова, 13", products3, Sdek);
        Order<ShopDelivery> order4 = new Order<ShopDelivery>("Г. Калуга, ул. Кирова, 13", products2, Magnit);



    }
}