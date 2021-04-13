using System;
using System.Collections.Generic;

namespace A896633.Actividad02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido al sistema de Control de stock. \nNOTAS IMPORTANTES: \n POR EL MODULO 1 SOLO SE INGRESAN PRODUCTOS QUE NO ESTAN REGISTRADOS. \n POR EL MODULO 2 Y 3 INGRESAN Y EGRESAN PRODUCTOS YA REGISTRADOS");
            Console.ReadKey();
            bool menu = false;
            
            Dictionary<int, int> stock = new Dictionary<int, int>();
            
            while (!menu)
            {
                Console.Clear();
                Console.WriteLine("Modulos. Ingrese:  \n 1. Ingresar al catalogo productos nuevos. \n 2. Ingresar Pedido \n 3. Entrega de Pedido \n 4. Reporte de Stock \n 5. Salir");
                int entrada = ayudante.validarInt();
                switch (entrada)
                {
                    case 1:                       
                            bool bandera = true;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("ID del producto");
                            int id = ayudante.validarInt();
                            Console.Clear();
                            Console.WriteLine("Cantidad");
                            int cant = ayudante.validarInt();
                            bool contieneKey = stock.ContainsKey(id);
                            if (contieneKey)
                            {
                                Console.WriteLine("El producto ya existe en el catalogo. Favor de ingresarlo por el modulo 2");
                                Console.ReadKey();
                            }
                            else
                            {
                                stock.Add(id, cant);
                                Console.Clear();
                            } 
                            bool validar = ayudante.validarContinuar();
                            if (!validar)
                                bandera = false;

                        } while (bandera);
                        Console.Clear();
                        break;
                    case 2:
                        bool bandera2 = false;
                        do
                        {
                            Console.WriteLine("Favor de ingresar ID del producto");
                            int id = ayudante.validarInt();
                            bool contieneKey = stock.ContainsKey(id);
                            if (contieneKey)
                            {
                                int StockId;
                                stock.TryGetValue(id, out StockId);
                                stock.Remove(id);
                                Console.WriteLine("Favor de ingresar la cantidad a ingresar");
                                int StockIngresar = ayudante.validarInt();
                                int StockNuevo = StockId + StockIngresar;
                                stock.Add(id, StockNuevo);
                                Console.WriteLine("el stock ha sido actualizado");
                                Console.ReadKey();
                                
                            }
                            else Console.WriteLine("Producto no existente. Favor de ingresar por el modulo 1");
                            Console.ReadKey();
                            Console.Clear();
                            bool validar = ayudante.validarContinuar();
                            if (!validar)
                                bandera2 = true;
                        } while (!bandera2);
                        

                        break;
                    case 3:
                        bool bandera3 = false;
                        do
                        {
                            Console.WriteLine("Favor de ingresar ID del producto a entregar");
                            int id = ayudante.validarInt();
                            bool contieneKey = stock.ContainsKey(id);
                            if (contieneKey)
                            {
                                int StockId;
                                stock.TryGetValue(id, out StockId);                              
                                Console.WriteLine("Favor de ingresar la cantidad a entregar");
                                int StockIngresar = ayudante.validarInt();
                                int StockNuevo = StockId - StockIngresar;
                                if (StockNuevo < 0)
                                {
                                    Console.WriteLine("Stock insuficiente.");
                                }
                                else
                                {
                                    stock.Remove(id);
                                    stock.Add(id, StockNuevo);
                                    Console.WriteLine("El producto puede ser entregado y el stock ha sido actualizado");
                                }                                                               
                                Console.ReadKey();

                            }
                            else Console.WriteLine("Producto no existente.");
                            Console.ReadKey();
                            Console.Clear();
                            bool validar = ayudante.validarContinuar();
                            if (!validar)
                                bandera3 = true;
                        } while (!bandera3);
                        break;
                    case 4:
                        Console.Clear();
                        foreach(var producto in stock)
                        {
                            Console.WriteLine("Para el producto Nro " + producto.Key + " hay " + producto.Value + " en stock");
                        }
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    case 5:
                        menu = true;
                        Console.Clear();
                        Console.WriteLine("Presione cualquier tecla para salir");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Favor de ingresar un numero valido");
                        break;
                }

            }
        }
    }
}
