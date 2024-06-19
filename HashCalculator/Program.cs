using System;
using System.IO;
using System.Security.Cryptography;

class HashCalculator
{
    static void Main(string[] args)
    {
        // Проверяем, был ли предоставлен путь к файлу
        if (args.Length != 1)
        {
            Console.WriteLine("Usage: HashCalculator <file path>");
            return;
        }

        try
        {
            // Записываем путь файла из аргументов командной строки
            string filePath = args[0];

            // Открываем файловый поток для чтения
            using (FileStream stream = File.OpenRead(filePath))
            {
                // Используем SHA1 алгоритм
                using (SHA1 sha1 = SHA1.Create())
                {
                    // Вычисляем хэш из потока данных файла
                    byte[] hash = sha1.ComputeHash(stream);

                    // Переводим байты хэша в строку шестнадцатеричных значений и выводим на экран
                    Console.WriteLine(BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant());
                }
            }
        }
        catch (IOException e)
        {
            // В случае возникновения ошибки при чтении файла выводим сообщение
            Console.WriteLine("Error reading the file: " + e.Message);
        }
    }
}


// Данный код вводиться в PowerShell для вычисления хеш-суммы данного файла
//C:\Users\axm\Documents\practic1\HashCalculator\HashCalculator\bin\Debug\net6.0\HashCalculator.exe "C:\Users\axm\Pictures\axm person\opium_person.png"

