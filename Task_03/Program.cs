using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создайте пользовательский атрибут AccessLevelAttribute, позволяющий определить уровень доступа пользователя к системе. 
             * Сформируйте состав сотрудников некоторой фирмы в виде набора классов, например, Manager, Programmer, Director. 
             * При помощи атрибута AccessLevelAttribute распределите уровни доступа персонала 
             * и отобразите на экране реакцию системы на попытку каждого сотрудника получить доступ в защищенную секцию.
             */

            object[] attributes;

            Manager manager = new Manager("John");
            manager.Show();
            Type typeManager = typeof(Manager);
            attributes = typeManager.GetCustomAttributes(false);

            CheckAccessLevel(attributes);

            Programmer programmer = new Programmer("Micky");
            programmer.Show();
            Type typeProgrammer = typeof(Programmer);
            attributes = typeProgrammer.GetCustomAttributes(false);

            CheckAccessLevel(attributes);

            Director director = new Director("J.K.");
            director.Show();
            Type typeDirector = typeof(Director);
            attributes = typeDirector.GetCustomAttributes(false);

            CheckAccessLevel(attributes);

            Console.ReadKey();
        }

        private static void CheckAccessLevel(object[] attributes)
        {
            foreach (AccessLevelAttribute attribute in attributes)
            {
                if (attribute.Level < 3)
                    Console.WriteLine("Уровень доступа недостаточный.");
                else
                    Console.WriteLine("Доступ разрешен.");
            }
        }

    }
    [AccessLevel(Level = 1)]
    class Manager
    {
        string name;
        public Manager(string name)
        {
            this.name = name;
        }

        internal void Show()
        {
            Console.WriteLine($"Менеджер {name}");
        }
    }
    [AccessLevel(Level = 2)]
    class Programmer
    {
        string name;
        public Programmer(string name)
        {
            this.name = name;
        }
        internal void Show()
        {
            Console.WriteLine($"Программист {name}");
        }

    }
    [AccessLevel(Level = 3)]
    class Director
    {
        string name;
        public Director(string name)
        {
            this.name = name;
        }
        internal void Show()
        {
            Console.WriteLine($"Директор {name}");
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class AccessLevelAttribute : System.Attribute
    {
        public int Level { get; set; }
    }
}



