namespace FinalTask
{
    abstract class Delivery
    {
        public string HomeAddress;
        public int DeliveryPeriod;
        public abstract string DeliveryType
        {
            get;
            set;
        }
    }

    abstract class WaysOfDelivery
    {
        public string CompanyName;
        public double CompanyFee;
        public string CompanyPhoneNumber;
    }

    class CourierCompany : WaysOfDelivery
    {
        public CourierCompany(string CompanyName, double CompanyFee, string PhoneNumber)
        {
            this.CompanyName = CompanyName;
            this.CompanyFee = CompanyFee;
            CompanyPhoneNumber = PhoneNumber;
        }
    }

    class PickPoint : WaysOfDelivery
    {
        public DateOnly StoragePeriod;
        public string Address;
        public TimeOnly OpeningTime;
        public TimeOnly ClosingTime;
    }

    class Shop : PickPoint
    {

    }

    class HomeDelivery : Delivery
    {
        CourierCompany Courier;
        public override string DeliveryType
        {
            get => DeliveryType;
            set => DeliveryType = "доставка на дом";
        }
        HomeDelivery(string address, CourierCompany courier)
        {
            HomeAddress = address;
            Courier = courier;
        }
    }

    class PickPointDelivery : Delivery
    {
        PickPoint pickPoint = new PickPoint();
        public override string DeliveryType
        {
            get => DeliveryType;
            set => DeliveryType = "доставка в пункт выдачи";
        }
    }

    class ShopDelivery : Delivery
    {
        Shop shop = new Shop();
        public override string DeliveryType
        {
            get => DeliveryType;
            set => DeliveryType = "доставка в магазин";
        }
    }


    class Product <TSpecification>
    {
        public string name;
        public double price;
        public string description;
        public string cathegory;

    }

    
    class Order<TDelivery>
        where TDelivery : Delivery
    {
        public static int OrderCount = 0;

        public Order(string address, string description, TDelivery delivery)
        {
            OrderCount++;
            Number = OrderCount;
            Delivery = delivery;
            delivery.HomeAddress = address;
            Description = description;
        }

        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.HomeAddress);
        }

        public void DisplayInform()
        {
            Console.WriteLine("Заказ номер {0}. Описание: {1}. Доставка по адресу: {2}. Тип доставки {3}.", Number, Description, Delivery.HomeAddress, Delivery.DeliveryType);
        }
        
        //Метод для поиска заказа, перегруженный, поиск по номеру, по адресу, по содержанию

        
    }

    class Program
    {
        static void Main()
        {
            CourierCompany kurier = new CourierCompany("Компания", 555.55, "8 800 55 35 35");

            Order<Delivery> order = new Order<Delivery>("Адрес дотсавки", "заказаны товары", );
            
        }
    }
}