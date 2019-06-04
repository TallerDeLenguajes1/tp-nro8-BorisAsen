using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class empleado
    {
        public string name;
        public string surname;
        public string maritalStatus;
        public string gender;
        public string position;
        public DateTime birthDate;
        public DateTime entryDate;
        public double pay;
        public int childrens;

        public Random rand = new Random();//Rand publico
        public empleado(string name, string surname, string maritalStatus, string gender, string position, DateTime birthDate, DateTime entryDate, double pay, int childrens)
        {
            //Console.WriteLine("Objeto Empleado construido");
            this.name = name;
            this.surname = surname;
            this.maritalStatus = maritalStatus;
            this.gender = gender;
            this.position = position;
            this.birthDate = birthDate;
            this.entryDate = entryDate;
            this.pay = pay;
            this.childrens = childrens;
        }

        //Funcion para calcular la edad
        public int Age()
        {
            return DateTime.Today.Subtract(birthDate).Days / 365;
        }

        //Funcion para calcular los años de servicio o antiguedad
        public int YearsOfService()
        {
            return DateTime.Today.Subtract(entryDate).Days / 365;
        }

        //Funcion para calcular los años restantes para la jubilacion
        public int YearsLeftToRetirement()
        {
            switch (gender)
            {
                case "Mujer":
                    return (60 - YearsOfService());
                case "Hombre":
                    return (65 - YearsOfService());
                case "Otro":
                    return (62 - YearsOfService());
                default:
                    return 0;
            }
        }

        //Funcion para calcular el salario final

        public double Salary()
        {
            double aditional;
            if (YearsOfService() > 20)
            {
                aditional = pay * 0.25;
            }
            else
            {
                aditional = pay * 0.02 * YearsOfService();
            }

            if (position == "Ingeniero" || position == "Especialista")
            {
                aditional = aditional * 1.5;
            }

            if (maritalStatus == "Casado" && childrens > 3)
            {
                aditional = aditional + 5000;
            }
            return aditional + pay;
        }

        public void ShowEmployee()
        {
            Console.WriteLine("\n\n* Empleado: ");
            Console.WriteLine("    Nombre Completo: " + name + " " + surname);
            Console.WriteLine("    Fecha de Nacimiento: " + birthDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("    Fecha de Ingreso a la empresa: " + entryDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("    Estado Civil: " + maritalStatus);
            Console.WriteLine("    Genero: " + gender);
            Console.WriteLine("    Cargo: " + position);
            Console.WriteLine("    Sueldo Base: $" + pay);

            //Calculos adicionales del punto 2
            Console.WriteLine("\n    Edad: " + Age() + " años");
            Console.WriteLine("    Antiguedad: " + YearsOfService() + " años");
            Console.WriteLine("    Años faltantes para la jubilacion: " + YearsLeftToRetirement() + " años");
            Console.WriteLine("    Cantidad de hijos: " + childrens);
            Console.WriteLine("    Salario: $" + Salary());
        }

        public void ReturnEmployee()
        {
            Console.WriteLine("\n\n* Empleado: ");
            Console.WriteLine("    Nombre Completo: " + name + " " + surname);
            Console.WriteLine("    Fecha de Nacimiento: " + birthDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("    Fecha de Ingreso a la empresa: " + entryDate.ToString("dd/MM/yyyy"));
            Console.WriteLine("    Estado Civil: " + maritalStatus);
            Console.WriteLine("    Genero: " + gender);
            Console.WriteLine("    Cargo: " + position);
            Console.WriteLine("    Sueldo Base: $" + pay);

            //Calculos adicionales del punto 2
            Console.WriteLine("\n    Edad: " + Age() + " años");
            Console.WriteLine("    Antiguedad: " + YearsOfService() + " años");
            Console.WriteLine("    Años faltantes para la jubilacion: " + YearsLeftToRetirement() + " años");
            Console.WriteLine("    Cantidad de hijos: " + childrens);
            Console.WriteLine("    Salario: $" + Salary());
        }

    }
}
