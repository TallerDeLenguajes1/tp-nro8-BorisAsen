using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP8
{
    class empleado
    {
        private string name;
        private string surname;
        private string maritalStatus;
        private string gender;
        private string position;
        private DateTime birthDate;
        private DateTime entryDate;
        private double pay;

        public empleado(string name, string surname, string maritalStatus, string gender, string position, DateTime birthDate, DateTime entryDate, double pay)
        {
            Console.WriteLine("Objeto Empleado construido");
            this.name = name;
            this.surname = surname;
            this.maritalStatus = maritalStatus;
            this.gender = gender;
            this.position = position;
            this.birthDate = birthDate;
            this.entryDate = entryDate;
            this.pay = pay;
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
        public Random rand = new Random();//Rand publico
        public double Salary()
        {
            int childrens = rand.Next(10);
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
            int childrens = rand.Next(10);
            Console.WriteLine("    Cantidad de hijos: " + childrens);
            Console.WriteLine("    Salario: $" + Salary());
        }



    }
}
