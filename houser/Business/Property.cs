﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using houser.Data;

namespace houser.Business
{
    public class Property
    {
        #region Fields
        protected string _accountNumber;
        protected string _Address;
        protected int _sqft;
        protected double _baths;
        protected int _beds;
        protected string _exterior;
        protected string _lastSaleDate;
        protected decimal _lastSalePrice;
        protected DateTime _dateModified;
        protected int _garageSize;
        protected bool _isNew;
        protected int _yearBuilt;
        protected string _type;
        protected string _builtAs;
        #endregion

        #region Propertiese
        public string AccountNumber { get { return _accountNumber; } set { _accountNumber = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public int Sqft { get { return _sqft; } set { _sqft = value; } }
        public double Baths { get { return _baths; } set { _baths = value; } }
        public int Beds { get { return _beds; } set { _beds = value; } }
        public string Exterior { get { return _exterior; } set { _exterior = value; } }
        public string LastSaleDate { get { return _lastSaleDate; } set { _lastSaleDate = value; } }
        public decimal LastSalePrice { get { return _lastSalePrice; } set { _lastSalePrice = value; } }
        public DateTime DateModified { get { return _dateModified; } set { _dateModified = value; } }
        public int GarageSize { get { return _garageSize; } set { _garageSize = value; } }
        public bool IsNew { get { return _isNew; } }
        public int YearBuilt { get { return _yearBuilt; } set { _yearBuilt = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string BuiltAs { get { return _builtAs; } set { _builtAs = value; } }
        #endregion
        

        #region Constructors
        public Property()
        {
        }

        // get/create new sale record by / with accountnumber and sale date.
        public Property(string accountNumber)
        {
            DataRow property = Property.GetPropertyByAccount(accountNumber);
            if (property == null)
            {
                _accountNumber = accountNumber;
                _isNew = true;
            }
            else
            {
                _isNew = false;
                _accountNumber = accountNumber;
                _Address = property["Address"].ToString();
                _baths = Convert.ToDouble(!string.IsNullOrEmpty(property["Baths"].ToString()) ? property["Baths"] : 0 );
                _beds = Convert.ToInt32(!string.IsNullOrEmpty(property["Beds"].ToString()) ? property["Beds"] : 0);
                _exterior = property["Exterior"].ToString();
                _lastSaleDate = property["LastSaleDate"].ToString();
                _lastSalePrice = Convert.ToDecimal(!string.IsNullOrEmpty(property["LastSalePrice"].ToString()) ? property["LastSalePrice"] : 0);
                _dateModified = Convert.ToDateTime(!string.IsNullOrEmpty(property["DateModified"].ToString()) ? property["DateModified"] : 01/01/2012);
                _garageSize = Convert.ToInt32(!string.IsNullOrEmpty(property["GarageSize"].ToString()) ? property["GarageSize"] : 0);
                _yearBuilt = Convert.ToInt32(!string.IsNullOrEmpty(property["YearBuilt"].ToString()) ? property["YearBuilt"] : 0);
                _type = property["Type"].ToString();
                _builtAs = property["BuiltAs"].ToString();
            }
        }
        #endregion

        #region Persistance
        public void Save()
        {
            if (IsNew)
                PropertyDB.InsertProperty(_accountNumber, _Address, _sqft, _baths, _beds, _exterior, _lastSaleDate,_lastSalePrice, _garageSize, _yearBuilt, _type, _builtAs);
            else
                PropertyDB.UpdateProperty(_accountNumber, _Address, _sqft, _baths, _beds, _exterior, _lastSaleDate,_lastSalePrice, _garageSize, _yearBuilt, _type, _builtAs);
        }
        #endregion
        public static DataRow GetPropertyByAccount(string accountNumber)
        {
            return PropertyDB.GetPropertyByAccount(accountNumber);
        }
        
    }
}