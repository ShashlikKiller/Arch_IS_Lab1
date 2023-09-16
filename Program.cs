using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using static Arch_IS_Lab1.InfoManipulation;

namespace Arch_IS_Lab1
{
    class Program
// Данные в файле должны соответствовать следующим требованиям:
//    несколько текстовых полей; +
//    одно(несколько) числовое поле; +
//    одно(несколько) логическое поле. +
// Примеры определяются согласно варианту, указанному преподавателем.
// Разработанное приложение должно обеспечивать следующие возможности:
//    Вывод всех записей на экран +
//    Вывод записи по номеру +
//    Запись данных в файл +
//    Удаление записи (записей) из файла +
//    Добавление записи в файл +
// Интерфейс приложения должен быть выполнен в текстовом виде.
// Выбор возможных операций с файлом организуется при помощи меню.Выход из
// приложения осуществляется пользователем по клавише Esc. 
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                ShouldUseConstructorParameters = type => false // Передача библиотеке разрешение на
                                                               // присваивание полей без конструктора
            };
            string path; // переменная пути до csv файла
            try
            {
                path = Environment.CurrentDirectory + "\\file.csv"; // Создание пути для .csv файла
            }
            catch
            {
                Console.WriteLine(" Файл по данному адресу отсутствует. Введите прямой адрес:");
                path = Console.ReadLine();
            }
            List<Student> Students;
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                IEnumerable<Student> Records = csv.GetRecords<Student>(); // Базовый интерфейс для всех
                                                                          // неуниверсальных коллекций
                Students = Records.ToList();
            }
            bool activeapp = true; // Это можно убрать, оставив в while просто true.
            while (activeapp)
            {
                    MenuCall(Students, path);
            }
        }

        public static void SaveRecords(List<Student> Students, string pathtofile)
        {
            using (var swriter = new StreamWriter(pathtofile))
            using (var csvwriter = new CsvWriter(swriter, CultureInfo.InvariantCulture))
            {
                csvwriter.WriteRecords(Students);
            }
            Console.WriteLine("\n Данные успешно сохранены. \n");
        }

        public static void MenuCall(List<Student> Students, string path)
        {
            MenuText();
            switch(Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1: // Вывод всех записей на экран
                    Console.WriteLine("\n Список студентов:\n");
                    ConsoleOutputAll(Students);
                    break;
                case ConsoleKey.D2: // Вывод записи по номеру
                    OutputByID(Students);
                    break;
                case ConsoleKey.D3: // Запись данных в файл
                    SaveRecords(Students, path);
                    break;
                case ConsoleKey.D4: // Удалить запись по индексу
                    DeleteRecord(Students);
                    break;
                case ConsoleKey.D5: // Добавление новой записи
                    AddNewRecord(Students);
                    break;
                case ConsoleKey.Escape: // Закрытие приложения
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(" Нажмите конкретную кнопку от 1 до 5 или Esc для выхода из приложения.");
                    break;
            }
        }
    }
}