using System;

class Program
{
    static void Main()
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
                    if(memento != null)
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

            }
        }
    }
}