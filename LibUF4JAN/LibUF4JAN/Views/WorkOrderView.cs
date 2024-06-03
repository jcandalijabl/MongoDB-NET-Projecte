using LibUF4JAN.DBContext;
using LibUF4JAN.DBContext.awDataSetTableAdapters;
using LibUF4JAN.Entities;
using SakilaDSEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using static LibUF4JAN.DBContext.awDataSet;

namespace LibUF4JAN.Views
{
    public class WorkOrderView : IEntityManagement<WorkOrder, int>
    {
        // Declaracions del DataSet i TableAdapter
        public static awDataSet ds = new awDataSet();
        WorkOrderTableAdapter workorder_adapter = new WorkOrderTableAdapter();

        #region Constructors

        public WorkOrderView()
        {
            workorder_adapter.Fill(ds.WorkOrder);
        }
        #endregion

        #region Implementacio Interficie
        public bool AddData(WorkOrder data)
        {
            try
            {
                WorkOrderRow data_row = ds.WorkOrder.NewWorkOrderRow();

                data_row.WorkOrderID = Retornar_dada(data.WorkOrderID);
                data_row.ProductID = Retornar_dada(data.ProductID);
                data_row.OrderQty = Retornar_dada(data.OrderQty);
                data_row.StockedQty = Retornar_dada(data.StockedQty);
                data_row.ScrappedQty = Retornar_dada(data.ScrappedQty);
                data_row.StartDate = Retornar_dada(data.StartDate);
                data_row.EndDate = Retornar_dada(data.EndDate);
                data_row.DueDate = Retornar_dada(data.DueDate);
                data_row.ScrapReasonID = Retornar_dada(data.ScrapReasonID);
                data_row.ModifiedDate = Retornar_dada(data.ModifiedDate);

                ds.WorkOrder.AddWorkOrderRow(data_row);
                workorder_adapter.Update(ds.WorkOrder);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<WorkOrder> GetData()
        {
            try
            {
                List<WorkOrder> lst_data = new List<WorkOrder>(); // Creo una llista buida de WorkOrder

                List<WorkOrderRow> files = new List<WorkOrderRow>(); // Creo una llista buida de WorkOrderRow
                files = ds.WorkOrder.ToList(); // Empleno la llista amb el DataSet

                foreach (WorkOrderRow fila in files)
                {
                    WorkOrder data = new WorkOrder(fila);
                    lst_data.Add(data);
                }

                return lst_data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public WorkOrder GetDataById(int Id)
        {
            try
            {
                // Obtinc la fila concreta amb l'Id especificat i la poso dins un objecte WorkOrderRow
                WorkOrderRow workorder = ds.WorkOrder.Where(c => c.ProductID == Id).FirstOrDefault();
                WorkOrder data = new WorkOrder();

                // Empleno l'objecte WorkOrder amb les dades de l'objcte WorkOrderRow
                data.WorkOrderID = (int)Retornar_dada(workorder["WorkOrderID"]);
                data.ProductID = (int)Retornar_dada(workorder["ProductID"]);
                data.OrderQty = (int)Retornar_dada(workorder["OrderQty"]);
                data.StockedQty = (int)Retornar_dada(workorder["StockedQty"]);
                data.ScrappedQty = (short)Retornar_dada(workorder["ScrappedQty"]);
                data.StartDate = (DateTime)Retornar_dada(workorder["StartDate"]);
                data.EndDate = (DateTime)Retornar_dada(workorder["EndDate"]);
                data.DueDate = (DateTime)Retornar_dada(workorder["DueDate"]);
                data.ScrapReasonID = (short)Retornar_dada(workorder["ScrapReasonID"]);
                data.ModifiedDate = (DateTime)Retornar_dada(workorder["ModifiedDate"]);

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Aquesta ID no existeix");
                throw e;
            }
        }

        public WorkOrder GetInstance()
        {
            WorkOrder workorder = new WorkOrder();
            return workorder;
        }

        public bool RemoveDataById(int Id)
        {
            try
            {
                // Obtenc la fila concreta de dades que tenen l'Id especificat i la elimino
                WorkOrderRow workorder = ds.WorkOrder.Where(c => c.ProductID == Id).FirstOrDefault();
                ds.WorkOrder.RemoveWorkOrderRow(workorder);
                workorder_adapter.Update(ds.WorkOrder);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateData(int Id, WorkOrder data)
        {
            try
            {
                // Obtenc la fila amb les dades que tenen l'Id especificat. Modifico les dades i actualizo.
                WorkOrderRow workorder = ds.WorkOrder.Where(c => c.ProductID == Id).FirstOrDefault();

                workorder.WorkOrderID = Retornar_dada(data.WorkOrderID);
                workorder.ProductID = Retornar_dada(data.ProductID);
                workorder.OrderQty = Retornar_dada(data.OrderQty);
                workorder.StockedQty = Retornar_dada(data.StockedQty);
                workorder.ScrappedQty = Retornar_dada(data.ScrappedQty);
                workorder.StartDate = Retornar_dada(data.StartDate);
                workorder.EndDate = Retornar_dada(data.EndDate);
                workorder.DueDate = Retornar_dada(data.DueDate);
                workorder.ScrapReasonID = Retornar_dada(data.ScrapReasonID);
                workorder.ModifiedDate = Retornar_dada(data.ModifiedDate);

                workorder_adapter.Update(workorder);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Metdes personalitzats

        // Metodes personalitzats

        public List<WorkOrder> GetOrdersBeforeDate(DateTime date)
        {
            List<WorkOrder> lst_data = new List<WorkOrder>(); // Creo una llista buida de WorkOrder

            List<WorkOrderRow> files = new List<WorkOrderRow>(); // Creo una llista buida de WorkOrderRow
            
            
            files = ds.WorkOrder.Where(c => c.StartDate < date).ToList(); // Empleno la llista amb el DataSet
            

            foreach (WorkOrderRow fila in files)
            {
                fila.ScrapReasonID = 1;
                WorkOrder data = new WorkOrder(fila);
                lst_data.Add(data);
            }

            return lst_data;
        }

        static T Retornar_dada<T>(T valor)
        {
            if (valor != null)
            {
                return valor;
            }
            else
            {
                return default;
            }
        }

        #endregion
    }
}
