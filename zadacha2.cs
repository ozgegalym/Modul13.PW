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
