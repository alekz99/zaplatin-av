using System;
using System.IO;

namespace Software_app
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        /// <param name="args"> Список аргументов командной строки.</param>
        /// <example>
        /// Содержимое файла input.txt
        /// 5
        /// FreeSoft|Cisco Packet Tracer|Cisco
        /// Shareware|Visual Studio IDE|Microsoft|01.02.2020|31
        /// CommercialSoft|Photoshop CS6|Adobe|13,99|15.06.2018|365
        /// CommercialSoft|WinRAE|	RARLAB|7,00|15.06.2019|365
        /// Shareware|UltraISO|EZB Systems, Inc.|01.02.2020|14</example>
        static void Main(string[] args)
        {
            string data;

            StreamReader sr = new StreamReader("input.txt");

            int count = Convert.ToInt32(sr.ReadLine());

            Software[] array = new Software[count];

            for (int i = 0; i < count; i++)
            {
                data = sr.ReadLine();
                string[] attrib = data.Split(new char[] { '|' });
                switch (attrib[0])
                {
                    case "FreeSoft":
                        array[i] = new FreeSoft(attrib[1], attrib[2]);
                        break;
                    case "Shareware":
                        array[i] = new Shareware(attrib[1], attrib[2], DateTime.Parse(attrib[3]), Convert.ToInt32(attrib[4]));
                        break;
                    case "CommercialSoft":
                        array[i] = new CommercialSoft(attrib[1], attrib[2], Convert.ToDouble(attrib[3]),
                            DateTime.Parse(attrib[4]), Convert.ToInt32(attrib[5]));
                        break;
                    default:
                        break;
                }
            }

            foreach (Software sw in array)
            {
                sw.GetInformation();
                Console.WriteLine();
            }

            Console.WriteLine("Software that is valid for current date:\n");
            foreach (Software sw in array)
            {
                if (sw.ReadyWork())
                {
                    Console.WriteLine(sw.WriteFullName());
                }
            }
        }
    }
}
