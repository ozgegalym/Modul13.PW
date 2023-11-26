using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 5, 10, 3, 8, 15, 7, 20 };

        
        FindAndPrintSecondMax(numbers);

    
        numbers.RemoveAll(n => n % 2 != 0);

        Console.WriteLine("List after removing odd elements:");
        foreach (var number in numbers)
        {
            Console.Write(number + " ");
        }
    }

    static void FindAndPrintSecondMax(List<int> numbers)
    {
        if (numbers.Count < 2)
        {
            Console.WriteLine("Not enough elements in the list.");
            return;
        }

        
        numbers.Sort((a, b) => b.CompareTo(a));

        
        Console.WriteLine($"Second maximum value is at position 1 with value {numbers[1]}");
    }
}

//zadacha 2
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<double> doubles = new List<double> { 1.5, 2.5, 3.5, 4.5, 5.5 };

        // Вывод элементов, значение которых больше среднего арифметического
        PrintElementsAboveAverage(doubles);
    }

    static void PrintElementsAboveAverage(List<double> doubles)
    {
        if (doubles.Count == 0)
        {
            Console.WriteLine("The list is empty.");
            return;
        }

        double average = doubles.Average();

        // Фильтрация и вывод элементов
        var aboveAverage = doubles.Where(d => d > average);
        Console.WriteLine("Elements above average:");
        foreach (var element in aboveAverage)
        {
            Console.Write(element + " ");
        }
    }
}

//zadacha 3
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Пути к файлам
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        // Чтение чисел из файла
        string[] lines = File.ReadAllLines(inputFile);
        int[] numbers = lines.Select(int.Parse).ToArray();

        // Перепись чисел в обратном порядке
        Array.Reverse(numbers);

        // Запись чисел в новый файл
        File.WriteAllLines(outputFile, numbers.Select(n => n.ToString()));

        Console.WriteLine("Numbers have been reversed and written to the output file.");
    }
}

//zadacha 4
using System;
using System.Collections.Generic;
using System.IO;

class Employee
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Gender { get; set; }
    public int Age { get; set; }
    public double Salary { get; set; }
}
class Program
{
    static void Main()
    {
        string filePath = "employees.txt";
        List<Employee> employees = ReadEmployeesFromFile(filePath);

        // Группировка сотрудников
        var below10000 = employees.Where(e => e.Salary < 10000);
        var aboveOrEqual10000 = employees.Where(e => e.Salary >= 10000);

        // Вывод в нужном порядке
        Console.WriteLine("Employees with salary below 10000:");
        PrintEmployees(below10000);

        Console.WriteLine("\nEmployees with salary 10000 and above:");
        PrintEmployees(aboveOrEqual10000);
    }

    static List<Employee> ReadEmployeesFromFile(string filePath)
    {
        List<Employee> employees = new List<Employee>();
        string[] lines = File.ReadAllLines(filePath);

        foreach (var line in lines)
        {
            string[] data = line.Split(',');
            employees.Add(new Employee
            {
                LastName = data[0],
                FirstName = data[1],
                MiddleName = data[2],
                Gender = data[3],
                Age = int.Parse(data[4]),
                Salary = double.Parse(data[5])
            });
        }

        return employees;
    }

    static void PrintEmployees(IEnumerable<Employee> employees)
    {
        foreach (var employee in employees)
        {
            Console.WriteLine($"{employee.LastName}, {employee.FirstName}, {employee.MiddleName}, " +
                $"{employee.Gender}, {employee.Age}, {employee.Salary}");
        }
    }
}

//zadacha 5
using System;
using System.Collections.Generic;

class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
}

class CD
{
    public string Title { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();
}

class MusicCatalog
{
    Dictionary<string, CD> catalog = new Dictionary<string, CD>();

    public void AddCD(string title)
    {
        catalog.Add(title, new CD { Title = title });
    }

    public void RemoveCD(string title)
    {
        catalog.Remove(title);
    }

    public void AddSong(string cdTitle, string songTitle, string artist)
    {
        if (catalog.TryGetValue(cdTitle, out var cd))
        {
            cd.Songs.Add(new Song { Title = songTitle, Artist = artist });
        }
        else
        {
            Console.WriteLine($"CD '{cdTitle}' not found.");
        }
    }

    public void RemoveSong(string cdTitle, string songTitle)
    {
        if (catalog.TryGetValue(cdTitle, out var cd))
        {
            var songToRemove = cd.Songs.Find(song => song.Title == songTitle);
            if (songToRemove != null)
            {
                cd.Songs.Remove(songToRemove);
            }
            else
            {
                Console.WriteLine($"Song '{songTitle}' not found in CD '{cdTitle}'.");
            }
        }
        else
        {
            Console.WriteLine($"CD '{cdTitle}' not found.");
        }
    }

    public void ViewCatalog()
    {
        foreach (var cd in catalog.Values)
        {
            Console.WriteLine($"CD: {cd.Title}");
            foreach (var song in cd.Songs)
            {
                Console.WriteLine($"  Song: {song.Title} - {song.Artist}");
            }
        }
    }

    public void SearchByArtist(string artist)
    {
        foreach (var cd in catalog.Values)
        {
            foreach (var song in cd.Songs)
            {
                if (song.Artist == artist)
                {
                    Console.WriteLine($"CD: {cd.Title}, Song: {song.Title}");
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        MusicCatalog catalog = new MusicCatalog();

        catalog.AddCD("CD1");
        catalog.AddSong("CD1", "Song1", "Artist1");
        catalog.AddSong("CD1", "Song2", "Artist2");

        catalog.AddCD("CD2");
        catalog.AddSong("CD2", "Song3", "Artist1");
        catalog.AddSong("CD2", "Song4", "Artist3");

        catalog.ViewCatalog();

        Console.WriteLine("\nSearching for songs by 'Artist1':");
        catalog.SearchByArtist("Artist1");
    }
}

