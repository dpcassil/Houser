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
        protected DateTime _lastSaleDate;
        protected int _lastSalePrice;
        protected DateTime _dateModified;
        protected int _garageSize;
        protected bool _isNew;
        #endregion

        #region Propertiese
        public string AccountNumber { get { return _accountNumber; } set { _accountNumber = value; } }
        public string Address { get { return _Address; } set { _Address = value; } }
        public int Sqft { get { return _sqft; } set { _sqft = value; } }
        public double Baths { get { return _baths; } set { _baths = value; } }
        public int Beds { get { return _beds; } set { _beds = value; } }
        public string Exterior { get { return _exterior; } set { _exterior = value; } }
        public DateTime LastSaleDate { get { return _lastSaleDate; } set { _lastSaleDate = value; } }
        public int LastSalePrice { get { return _lastSalePrice; } set { _lastSalePrice = value; } }
        public DateTime DateModified { get { return _dateModified; } set { _dateModified = value; } }
        public int GarageSize { get { return _garageSize; } set { _garageSize = value; } }
        public bool IsNew { get { return _isNew; } }
        #endregion
        #region Static Methods

        #region Constructors
        public Property()
        {
        }

        // get/create new sale record by / with accountnumber and sale date.
        public Property(string accountNumber)
        {
            DataRow property = Property.GetPropertyByAccount(accountNumber);
            if (saleRecord == null)
                isNew = true;
            else
            {
                isNew = false;
                _accountNumber = accountNumber;
                _saleDate = saleDate;
                _salePrice = Convert.ToDouble(saleRecord["SalePrice"]);
                _saleRecordID = Convert.ToInt32(saleRecord["SaleRecordID"]);
            }
        }
        #endregion

        #endregion
        public static DataSet GetPropertyByAccount(string accountNumber)
        {
            return PropertyDB.GetPropertyByAccount(accountNumber);
        }
        #endregion
    }
}