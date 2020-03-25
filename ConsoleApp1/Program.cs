using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте, дорого пользователь");
            Console.WriteLine("Чтобы создать новый аккаунт, нажмите 1, чтобы авторизоваться, нажмите 2");
            byte action = byte.Parse(Console.ReadLine());
            if (action==1)
            {
                Console.Clear();
                Console.WriteLine("Введите имя: ");
                string file_name = Console.ReadLine();
                File.Create("D:\\Практические работы\\с#\\" + file_name+".txt");
                Console.WriteLine("Пароль: ");
                string user_password = Console.ReadLine();
                FileStream file_str = new FileStream("D:\\" + file_name + ".txt",FileMode.Create);
                StreamWriter file_writer = new StreamWriter(file_str);
                file_writer.WriteLine(user_password);
                file_writer.Close();
                Console.WriteLine("Регистрация успешно пройдена!");
                action++;
            }
            if (action==2)
            {
                Console.Clear();
                Console.WriteLine("Введите имя: ");
                string file_name = Console.ReadLine();
                FileStream file_str2 = new FileStream("D:\\" + file_name + ".txt", FileMode.Open);
                StreamReader file_reader = new StreamReader(file_str2);
                string check = file_reader.ReadLine();
                file_reader.Close();
                Console.WriteLine("Введите пароль:");
                string password = Console.ReadLine();
                if (check == password)
                {
                    Console.WriteLine("Авторизация прошла успешно!");
                }
                else Console.WriteLine("Ошибка!");
            }
            Console.ReadKey();
        }
    }
}
