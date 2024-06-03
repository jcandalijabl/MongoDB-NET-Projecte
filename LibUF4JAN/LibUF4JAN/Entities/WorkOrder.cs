using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibUF4JAN.DBContext.awDataSet;

namespace LibUF4JAN.Entities
{
    public class WorkOrder
    {
        public int WorkOrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderQty { get; set; }
        public int StockedQty { get; set; }
        public short ScrappedQty { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DueDate { get; set; }
        public short ScrapReasonID { get; set; }
        public DateTime ModifiedDate { get; set; }


        public WorkOrder() { }
        public WorkOrder(WorkOrderRow workorder)
        {
            if (!DBNull.Value.Equals(workorder["WorkOrderID"]))
                WorkOrderID = workorder.WorkOrderID;
            else
                WorkOrderID = default;

            if (!DBNull.Value.Equals(workorder["ProductID"]))
                ProductID = workorder.ProductID;
            else
                ProductID = default;

            if (!DBNull.Value.Equals(workorder["OrderQty"]))
                OrderQty = workorder.OrderQty;
            else
                OrderQty = default;

            if (!DBNull.Value.Equals(workorder["StockedQty"]))
                StockedQty = workorder.StockedQty;
            else
                StockedQty = default;

            if (!DBNull.Value.Equals(workorder["ScrappedQty"]))
                ScrappedQty = workorder.ScrappedQty;
            else
                ScrappedQty = default;

            if (!DBNull.Value.Equals(workorder["StartDate"]))
                StartDate = workorder.StartDate;
            else
                StartDate = default;

            if (!DBNull.Value.Equals(workorder["EndDate"]))
                EndDate = workorder.EndDate;
            else
                EndDate = default;

            if (!DBNull.Value.Equals(workorder["DueDate"]))
                DueDate = workorder.DueDate;
            else
                DueDate = default;

            if (!DBNull.Value.Equals(workorder["ScrapReasonID"]))
                ScrapReasonID = workorder.ScrapReasonID;
            else
                ScrapReasonID = 1;

            if (!DBNull.Value.Equals(workorder["ModifiedDate"]))
                ModifiedDate = workorder.ModifiedDate;
            else
                ModifiedDate = default;
        }

        /*static T Retornar_dada<T>(T valor)
        {
            if (!DBNull.Value.Equals(valor))
            {
                return valor;
            }
            else
            {
                return default;
            }
        }*/
    }
}
