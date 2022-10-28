using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        /*
         * Расширьте возможности программы-рефлектора из предыдущего урока следующим образом: 
         * 1. Добавьте возможность выбирать, какие именно члены типа должны быть показаны пользователю. 
         * При этом должна быть возможность выбирать сразу несколько членов типа, например, методы и свойства. 
         * 2. Добавьте возможность вывода информации об атрибутах для типов и всех членов типа, которые могут быть декорированы атрибутами. 
         */

        Assembly assembly = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Строка приема полного имени загружаемой сборки.
                string path = openFileDialog.FileName;

                try
                {
                    assembly = Assembly.LoadFile(path);

                    textBox.Text += "СБОРКА    " + path + "  -  УСПЕШНО ЗАГРУЖЕНА" + Environment.NewLine + Environment.NewLine;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                // Вывод информации о всех типах в сборке.
                textBox.Text += "СПИСОК ВСЕХ ТИПОВ В СБОРКЕ:     " + assembly.FullName + Environment.NewLine + Environment.NewLine;

                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    textBox.Text += "Тип:  " + type + Environment.NewLine;
                    var methods = type.GetMethods();
                    if (methods != null)
                    {
                        foreach (var method in methods)
                        {
                            string methStr = "Метод:" + method.Name + "\n";
                            var methodBody = method.GetMethodBody();
                            if (methodBody != null)
                            {
                                var byteArray = methodBody.GetILAsByteArray();

                                foreach (var b in byteArray)
                                {
                                    methStr += b + ":";
                                }
                            }
                            textBox.Text += methStr + Environment.NewLine;
                        }
                    }
                    var attributes = type.GetCustomAttributes(false);
                    if (attributes != null)
                    {
                        foreach (Attribute attribute in attributes)
                        {
                            string methStr = "Аттрибуты:" + attribute.TypeId.ToString() + "\n";
                            textBox.Text += methStr + Environment.NewLine;
                        }
                    }
                }

            }
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}