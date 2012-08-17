﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;



namespace houser.Data
{
    public class PropertyDB
    {
        private static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["HouserConnectionString1"].ConnectionString;
        #region static methods

        /// <summary>
        /// Example of sqlhelper execute dataset.
        /// </summary>
        public static DataRow GetPropertyByAccount(string accountNumber)
        {
            DataSet results =  SqlHelper.ExecuteDataset(CONNECTIONSTRING, CommandType.Text,
                @"SELECT TOP (1) * FROM Property WHERE AccountNumber = @AccountNumber",
                new SqlParameter("@AccountNumber", accountNumber));
            return results.Tables[0].Rows.Count > 0 ? results.Tables[0].Rows[0] : null;
        }

        public static void InsertProperty(string accountNumber, string address, int sqft, double baths, int beds,
             string exterior, string lastSaleDate, decimal lastSalePrice, int garageSize, int yearBuilt, string type, string builtAs)
        {
            SqlHelper.ExecuteNonQuery(CONNECTIONSTRING, CommandType.Text,
                @"INSERT INTO [Property]
                   ([AccountNumber] ,[Address] ,[Sqft] ,[Baths] ,[Beds] ,[Exterior] ,[LastSaleDate] ,[LastSalePrice] ,[GarageSize]
                    ,[YearBuilt] ,[Type] ,[BuiltAs])
                VALUES (@AccountNumber, @Address, @Sqft, @Baths, @Beds, @Exterior, @LastSaleDate, @LastSalePrice, @GarageSize, @YearBuilt, @Type, @BuiltAS)",
                new SqlParameter("@AccountNumber", accountNumber),
                new SqlParameter("@Address", address),
                new SqlParameter("@Sqft", sqft),
                new SqlParameter("@Baths", baths),
                new SqlParameter("@Beds", beds),
                new SqlParameter("@Exterior", exterior),
                new SqlParameter("@LastSaleDate", lastSaleDate),
                new SqlParameter("@LastSalePrice", lastSalePrice),
                new SqlParameter("@GarageSize", garageSize),
                new SqlParameter("@YearBuilt", yearBuilt),
                new SqlParameter("@Type", type),
                new SqlParameter("@BuiltAs", builtAs));
        }

        public static void UpdateProperty(string accountNumber, string address, int sqft, double baths, int beds,
             string exterior, string lastSaleDate, decimal lastSalePrice, int garageSize, int yearBuilt, string type, string builtAs)
        {
            var result = SqlHelper.ExecuteScalar(CONNECTIONSTRING, CommandType.Text,
                @"UPDATE [Property] SET [Address] = @Address ,[Sqft] = @Sqft ,[Baths] = @Baths ,[Beds] = @Beds 
                    ,[Exterior] = @Exterior ,[LastSaleDate] = @LastSaleDate ,[LastSalePrice] = @LastSalePrice ,[GarageSize] = @GarageSize
                    ,[YearBuilt] = @YearBuilt ,[Type] = @Type ,[BuiltAs] = @BuiltAS WHERE AccountNumber = @AccountNumber",
                new SqlParameter("@AccountNumber", accountNumber),
                new SqlParameter("@Address", address),
                new SqlParameter("@Sqft", sqft),
                new SqlParameter("@Baths", baths),
                new SqlParameter("@Beds", beds),
                new SqlParameter("@Exterior", exterior),
                new SqlParameter("@LastSaleDate", lastSaleDate),
                new SqlParameter("@LastSalePrice", lastSalePrice),
                new SqlParameter("@GarageSize", garageSize),
                new SqlParameter("@YearBuilt", yearBuilt),
                new SqlParameter("@Type", type),
                new SqlParameter("@BuiltAs", builtAs));
        }


        #endregion
    }
}