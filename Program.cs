namespace Module14.Task;

class Program
{
    static void Main(string[] args)
    {
        var phoneBook = new List<Contact>();

        phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
        phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
        phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
        phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
        phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
        phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

        var sortedContacts = phoneBook
            .OrderBy(sc => sc.Name)
            .ThenBy(sc => sc.LastName);

        Console.WriteLine("Для вывода на экран введите номер страницы телефонной книги 1, 2 или 3");

        while (true)
        {
            var keyChar = Console.ReadKey().KeyChar;
            Console.Clear();

            if (!Char.IsDigit(keyChar))
            {
                Console.WriteLine("Ошибка ввода, введите 1, 2 или 3");
            }
            else
            {
                IEnumerable<Contact> page = null;

                switch (keyChar)
                {
                    case ('1'):
                        page = sortedContacts.Take(2);
                        break;
                    case ('2'):
                        page = sortedContacts.Skip(2).Take(2);
                        break;
                    case ('3'):
                        page = sortedContacts.Skip(4).Take(2);
                        break;
                }

                if (page == null)
                {
                    Console.WriteLine($"Ошибка ввода, страницы {keyChar} не существует, введите 1, 2 или 3");
                    continue;
                }

                foreach (var contact in page)
                    Console.WriteLine(contact.Name + " " + contact.LastName + " " + contact.PhoneNumber + " " + contact.Email);
            }
        }
    }
}

public class Contact
{
    public Contact(string name, string lastName, long phoneNumber, String email)
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

