using LibUF4JAN.DBContext;
using LibUF4JAN.DBContext.awDataSetTableAdapters;
using LibUF4JAN.Entities;
using SakilaDSEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static LibUF4JAN.DBContext.awDataSet;

namespace LibUF4JAN.Views
{
    public class ProductView : IEntityManagement<Product, int>
    {
        // Declaracions del DataSet i TableAdapter
        public static awDataSet ds = new awDataSet();
        ProductTableAdapter product_adapter = new ProductTableAdapter();

        #region Constructors

        public ProductView() 
        {
            product_adapter.Fill(ds.Product);
        }
        #endregion

        #region Implementacio interficie

        public bool AddData(Product data)
        {
            try
            {
                ProductRow data_row = ds.Product.NewProductRow();

                data_row.ProductID = Retornar_dada(data.ProductID);
                data_row.Name = Retornar_dada(data.Name);
                data_row.ProductNumber = Retornar_dada(data.ProductNumber);
                data_row.MakeFlag = Retornar_dada(data.MakeFlag);
                data_row.FinishedGoodsFlag = Retornar_dada(data.FinishedGoodsFlag);
                data_row.Color = Retornar_dada(data.Color);
                data_row.SafetyStockLevel = Retornar_dada(data.SafetyStockLevel);
                data_row.ReorderPoint = Retornar_dada(data.ReorderPoint);
                data_row.StandardCost = Retornar_dada(data.StandardCost);
                data_row.ListPrice = Retornar_dada(data.ListPrice);
                data_row.Size = Retornar_dada(data.Size);
                data_row.SizeUnitMeasureCode = Retornar_dada(data.SizeUnitMeasureCode);
                data_row.WeightUnitMeasureCode = Retornar_dada(data.WeightUnitMeasureCode);
                data_row.Weight = Retornar_dada(data.Weight);
                data_row.DaysToManufacture = Retornar_dada(data.DaysToManufacture);
                data_row.ProductLine = Retornar_dada(data.ProductLine);
                data_row.Class = Retornar_dada(data.Class);
                data_row.Style = Retornar_dada(data.Style);
                data_row.ProductSubcategoryID = Retornar_dada(data.ProductSubcategoryID);
                data_row.ProductModelID = Retornar_dada(data.ProductModelID);
                data_row.SellStartDate = Retornar_dada(data.SellStartDate);
                data_row.SellEndDate = Retornar_dada(data.SellEndDate);
                data_row.DiscontinuedDate = Retornar_dada(data.DiscontinuedDate);
                data_row.rowguid = Retornar_dada(data.rowguid);
                data_row.ModifiedDate = Retornar_dada(data.ModifiedDate);

                ds.Product.AddProductRow(data_row);
                product_adapter.Update(ds.Product);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public List<Product> GetData()
        {
            try
            {
                List<Product> lst_data = new List<Product>(); // Creo una llista buida de Product
                 // Creo un objecte Product buit

                List<ProductRow> files = new List<ProductRow>(); // Creo una llista buida de ProductRow
                files = ds.Product.ToList(); // Empleno la llista amb el DataSet

                foreach (ProductRow fila in files)
                {
                    // Empleno l'objecte Product
                    Product data = new Product(fila);

                    lst_data.Add(data);
                }

                return lst_data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Product GetDataById(int Id)
        {
            try
            {
                // Obtenc la fila amb dades que tenen l'Id especificada i ho poso en un ProductRow
                ProductRow product = ds.Product.Where(c => c.ProductID == Id).FirstOrDefault();
                // Creo un objecte de tipus Product per poder fer la transferéncia de dades a continuació
                Product data = new Product();

                // Empleno l'objecte Product
                data.ProductID = Retornar_dada(product.ProductID);
                data.Name = Retornar_dada(product.Name);
                data.ProductNumber = Retornar_dada(product.ProductNumber);
                data.MakeFlag = Retornar_dada(product.MakeFlag);
                data.FinishedGoodsFlag = Retornar_dada(product.FinishedGoodsFlag);
                data.Color = Retornar_dada(product.Color);
                data.SafetyStockLevel = Retornar_dada(product.SafetyStockLevel);
                data.ReorderPoint = Retornar_dada(product.ReorderPoint);
                data.StandardCost = Retornar_dada(product.StandardCost);
                data.ListPrice = Retornar_dada(product.ListPrice);
                data.Size = Retornar_dada(product.Size);
                data.SizeUnitMeasureCode = Retornar_dada(product.SizeUnitMeasureCode);
                data.WeightUnitMeasureCode = Retornar_dada(product.WeightUnitMeasureCode);
                data.Weight = Retornar_dada(product.Weight);
                data.DaysToManufacture = Retornar_dada(product.DaysToManufacture);
                data.ProductLine = Retornar_dada(product.ProductLine);
                data.Class = Retornar_dada(product.Class);
                data.Style = Retornar_dada(product.Style);
                data.ProductSubcategoryID = Retornar_dada(product.ProductSubcategoryID);
                data.ProductModelID = Retornar_dada(product.ProductModelID);
                data.SellStartDate = Retornar_dada(product.SellStartDate);
                data.SellEndDate = Retornar_dada(product.SellEndDate);
                data.DiscontinuedDate = Retornar_dada(product.DiscontinuedDate);
                data.rowguid = Retornar_dada(product.rowguid);
                data.ModifiedDate = Retornar_dada(product.ModifiedDate);

                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine("Aquesta ID no existeix");
                throw e;
            }
        }

        public Product GetInstance()
        {
            Product product = new Product();
            return product;
        }

        public bool RemoveDataById(int Id)
        {
            try
            {
                ProductRow product = ds.Product.Where(c => c.ProductID == Id).FirstOrDefault();
                ds.Product.RemoveProductRow(product);
                product_adapter.Update(ds.Product);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateData(int Id, Product data)
        {
            try
            {
                ProductRow product = ds.Product.Where(c => c.ProductID == Id).FirstOrDefault();

                product.ProductID = Retornar_dada(data.ProductID);
                product.Name = Retornar_dada(data.Name);
                product.ProductNumber = Retornar_dada(data.ProductNumber);
                product.MakeFlag = Retornar_dada(data.MakeFlag);
                product.FinishedGoodsFlag = Retornar_dada(data.FinishedGoodsFlag);
                product.Color = Retornar_dada(data.Color);
                product.SafetyStockLevel = Retornar_dada(data.SafetyStockLevel);
                product.ReorderPoint = Retornar_dada(data.ReorderPoint);
                product.StandardCost = Retornar_dada(data.StandardCost);
                product.ListPrice = Retornar_dada(data.ListPrice);
                product.Size = Retornar_dada(data.Size);
                product.SizeUnitMeasureCode = Retornar_dada(data.SizeUnitMeasureCode);
                product.WeightUnitMeasureCode = Retornar_dada(data.WeightUnitMeasureCode);
                product.Weight = Retornar_dada(data.Weight);
                product.DaysToManufacture = Retornar_dada(data.DaysToManufacture);
                product.ProductLine = Retornar_dada(data.ProductLine);
                product.Class = Retornar_dada(data.Class);
                product.Style = Retornar_dada(data.Style);
                product.ProductSubcategoryID = Retornar_dada(data.ProductSubcategoryID);
                product.ProductModelID = Retornar_dada(data.ProductModelID);
                product.SellStartDate = Retornar_dada(data.SellStartDate);
                product.SellEndDate = Retornar_dada(data.SellEndDate);
                product.DiscontinuedDate = Retornar_dada(data.DiscontinuedDate);
                product.rowguid = Retornar_dada(data.rowguid);
                product.ModifiedDate = Retornar_dada(data.ModifiedDate);

                product_adapter.Update(product);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Metodes personalitzats

        // Metodes personalitzats

        public double GetMonthlyAvg(int month)
        {
            List<ProductRow> lst_product = product_adapter.GetDataByMonth(month).ToList();

            double monthlyAvg = 0;
            int i;

            for (i = 0; i < lst_product.Count; i++)
            {
                monthlyAvg++;
            }
            monthlyAvg = monthlyAvg / i;
            return monthlyAvg;
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
