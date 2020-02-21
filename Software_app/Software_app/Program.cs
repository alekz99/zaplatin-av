using System;
using System.IO;
using System.Diagnostics;
using System.Xml.Serialization;

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

            Trace.WriteLine("An array of software has been created.");
            Trace.Indent();
            Trace.WriteLineIf(array.Length == count, "The number of elements in the " +
                "array is equal to the specified value: " + count.ToString());
            Trace.Unindent();

            Trace.WriteLine("Filling Array");
            Trace.Indent();
            for (int i = 0; i < count; i++)
            {
                data = sr.ReadLine();
                string[] attrib = data.Split(new char[] { '|' });
                switch (attrib[0])
                {
                    case "FreeSoft":
                        array[i] = new FreeSoft(attrib[1], attrib[2]);
                        Trace.WriteLine("Creating a Class Object FreeSoft: " + array[i].WriteFullName());
                        break;
                    case "Shareware":
                        array[i] = new Shareware(attrib[1], attrib[2], DateTime.Parse(attrib[3]), Convert.ToInt32(attrib[4]));
                        Trace.WriteLine("Creating a Class Object Shareware:" + array[i].WriteFullName());
                        break;
                    case "CommercialSoft":
                        array[i] = new CommercialSoft(attrib[1], attrib[2], Convert.ToDouble(attrib[3]),
                            DateTime.Parse(attrib[4]), Convert.ToInt32(attrib[5]));
                        Trace.WriteLine("Creating a Class Object CommercialSoft:" + array[i].WriteFullName());
                        break;
                    default:
                        break;
                }
            }
            Trace.Unindent();

            GenerateXML(array);

            Trace.WriteLine("Display all software.");
            Trace.Indent();
            foreach (Software sw in array)
            {
                try { 
                    sw.GetInformation();
                    Trace.WriteLine("Function GetInformation completed.");
                }
                catch (Exception) { Trace.Fail("Error in function GetInformation.");};
                Console.WriteLine();
            }
            Trace.Unindent();

            Trace.WriteLine("Displays available for use software.");
            Trace.Indent();
            Console.WriteLine("Software that is valid for current date:\n");
            foreach (Software sw in array)
            {
                try
                {
                    if (sw.ReadyWork())
                    {
                        Console.WriteLine(sw.WriteFullName());
                    }
                    Trace.WriteLine("Function ReadyWork completed.");
                }
                catch (Exception)
                {
                    Trace.Fail("Error in function GetInformation.");
                }
            }
            Trace.Unindent();
            Trace.Flush();
        }

        public static void GenerateXML (Software[] array)
        {
            XmlSerializer serializerFreeSoft = new XmlSerializer(typeof(FreeSoft));
            XmlSerializer serializerShareware = new XmlSerializer(typeof(Shareware));
            XmlSerializer serializerCommercialSoft = new XmlSerializer(typeof(CommercialSoft));
            TextWriter writer = new StreamWriter("xml_output.txt");

            foreach (Software sw in array)
            {
                try
                {
                    serializerFreeSoft.Serialize(writer, sw);
                }
                catch (Exception) { };
                try
                {
                    serializerShareware.Serialize(writer, sw);
                }
                catch (Exception) { };
                try
                {
                    serializerCommercialSoft.Serialize(writer, sw);
                }
                catch (Exception) { };
            }

            writer.Close();
        }
    }
}
