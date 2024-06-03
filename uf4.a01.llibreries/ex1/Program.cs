using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibUF4JAN;
using LibUF4JAN.DBContext.awDataSetTableAdapters;
using LibUF4JAN.Entities;
using LibUF4JAN.Views;
using static LibUF4JAN.DBContext.awDataSet;

namespace ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductView productView = new ProductView();
            WorkOrderView workorderView = new WorkOrderView();


            List<Product> list_productes = productView.GetData();

            List<WorkOrder> list_workorder = workorderView.GetData();

            MainMenu(list_productes, list_workorder);
        }

        static string Opcio()
        {
            Console.WriteLine();
            Console.Write("             -- ");
            string opcio = Console.ReadLine();
            return opcio;
        }

        static void OperacioFinalitzada()
        {
            Console.WriteLine();
            Console.Write("     (!) HA FINALITZAT ");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Polsa una tecla per continuar... ");
            Console.ReadKey();
        }

        static void MainMenu(List<Product> list_productes, List<WorkOrder> list_workorder)
        {
            bool sortir = false;
            string opcio;

            do
            {
                Console.Clear();
                Console.WriteLine("         [====================================]");
                Console.WriteLine("         [=          MENÚ PRINCIPAL          =]");
                Console.WriteLine("         [====================================]");
                Console.WriteLine();
                Console.WriteLine("             1. Llistat simple dels productes");
                Console.WriteLine();
                Console.WriteLine("             2. Consultar les ordres de fabricació anteriors a la data (x data)");
                Console.WriteLine();
                Console.WriteLine("             3. Donar d'alta una nova ordre de fabricació");
                Console.WriteLine();
                Console.WriteLine("             4. Surt");

                opcio = Opcio();
                switch (opcio)
                {
                    case "1":
                        LlistatSimpleProducte(list_productes);
                        break;
                    case "2":
                        LlistatOrdresFabricacioAnteriors(list_workorder);
                        break;
                    case "3":
                        DonarAltaUnaOrdre(list_workorder);
                        break;
                    case "4":
                        sortir = true;
                        break;
                    default:
                        break;
                }
            } while (!sortir || string.IsNullOrEmpty(opcio));
        }

        static void LlistatSimpleProducte(List<Product> list_productes)
        {
            Console.Clear();
            Console.WriteLine("         [===================================================]");
            Console.WriteLine("         [=          LLISTAT SIMPLE DELS PRODUCTES          =]");
            Console.WriteLine("         [===================================================]");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("         Linia     Product ID    Name                        Num");
            Console.WriteLine("         #############################################################");
            Console.WriteLine();

            for (int i = 0; i < list_productes.Count; i++)
            {
                Console.WriteLine("         " + Convert.ToString(i).PadRight(10) + Convert.ToString(list_productes[i].ProductID).PadRight(14) + Convert.ToString(list_productes[i].Name).PadRight(28) + Convert.ToString(list_productes[i].ProductNumber));

                // Pausar cada 30 registres
                if (i % 30 == 0 && i > 0)
                {
                    Console.WriteLine();
                    Console.Write("         Mostra 30 més...");
                    Console.ReadKey();
                }
            }

            OperacioFinalitzada();
        }

        static void LlistatOrdresFabricacioAnteriors(List<WorkOrder> list_workorder)
        {
            bool exit = false;
            DateTime data;

            Console.Clear();
            Console.WriteLine("         [==================================================]");
            Console.WriteLine("         [=          LLISTAT ORDRES DE FABRICACIÓ          =]");
            Console.WriteLine("         [==================================================]");
            Console.WriteLine("         (Anteriors a una data)");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("         Data (dd/mm/yyyy): ");

            try
            {
                data = Convert.ToDateTime(Console.ReadLine());

                WorkOrderView workorderView = new WorkOrderView();
                List<WorkOrder> list_worder = workorderView.GetOrdersBeforeDate(data);

                Console.WriteLine();
                Console.WriteLine("         Linia     Product ID    Quantity    Start date");
                Console.WriteLine("         ##################################################");
                Console.WriteLine();

                for (int i = 0; i < list_workorder.Count && !exit; i++)
                {
                    Console.WriteLine("         " + Convert.ToString(i).PadRight(10) + Convert.ToString(list_workorder[i].ProductID).PadRight(14) + Convert.ToString(list_workorder[i].OrderQty).PadRight(12) + Convert.ToString(list_workorder[i].StartDate.ToShortDateString()));
                    
                    // Pausar cada 30 registres i preguntar si vol sortir abans de seguir
                    if (i % 30 == 0 && i > 0)
                    {
                        Console.WriteLine();
                        Console.Write("         Mostra 30 més... ('q' per sortir) ");
                        if (Console.ReadLine() == "q")
                        {
                            exit = true;
                        }
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("     (ERROR!) S'ha produït un error. Has inserit la data correctament?");
            }

            OperacioFinalitzada();
        }

        static void DonarAltaUnaOrdre(List<WorkOrder> list_workorder)
        {
            int id_a_cercar;
            int quantitat;

            Console.Clear();
            Console.WriteLine("         [==========================================================]");
            Console.WriteLine("         [=          DONAR D'ALTA UNA ORDRE DE FABRICACIÓ          =]");
            Console.WriteLine("         [==========================================================]");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("         Product ID: ");
            try
            {
                id_a_cercar = Convert.ToInt32(Console.ReadLine());

                WorkOrder worder2 = new WorkOrder();

                if (ExisteixProducte(list_workorder, id_a_cercar))
                {
                    Console.Write("         Quantitat: ");
                    quantitat = Convert.ToInt32(Console.ReadLine());

                    worder2.ProductID = id_a_cercar;
                    worder2.StartDate = DateTime.Now;
                    worder2.DueDate = DateTime.Now.AddDays(7);
                    worder2.ModifiedDate = DateTime.Now;
                    worder2.OrderQty = quantitat;
                    worder2.ScrappedQty = 0;


                    Console.WriteLine();
                    Console.WriteLine("         (!) S'ha donat d'alta el producte");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("     (ERROR!) Aquest producte no existeix.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
                Console.WriteLine("     (ERROR!) S'ha produït un error. Intenta-ho de nou.");
            }

            OperacioFinalitzada();
        }

        static bool ExisteixProducte(List<WorkOrder> list_workorder, int id)
        {
            for (int i = 0; i < list_workorder.Count; i++)
            {
                if (list_workorder[i].ProductID == id)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
