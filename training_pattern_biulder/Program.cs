public class Car
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public bool TripComputer { get; set; }
    public bool GPS { get; set; }

    public override string ToString()
    {
        return $"Машина с {Seats} креслами \n{Engine} \nБортовой компьютер: {TripComputer} \nGPS: {GPS}";
    }
}

public class CarManual
{
    public int Seats { get; set; }
    public string Engine { get; set; }
    public string TripComputerInstructions { get; set; }
    public string GPSInstructions { get; set; }

    public override string ToString()
    {
        return $"\nРуководство по эксплуатации:\n{Engine}\nинструкция бортового компьютера:{TripComputerInstructions}\nинструкциями GPS: {GPSInstructions}";
    }
}

public interface IBuilder
{
    void Reset();
    void SetSeats(int number);
    void SetEngine(string engine);
    void SetTripComputer();
    void SetGPS();
}

public class CarBuilder : IBuilder
{
    private Car _car;

    public CarBuilder()
    {
        _car = new Car();
    }

    public void Reset()
    {
        _car = new Car();
    }

    public void SetSeats(int number)
    {
        _car.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _car.Engine = engine;
    }

    public void SetTripComputer()
    {
        _car.TripComputer = true;
    }

    public void SetGPS()
    {
        _car.GPS = true;
    }

    public Car GetResult()
    {
        return _car;
    }
}

public class CarManualBuilder : IBuilder
{
    private CarManual _manual;

    public CarManualBuilder()
    {
        _manual = new CarManual();
    }

    public void Reset()
    {
        _manual = new CarManual();
    }

    public void SetSeats(int number)
    {
        _manual.Seats = number;
    }

    public void SetEngine(string engine)
    {
        _manual.Engine = engine;
    }

    public void SetTripComputer()
    {
        _manual.TripComputerInstructions = " Стоит прошивка 10 версии";
    }

    public void SetGPS()
    {
        _manual.GPSInstructions = "Имеет на борту Карбюратор, инжектор, инспектор проректор\r\nИК-порт, блютуз, туз, козырь, валет\r\nДама, румба, сальса, танго, манго, Мисс Бахар\r\nСеть магазинов Сабина, э\r\nСисле, Элвис Пресли , Джек Дэниелс, Уолт Дисней\r\nФренсис Форд Коппола, акапелла, опера, хор\r\nНейша хор, винзавод, Новый Год, Новруз Байрам\r\nДень Независимости, Праздник Святого Патрика \r\n\r\nДальше\r\nПолный салон, наверху, внизу люк\r\nПанорама, балкон, фасад\r\nСмотровая площадка, зеркало заднего вида\r\nЗеркало монитора, зеркало фонарь\r\nЗеркало заставки, приставка, 10 к 1 ставка, полставки\r\nПодставка, булавка, козявкаПошли дальше\r\nЗатем\r\nDVD, VCD, впереди не перди, CD и не рыпайся\r\nMP3, MP4, М-пакет, М-торба, М-зембиль\r\nChanger, обмен, я не вижу изменений, Калифорния любит\r\nДвое самых разыскиваемых в Америке, Hit'em Up (и-и-и)\r\nПакет мемори, мемори-карта, мультимедийная карта\r\nФлеш-карта, кардридер, сидр, гнойный пидр, лидер (и-и-и)\r\nАНС, Аз-ТВ, Аз Саманд, Аз-Петрол\r\nAsta la vista, Vista, XP, Windows\r\nЗатем\r\nнастройки Сидение, вставание, лежание\r\nФункция \"Забеременеть\"\r\nМеню, функции, браузер\r\nМои приложения, Игры, Контакты , SIM\r\nКондиционер Сплит, вентилятор, печь\r\nАвтонагрев, греф, Доля\r\nПосылка, доставка, отчёт переданных\r\nВходящих, исходящих\r\nМоих папок, Шаблоны, СМС-сообщения\r\nЭлектронная почта";
    }

    public CarManual GetResult()
    {
        return _manual;
    }
}

public class Director
{
    public void MakeSUV(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(5);
        builder.SetEngine("Двигатель от ракеты");
        builder.SetTripComputer();
        builder.SetGPS();
    }

    public void MakeSportsCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(5);
        builder.SetEngine("Двигатель от ракеты");
        builder.SetTripComputer();
        builder.SetGPS();
    }
}

public class Programm
{
    public static void Main(string[] args)
    {
        Director director = new Director();

        CarBuilder carBuilder = new CarBuilder();
        director.MakeSportsCar(carBuilder);
        Car car = carBuilder.GetResult();
        Console.WriteLine(car);

        CarManualBuilder manualBuilder = new CarManualBuilder();
        director.MakeSUV(manualBuilder);
        CarManual manual = manualBuilder.GetResult();
        Console.WriteLine(manual);
    }
}