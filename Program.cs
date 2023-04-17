using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Practicheskaya_4
{
    internal class Program
    {
        string path = Directory.GetCurrentDirectory();
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            Console.WriteLine("Задание 1: \n");

            List<int> number = new List<int>();

            Console.WriteLine("100 случайных чисел от 1 до 100:\n");
            number = FillList(100, number);
            ShowList(number);

            Console.WriteLine("\n\nЧисла больше 25 и меньше 50:\n");
            number = DeleteList(number);
            ShowList(number);

            Console.ReadKey();

            Console.WriteLine("\n\nЗадание 2: \n");

            Dictionary<string, string> list = new Dictionary<string, string>();

            list = AddList(list);

            CheckPhone(list);

            Console.WriteLine("\nЗадание 3: \n");

            HashSet<int> hashSetList = new HashSet<int>();
            bool check = true;

            while (check)
            {
                Console.WriteLine("\nВведите число в коллекцию HashSet(введите пустую строку чтобы закончить вводить числа)");
                string checkHash = Console.ReadLine();
                int hash;

                try { hash = int.Parse(checkHash); }
                catch { break; }

                if (checkHash == "")
                    break;

                if (!hashSetList.Contains(hash))
                {
                    hashSetList.Add(hash);
                    Console.WriteLine("\nЧисло добавлено\n");
                }
                else
                    Console.WriteLine("\nТакое число уже есть\n");
            }

            Console.WriteLine("\nЗадание 4: \n");

            Console.WriteLine("Введите ФИО");
            string fio = Console.ReadLine();
            Console.WriteLine("Введите Улицу");
            string street = Console.ReadLine();
            Console.WriteLine("Введите номер дома");
            int houseNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите номер квартиры");
            int apartmentNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите мобильный телефон");
            string phone = Console.ReadLine();
            Console.WriteLine("Введите домашний телефон");
            string homePhone = Console.ReadLine();

            XDocument xdoc = new XDocument();

            XElement _fio = new XElement("Person");
            XAttribute _fioAttr = new XAttribute("name", fio);

            XElement Address = new XElement("Address");
            XElement streetEllem = new XElement("Street", street);
            XElement houseNumberEllem = new XElement("HouseNumber", houseNumber);
            XElement flatNumberEllem = new XElement("FlatNumber", apartmentNumber);

            XElement phones = new XElement("Phones");
            XElement mobileElem = new XElement("MobilePhone", phone);
            XElement flatPhoneElem = new XElement("FlatPhone", homePhone);

            xdoc.Add(_fio);
            _fio.Add(_fioAttr);

            _fio.Add(Address);
            Address.Add(streetEllem);
            Address.Add(houseNumberEllem);
            Address.Add(flatNumberEllem);

            _fio.Add(phones);
            phones.Add(mobileElem);
            phones.Add(flatPhoneElem);

            xdoc.Save($@"{path}\задание4.xml");

            Console.WriteLine($@"Файл xml сохранён по пути {path}\задание4.xml");

            Console.ReadKey();
        }

        static public List<int> FillList(int a, List<int> number)
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
                number.Add(rnd.Next(0, 101));
            return number;
        }
        static public List<int> DeleteList(List<int> number)
        {
            for (int i = 0; i < number.Count; i++)
            {
                if (number[i] > 25 || number[i] < 50)
                    number.Remove(i);
            }
            return number;
        }
        static public void ShowList(List<int> number)
        {
            for (int i = 0; i < number.Count; i++)
                Console.Write($"{number[i]} ");
        }

        static public Dictionary<string, string> AddList(Dictionary<string, string> list)
        {
            bool check = true;

            while (check)
            {
                Console.WriteLine("\nВведите номер телефона(введите пустую строку чтобы закончить вводить данные)");
                string phone = Console.ReadLine();

                if (phone == "")
                    break;

                Console.WriteLine("\nВведите ФИО владельца телефона");
                string fio = Console.ReadLine();
                
                list.Add(phone, fio);
            }
            return list;
        }
        
        static public void CheckPhone(Dictionary<string, string> list)
        {
            string findFio = "";
            bool check = true;

            while(check)
            {
                Console.WriteLine("\nВведите номер телефона чтобы найти владельца(введите пустую строку чтобы закончить искать владельца)");
                string checkPhone = Console.ReadLine();

                if (checkPhone == "")
                    break;

                if (list.TryGetValue(checkPhone, out findFio))
                    Console.WriteLine($"\nУ телефона {checkPhone} владелец {findFio}");
                else
                    Console.WriteLine("Такого телефона нет");
            }
        }
    }
}
