using System;
using System.Linq;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Runtime.InteropServices;
using Module14.Task;

namespace Module14.Task;

class Program
{
    static void Main(string[] args)
    {
        //  создаём пустой список с типом данных Contact
        var phoneBook = new List<Contact>();

        // добавляем контакты
        phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
        phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

        // бесконечный цикл, ожидающий ввод с консоли
        while (true)
        {
            var keyChar = Console.ReadKey().KeyChar; // получаем символ с консоли
            Console.Clear();  //  очистка консоли от ввода


            if (!Char.IsDigit(keyChar))
            {
                Console.WriteLine("Ошибка ввода, введите число");
            }
            else
            {
                //  переменная для хранения запроса в зависимости от введенного с консоли числа
                IEnumerable<Contact> page = null;

                //  выбираем нужное кол-во элементов для создания постраничного ввода в зависимости от запроса
                switch (keyChar)
                {
                    case ('1'):
                        page = phoneBook.Take(2);
                        break;
                    case ('2'):
                        page = phoneBook.Skip(2).Take(2);
                        break;
                    case ('3'):
                        page = phoneBook.Skip(4).Take(2);
                        break;
                }

                //   проверим, что ввели существующий номер страницы
                if (page == null)
                {
                    Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует");
                    continue;
                }

                // вывод результата на консоль
                foreach (var contact in page)
                    Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber + " " + contact.Email);
            }
        }
    }
}
public class Contact // модель класса
{
    public Contact(string name, string lastName, long phoneNumber, String email) // метод-конструктор
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Email = email;
    }

    public String Name { get; }
    public String LastName { get; }
    public long PhoneNumber { get; }
    public String Email { get; }
}

