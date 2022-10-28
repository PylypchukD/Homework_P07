using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * Создайте класс и примените к его методам атрибут Obsolete сначала в форме, просто выводящей предупреждение, 
             * а затем в форме, препятствующей компиляции. Продемонстрируйте работу атрибута на примере вызова данных методов.
             */

            MyClass myClass = new MyClass();
            myClass.MyNewMethod();
            myClass.MyOldMethod(); // Подстветка и intellisense выводит подсказку о не использованию метода.

        }
    }

    public class MyClass
    {
        public void MyNewMethod()
        {
            Console.WriteLine("Реализация старого метода.");
        }

        [Obsolete("Это старый метод, используйте MyNewMethod")]
        public void MyOldMethod()
        {
            Console.WriteLine("Реализация старого метода.");
        }
    }
}
