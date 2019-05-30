using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class Program
    {
        //MAIN
        static void Main(string[] args)
        {
            List<empleado> empleados = new List<empleado>();
            Console.Write("Ingrese la cantidad de empleados a crear: ");
            int cant = Convert.ToInt16(Console.ReadLine());
            BuildEmployesList(empleados, cant);
            Console.Clear();

            Console.WriteLine("\nEmpleados de la Empresa: ");
            ShowEmployes(empleados);


            Console.ReadKey();
        }

        ////Enum necesarios para simular empleados aleatorios
        public enum names { Juan, Maria, Pedro, Sofia, Agustina, Rafael };
        public enum surnames { Perez, Ramirez, Martinez, Rodriguez, Carrizo, Gonzalez };
        public enum maritalStatus { Casado, Soltero };
        public enum genders { Mujer, Hombre, Otro };
        public enum positions { Auxiliar, Admnistrativo, Ingeniero, Especialista, Investigador }


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

            empleado new_emp = new empleado(name, surname, mS, gender, position, birthDate , entryDate, pay);

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

        ////Estructura Empleado
        //public struct empleado
        //{
        //    public string name;
        //    public string surname;
        //    public string maritalStatus;
        //    public string gender;
        //    public string position;
        //    public DateTime birthdDate;
        //    public DateTime entryDate;
        //    public double pay;
        //}

        ////Funcion para crear la lista de empleados
        //public static List<empleado> BuildEmployesList(List<empleado> empleados, int cant)
        //{
        //    empleado emp;
        //    for (int i = 0; i < cant; i++)
        //    {
        //        emp = NewEmploye();
        //        empleados.Add(emp);
        //    }

        //    return empleados;
        //}

        ////Funcion que crea un empleado con valores aleatorios
        //static public Random rand = new Random();//Rand publico
        //public static empleado NewEmploye()
        //{
        //    empleado new_emp;
        //    new_emp.name = Enum.GetName(typeof(names), rand.Next(6)); //del 0 al 5
        //    new_emp.surname = Enum.GetName(typeof(surnames), rand.Next(6)); //del 0 al 5
        //    new_emp.maritalStatus = Enum.GetName(typeof(maritalStatus), rand.Next(2)); //del 0 al 1
        //    new_emp.gender = Enum.GetName(typeof(genders), rand.Next(3)); //del 0 al 2
        //    new_emp.position = Enum.GetName(typeof(positions), rand.Next(5)); //del 0 
        //    new_emp.pay = rand.Next(10, 50) * 1000; // de 10k a 50k

        //    DateTime BD_from = new DateTime(1939, 1, 1);
        //    DateTime BD_to = new DateTime(2001, 1, 1);
        //    new_emp.birthdDate = RandomDate(BD_from, BD_to);

        //    DateTime ED_from = new_emp.birthdDate.AddDays(365 * 18);
        //    DateTime ED_to = DateTime.Today;
        //    new_emp.entryDate = RandomDate(ED_from, ED_to);

        //    return new_emp;
        //}


        ////Funcion para crear una fecha aleatoria
        //public static DateTime RandomDate(DateTime from, DateTime to)
        //{
        //    int Days_Until_Today = (to - from).Days;
        //    int Days_to_add = rand.Next(Days_Until_Today + 1);
        //    DateTime new_date = from.AddDays(Days_to_add);

        //    return new_date;
        //}


        ////Funcion para calcular la edad
        //public static int Age(DateTime birthDate)
        //{
        //    return DateTime.Today.Subtract(birthDate).Days / 365;
        //}


        ////Funcion para calcular los años de servicio o antiguedad
        //public static int YearsOfService(DateTime entryDate)
        //{
        //    return DateTime.Today.Subtract(entryDate).Days / 365;
        //}

        //public static int YearsLeftToRetirement(int yearsOfService, string gender)
        //{
        //    switch (gender)
        //    {
        //        case "Mujer":
        //            return (60 - yearsOfService);
        //        case "Hombre":
        //            return (65 - yearsOfService);
        //        case "Otro":
        //            return (62 - yearsOfService);
        //        default:
        //            return 0;
        //    }
        //}


        ////Funcion para calcular el salario final
        //public static double Salary(double pay, string maritalStatus, int childrens, int YearsOfService, string position)
        //{
        //    double aditional;
        //    if (YearsOfService > 20)
        //    {
        //        aditional = pay * 0.25;
        //    }
        //    else
        //    {
        //        aditional = pay * 0.02 * YearsOfService;
        //    }

        //    if (position == "Ingeniero" || position == "Especialista")
        //    {
        //        aditional = aditional * 1.5;
        //    }

        //    if (maritalStatus == "Casado" && childrens > 3)
        //    {
        //        aditional = aditional + 5000;
        //    }
        //    return aditional + pay;
        //}


        ////Funcion para mostrar la lista de empleados
        //public static void ShowEmployes(List<empleado> empleados)
        //{
        //    foreach (empleado e in empleados)
        //    {
        //        Console.WriteLine("\n\n* Empleado: ");
        //        Console.WriteLine("    Nombre Completo: " + e.name + " " + e.surname);
        //        Console.WriteLine("    Fecha de Nacimiento: " + e.birthdDate.ToString("dd/MM/yyyy"));
        //        Console.WriteLine("    Fecha de Ingreso a la empresa: " + e.entryDate.ToString("dd/MM/yyyy"));
        //        Console.WriteLine("    Estado Civil: " + e.maritalStatus);
        //        Console.WriteLine("    Genero: " + e.gender);
        //        Console.WriteLine("    Cargo: " + e.position);
        //        Console.WriteLine("    Sueldo Base: $" + e.pay);

        //        //Calculos adicionales del punto 2

        //        Console.WriteLine("\n    Edad: " + Age(e.birthdDate) + " años");
        //        Console.WriteLine("    Antiguedad: " + YearsOfService(e.entryDate) + " años");
        //        Console.WriteLine("    Años faltantes para la jubilacion: " + YearsLeftToRetirement(YearsOfService(e.entryDate), e.gender) + " años");
        //        int childrens = rand.Next(10);
        //        Console.WriteLine("    Cantidad de hijos: " + childrens);
        //        Console.WriteLine("    Salario: $" + Salary(e.pay, e.maritalStatus, childrens, YearsOfService(e.entryDate), e.position));
        //    }
        //}

    }
}
