using System;
using System.Collections.Generic;
using System.Text;

namespace A896633.Actividad02
{
    class ayudante
    {
        public static int validarInt()
        {
            int numero;
            bool bandera = false;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out numero))
                {
                    Console.WriteLine("Por favor ingrese solo numeros");
                }
                else if (numero < 0)
                {
                    Console.WriteLine("solo se permite numeros mayores o igual a 0");
                }
                else bandera = true;
            } while (!bandera);
            return numero;
        }

        public static bool validarContinuar() //Me devuelve true si el usuario desea continuar
        {
            Console.Clear();
            Console.WriteLine("Ingrese 1 si desea continuar. 2 para volver al menu");
            bool bandera = false;
            bool validar = false;
            int variable;
            do
            {
                if (!int.TryParse(Console.ReadLine(), out variable))
                {
                    Console.WriteLine("Ingreso invalido");
                }
                else
                {
                    if (variable != 1 && variable != 2)
                    {
                        Console.WriteLine("solo puede ingresar 1 o 2");
                    }
                    else bandera = true;
                } 
            } while (!bandera);
            if (variable == 1)
                validar = true;
            if (variable == 2)
                validar = false;
            return validar;

        }


    }


}
