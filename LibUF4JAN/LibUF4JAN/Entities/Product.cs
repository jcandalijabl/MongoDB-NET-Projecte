using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibUF4JAN.DBContext.awDataSet;

namespace LibUF4JAN.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool MakeFlag { get; set; }
        public bool FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int ProductSubcategoryID { get; set; }
        public int ProductModelID { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime SellEndDate { get; set; }
        public DateTime DiscontinuedDate { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }


        public Product() { }

        public Product(ProductRow producte)
        {
            if (!DBNull.Value.Equals(producte["ProductID"]))
                ProductID = producte.ProductID;
            else
                ProductID = default;

            if (!DBNull.Value.Equals(producte["Name"]))
                Name = producte.Name;
            else
                Name = default;

            if (!DBNull.Value.Equals(producte["ProductNumber"]))
                ProductNumber = producte.ProductNumber;
            else
                ProductNumber = default;

            if (!DBNull.Value.Equals(producte["MakeFlag"]))
                MakeFlag = producte.MakeFlag;
            else
                MakeFlag = default;

            if (!DBNull.Value.Equals(producte["FinishedGoodsFlag"]))
                FinishedGoodsFlag = producte.FinishedGoodsFlag;
            else
                FinishedGoodsFlag = default;

            if (!DBNull.Value.Equals(producte["Color"]))
                Color = producte.Color;
            else
                Color = default;

            if (!DBNull.Value.Equals(producte["SafetyStockLevel"]))
                SafetyStockLevel = producte.SafetyStockLevel;
            else
                SafetyStockLevel = default;

            if (!DBNull.Value.Equals(producte["ReorderPoint"]))
                ReorderPoint = producte.ReorderPoint;
            else
                ReorderPoint = default;

            if (!DBNull.Value.Equals(producte["StandardCost"]))
                StandardCost = producte.StandardCost;
            else
                StandardCost = default;

            if (!DBNull.Value.Equals(producte["ListPrice"]))
                ListPrice = producte.ListPrice;
            else
                ListPrice = default;

            if (!DBNull.Value.Equals(producte["Size"]))
                Size = producte.Size;
            else
                Size = default;

            if (!DBNull.Value.Equals(producte["SizeUnitMeasureCode"]))
                SizeUnitMeasureCode = producte.SizeUnitMeasureCode;
            else
                SizeUnitMeasureCode = default;

            if (!DBNull.Value.Equals(producte["WeightUnitMeasureCode"]))
                WeightUnitMeasureCode = producte.WeightUnitMeasureCode;
            else
                WeightUnitMeasureCode = default;

            if (!DBNull.Value.Equals(producte["Weight"]))
                Weight = producte.Weight;
            else
                Weight = default;

            if (!DBNull.Value.Equals(producte["DaysToManufacture"]))
                DaysToManufacture = producte.DaysToManufacture;
            else
                DaysToManufacture = default;

            if (!DBNull.Value.Equals(producte["ProductLine"]))
                ProductLine = producte.ProductLine;
            else
                ProductLine = default;

            if (!DBNull.Value.Equals(producte["Class"]))
                Class = producte.Class;
            else
                Class = default;

            if (!DBNull.Value.Equals(producte["Style"]))
                Style = producte.Style;
            else
                Style = default;

            if (!DBNull.Value.Equals(producte["ProductSubcategoryID"]))
                ProductSubcategoryID = producte.ProductSubcategoryID;
            else
                ProductSubcategoryID = default;

            if (!DBNull.Value.Equals(producte["ProductModelID"]))
                ProductModelID = producte.ProductModelID;
            else
                ProductModelID = default;

            if (!DBNull.Value.Equals(producte["SellStartDate"]))
                SellStartDate = producte.SellStartDate;
            else
                SellStartDate = default;

            if (!DBNull.Value.Equals(producte["SellEndDate"]))
                SellEndDate = producte.SellEndDate;
            else
                SellEndDate = default;

            if (!DBNull.Value.Equals(producte["DiscontinuedDate"]))
                DiscontinuedDate = producte.DiscontinuedDate;
            else
                DiscontinuedDate = default;

            if (!DBNull.Value.Equals(producte["rowguid"]))
                rowguid = producte.rowguid;
            else
                rowguid = default;

            if (!DBNull.Value.Equals(producte["ModifiedDate"]))
                ModifiedDate = producte.ModifiedDate;
            else
                ModifiedDate = default;
        }

        static T Retornar_dada<T>(T valor)
        {
            if (!DBNull.Value.Equals(valor))
            {
                return valor;
            }
            else
            {
                return default;
            }
        }
    }
}
