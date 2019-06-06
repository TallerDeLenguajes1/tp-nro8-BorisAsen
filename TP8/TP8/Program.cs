using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
        ////Enum necesarios para simular empleados aleatorios
        public enum names { Juan, Maria, Pedro, Sofia, Agustina, Rafael };
        public enum surnames { Perez, Ramirez, Martinez, Rodriguez, Carrizo, Gonzalez };
        public enum maritalStatus { Casado, Soltero };
        public enum genders { Mujer, Hombre, Otro };
        public enum positions { Auxiliar, Admnistrativo, Ingeniero, Especialista, Investigador }
        class Program
        {
        const string FileName = "registros.csv";

        //MAIN
        static void Main(string[] args)
        {
            List<empleado> empleados = new List<empleado>();

            Console.Write("Empleados guardados previamente: ");
            EmployeesFromCsvToList(empleados);
            ShowEmployes(empleados);

            Console.WriteLine("\nPresione una tecla para generar nuevos empleados");
            Console.ReadKey();
            Console.Clear();

            Console.Write("Ingrese la cantidad de empleados a crear: ");
            int cant = Convert.ToInt16(Console.ReadLine());
            Console.Clear();
            BuildEmployesList(empleados, cant);

            Console.WriteLine("\nLista de empleados actualizada: ");
            ShowEmployes(empleados);

            Console.WriteLine("\nPresione una tecla para guardar la lista actualizada");
            Console.ReadKey();

            SaveEmployees(empleados,cant);
            Console.WriteLine("\nLos Empleados se guardaron con exito");

            BackUp(empleados);
            Console.WriteLine("\nEl BackUp se realizo correctamente");

            Console.ReadKey();
        }

        //Funcion para cargar empleados desde el csv
        public static List<empleado> EmployeesFromCsvToList(List<empleado> empleados)
        {
            string[] content = File.ReadAllLines(FileName);
            foreach (string line in content)
            {
                string[] delimitedContent = line.Split(';');
                string name = delimitedContent[0];
                string surname = delimitedContent[1];
                string maritalStatus = delimitedContent[2];
                string gender = delimitedContent[3];
                string position = delimitedContent[4];
                DateTime birthDate = Convert.ToDateTime(delimitedContent[5]);
                DateTime entryDate = Convert.ToDateTime(delimitedContent[6]);
                double pay = Convert.ToDouble(delimitedContent[7]);
                int childrens = rand.Next(10);

                empleado new_emp = new empleado(name, surname, maritalStatus, gender, position, birthDate, entryDate, pay, childrens);
                empleados.Add(new_emp);
            }

            return empleados;
        }

        //Funcion para guardar los empleados en el csv
        public static void SaveEmployees(List<empleado> empleados, int cant)
        {
            string new_line;
            StreamWriter CsvFile = File.AppendText(FileName);
            new_line = "";
            CsvFile.WriteLine(new_line);

            for (int i = empleados.Count()-cant; i < empleados.Count(); i++)
            {
                new_line = empleados[i].name + ";" + empleados[i].surname + ";" + empleados[i].maritalStatus + ";" + empleados[i].gender + ";" + empleados[i].position + ";" + empleados[i].birthDate.ToString("dd/MM/yyyy") + ";" + empleados[i].entryDate.ToString("dd/MM/yyyy") + ";" + empleados[i].pay.ToString();
                //Console.WriteLine(new_line);
                CsvFile.WriteLine(new_line);
            }

            //foreach (empleado e in empleados)
            //{
            //    new_line = e.name + ";" + e.surname + ";" + e.maritalStatus + ";"+ e.gender + ";" + e.position + ";" +  e.birthDate.ToString("dd/MM/yyyy") + ";" + e.entryDate.ToString("dd/MM/yyyy") + ";" +  e.pay.ToString();
            //    Console.WriteLine(new_line);
            //    CsvFile.WriteLine(new_line);
            //}
            CsvFile.Close();
        }


        public static empleado LoadEmploye()
        {
            string name = Enum.GetName(typeof(names), rand.Next(6)); //del 0 al 5
            string surname = Enum.GetName(typeof(surnames), rand.Next(6)); //del 0 al 5
            string mS = Enum.GetName(typeof(maritalStatus), rand.Next(2)); //del 0 al 1
            string gender = Enum.GetName(typeof(genders), rand.Next(3)); //del 0 al 2
            string position = Enum.GetName(typeof(positions), rand.Next(5)); //del 0 
            double pay = rand.Next(10, 50) * 1000; // de 10k a 50k

            DateTime BD_from = new DateTime(1939, 1, 1);
            DateTime BD_to = new DateTime(2001, 1, 1);
            DateTime birthDate = RandomDate(BD_from, BD_to);

            DateTime ED_from = birthDate.AddDays(365 * 18);
            DateTime ED_to = DateTime.Today;
            DateTime entryDate = RandomDate(ED_from, ED_to);
            int childrens = rand.Next(10);

            empleado new_emp = new empleado(name, surname, mS, gender, position, birthDate, entryDate, pay, childrens);

            return new_emp;
        }
        //Funcion para crear la lista de empleados
        public static List<empleado> BuildEmployesList(List<empleado> empleados, int cant)
        {
            empleado emp;
            for (int i = 0; i < cant; i++)
            {
                emp = NewEmploye();
                empleados.Add(emp);
            }

            return empleados;
        }

        //Funcion que crea un empleado con valores aleatorios
        static public Random rand = new Random();//Rand publico
        public static empleado NewEmploye()
        {
            string name = Enum.GetName(typeof(names), rand.Next(6)); //del 0 al 5
            string surname = Enum.GetName(typeof(surnames), rand.Next(6)); //del 0 al 5
            string mS = Enum.GetName(typeof(maritalStatus), rand.Next(2)); //del 0 al 1
            string gender = Enum.GetName(typeof(genders), rand.Next(3)); //del 0 al 2
            string position = Enum.GetName(typeof(positions), rand.Next(5)); //del 0 
            double pay = rand.Next(10, 50) * 1000; // de 10k a 50k

            DateTime BD_from = new DateTime(1939, 1, 1);
            DateTime BD_to = new DateTime(2001, 1, 1);
            DateTime birthDate = RandomDate(BD_from, BD_to);

            DateTime ED_from = birthDate.AddDays(365 * 18);
            DateTime ED_to = DateTime.Today;
            DateTime entryDate = RandomDate(ED_from, ED_to);
            int childrens = rand.Next(10);

            empleado new_emp = new empleado(name, surname, mS, gender, position, birthDate , entryDate, pay, childrens);

            return new_emp;
        }


        //Funcion para crear una fecha aleatoria
        public static DateTime RandomDate(DateTime from, DateTime to)
        {
            int Days_Until_Today = (to - from).Days;
            int Days_to_add = rand.Next(Days_Until_Today + 1);
            DateTime new_date = from.AddDays(Days_to_add);

            return new_date;
        }

        //Funcion para mostrar la lista de empleados
        public static void ShowEmployes(List<empleado> empleados)
        {
            foreach (empleado e in empleados)
            {
                e.ShowEmployee();
            }
        }

        public static string SelectBackUpPath()
        {
            int i = 1;
            string[] availableDisks = Environment.GetLogicalDrives();
            Console.WriteLine();
            foreach (string drive in availableDisks)
            {
                Console.WriteLine("   "+i+") "+drive);
                i++;
            }

            Console.Write("\nIngrese el numero correspondiente al disco elegido: ");
            int nro = Convert.ToInt16(Console.ReadLine());
            string selectedDirectory = @availableDisks[nro-1];
            Console.WriteLine("\nOpcion seleccionada: " + selectedDirectory);

            return selectedDirectory;
        }

        public static void BackUp(List<empleado> empleados)
        {
            Console.WriteLine("\nSe enlistaran los discos disponibles con el fin de realizar un BackUp de los empleados de la empresa");

            string BackUpPath = SelectBackUpPath() + "\\BackUpAgenda";

            Console.WriteLine("\nRuta elegida: " + BackUpPath);

            string fileNumber = "";
            if (Directory.Exists(BackUpPath))
            {
                string[] availableFiles = Directory.GetFiles(BackUpPath);
                fileNumber = Convert.ToString(availableFiles.Length);
            }

            if (!File.Exists(BackUpPath))
            {
                Directory.CreateDirectory(BackUpPath);
            }

            string backUpContent;
            if (fileNumber == "")
            {
                BackUpPath = BackUpPath + "\\backup.bk";
            }
            else
            {
                BackUpPath = BackUpPath + "\\backup(" + fileNumber + ").bk";
            }

            FileStream fs = File.Create(BackUpPath);
            using (StreamWriter bk = new StreamWriter(fs))
            {
                backUpContent = BackUpString(empleados);
                bk.WriteLine(backUpContent);
                //Console.Write(backUpContent);
                bk.Close();
            }
        }

        public static string BackUpString(List<empleado> empleados)
        {
            string text = "";
            foreach (empleado e in empleados)
            {
                text = text+ e.name + ";" + e.surname + ";" + e.maritalStatus + ";" + e.gender + ";" + e.position + ";" + e.birthDate.ToString("dd/MM/yyyy") + ";" + e.entryDate.ToString("dd/MM/yyyy") + ";" + e.pay.ToString() +"\n";
            }

            return text;
        }

    }
}
