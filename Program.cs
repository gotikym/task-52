using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        ListCriminals listCriminals = new ListCriminals();
        listCriminals.Search();
    }
}

class ListCriminals
{
    private List<Criminal> _criminals = new List<Criminal>();

    public ListCriminals()
    {
        Fill();
    }

    public void Search()
    {
        const string CommandShow = "show";
        const string CommandFilter = "filter";
        const string CommandExit = "exit";
        bool isExit = false;

        while (isExit == false)
        {
            Console.WriteLine("Для просмотра всех заключенных - " + CommandShow + ", для поиска вышедшего преступника по параметрам введите " + CommandFilter + ", для выхода из программы " + CommandExit);
            string userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case CommandShow:
                    ShowCriminals();
                    break;

                case CommandFilter:
                    Filter();
                    break;

                case CommandExit:
                    isExit = true;
                    break;
            }
        }
    }

    private void Filter()
    {
        Console.WriteLine("Для установки нужных фильтров введите рост, вес и национальность преступника");

        Console.Write("Рост: ");
        int height = GetNumber();
        Console.Write("Вес: ");
        int weight = GetNumber();
        Console.Write("Национальность: ");
        string nationality = Console.ReadLine();

        var filteredCriminal = from Criminal criminal in _criminals
                               where criminal.Height == height && criminal.Weight == weight &&
                               criminal.Nationality == nationality && criminal.IsArrested == false
                               select criminal;

        foreach (Criminal criminal in filteredCriminal)
        {
            Console.WriteLine(criminal.FullName + " " + criminal.Height + " " + criminal.Weight + " " + criminal.Nationality);
        }

        Console.ReadKey();
    }

    private void ShowCriminals()
    {
        foreach (var criminal in _criminals)
        {
            Console.WriteLine(criminal.FullName + " " + criminal.Height + " " + criminal.Weight + " " + criminal.Nationality);
        }
    }

    private void Fill()
    {
        _criminals.Add(new Criminal("Ержан Ержанович Ержанцев", false, 190, 80, "ержанец"));
        _criminals.Add(new Criminal("Баролд Венесов Бабкин", true, 170, 90, "мексиканец"));
        _criminals.Add(new Criminal("Евекан Пеликанов Балкон", false, 185, 80, "ержанец"));
        _criminals.Add(new Criminal("Жора Петрович Жрунов", false, 190, 90, "австралиец"));
        _criminals.Add(new Criminal("Тапок Тараканов Шлёпович", true, 185, 90, "бразилец"));
        _criminals.Add(new Criminal("Ботинок Скользящий Польду", false, 185, 90, "бразилец"));
        _criminals.Add(new Criminal("Маракас Играющий Днём", true, 170, 90, "мексиканец"));
        _criminals.Add(new Criminal("Медведь Водка Балалайка", false, 190, 85, "русский"));
        _criminals.Add(new Criminal("Брат Ержана Ержанцев", true, 180, 80, "ержанец"));
        _criminals.Add(new Criminal("Маркус Ествверх Ногами", true, 170, 85, "австралиец"));
    }

    private int GetNumber()
    {
        bool isParse = false;
        int numberForReturn = 0;

        while (isParse == false)
        {
            string userNumber = Console.ReadLine();
            int.TryParse(userNumber, out numberForReturn);

            if (numberForReturn <= 0)
            {
                Console.WriteLine("Это не игрушки, мы преступника ищем, вводи нормально");
            }
            else
            {
                isParse = true;
            }
        }

        return numberForReturn;
    }
}

class Criminal
{
    public Criminal(string fullName, bool isArrested, int height, int weight, string nationality)
    {
        FullName = fullName;
        IsArrested = isArrested;
        Height = height;
        Weight = weight;
        Nationality = nationality;
    }

    public string FullName { get; private set; }
    public bool IsArrested { get; private set; }
    public int Height { get; private set; }
    public int Weight { get; private set; }
    public string Nationality { get; private set; }
}
