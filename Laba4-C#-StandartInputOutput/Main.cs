using System;
using System.Xml.XPath;
using System.Linq;
using System.Collections.Generic;

class Program
{

    static void Main()
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        while (true)
        {
            Console.WriteLine("\nРЕДАКТОР");
            Console.WriteLine("1. Текстовый редактор");
            Console.WriteLine("2. Поиск файлов");
            Console.WriteLine("3. Индексация файлов");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunEditor();
                    break;
                case "2":
                    RunSearch();
                    break;
                case "3":
                    RunIndexing();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный пункт меню.");
                    break;
            }
        }
    }

    static void RunEditor()
    {
        TextEditor editor = new TextEditor();
        History history = new History();

        while (true)
        {
            Console.WriteLine("\nТЕКСТОВЫЙ РЕДАКТОР");
            Console.WriteLine("1. Изменить текст");
            Console.WriteLine("2. Показать текст");
            Console.WriteLine("3. Отменить изменение");
            Console.WriteLine("4. Выход");

            Console.WriteLine("\nВыберите пункт: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    history.Push(editor.Save());
                    Console.WriteLine("Введите новый текст: ");
                    editor.Content = Console.ReadLine();
                    Console.WriteLine("Текст изменен.");
                    break;
                case "2":
                    Console.WriteLine($"Текст: {editor.Content}");
                    break;
                case "3":
                    var memento = history.Undo();
                    if (memento != null)
                    {
                        editor.Restore(memento);
                        Console.WriteLine("Изменение отменено.");
                    }
                    else
                    {
                        Console.WriteLine("История пуста.");
                    }
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Неверный пункт меню.");
                    break;

            }
        }
    }


    static void RunSearch()
    {
        FileSearcher searcher = new FileSearcher();
        Console.Write("Введите путь к папке: ");
        string directory = Console.ReadLine();
        Console.Write("Введите ключевое слово: ");
        string keyword = Console.ReadLine();

        var files = searcher.Search(directory, keyword);
        Console.WriteLine("Найденные файлы: ");

        foreach (var file in files)
        {
            Console.WriteLine(file);
        }
    }


    static void RunIndexing()
    {
        FileIndexer indexer = new FileIndexer();
        Console.Write("Введите путь к папке: ");

        string directory = Console.ReadLine();

        Console.WriteLine("Введите ключевые слова через запятую: ");

        string input = Console.ReadLine();

        List<string> keywords = input.Split(',')
            .Select(x => x.Trim())
            .ToList();

        var index = indexer.BuildIndex(directory, keywords);

        foreach (var pair in index)
        {
            Console.WriteLine($"Ключевое слово: {pair.Key}");

            foreach (var file in pair.Value) Console.WriteLine(file);
        }
    }
}