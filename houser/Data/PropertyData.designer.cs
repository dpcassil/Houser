﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace houser.Data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Houser")]
	public partial class PropertyData : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPropertyRecord(PropertyRecord instance);
    partial void UpdatePropertyRecord(PropertyRecord instance);
    partial void DeletePropertyRecord(PropertyRecord instance);
    partial void InsertProperty(Property instance);
    partial void UpdateProperty(Property instance);
    partial void DeleteProperty(Property instance);
    partial void InsertSSaleRecord(SSaleRecord instance);
    partial void UpdateSSaleRecord(SSaleRecord instance);
    partial void DeleteSSaleRecord(SSaleRecord instance);
    #endregion
		
		public PropertyData() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["HouserConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PropertyData(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PropertyData(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PropertyData(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PropertyData(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<PropertyRecord> PropertyRecords
		{
			get
			{
				return this.GetTable<PropertyRecord>();
			}
		}
		
		public System.Data.Linq.Table<PropertyComp> PropertyComps
		{
			get
			{
				return this.GetTable<PropertyComp>();
			}
		}
		
		public System.Data.Linq.Table<Property> Properties
		{
			get
			{
				return this.GetTable<Property>();
			}
		}
		
		public System.Data.Linq.Table<SSaleRecord> SSaleRecords
		{
			get
			{
				return this.GetTable<SSaleRecord>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PropertyRecord")]
	public partial class PropertyRecord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _AccountNumber;
		
		private string _Data;
		
		private System.DateTime _DateCreated;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccountNumberChanging(string value);
    partial void OnAccountNumberChanged();
    partial void OnDataChanging(string value);
    partial void OnDataChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public PropertyRecord()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountNumber", DbType="VarChar(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="VarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PropertyComps")]
	public partial class PropertyComp
	{
		
		private string _PropertyAccount;
		
		private string _CompAccount;
		
		public PropertyComp()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PropertyAccount", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string PropertyAccount
		{
			get
			{
				return this._PropertyAccount;
			}
			set
			{
				if ((this._PropertyAccount != value))
				{
					this._PropertyAccount = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CompAccount", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string CompAccount
		{
			get
			{
				return this._CompAccount;
			}
			set
			{
				if ((this._CompAccount != value))
				{
					this._CompAccount = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Property")]
	public partial class Property : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _AccountNumber;
		
		private string _Address;
		
		private int _SQFT;
		
		private int _Beds;
		
		private string _Baths;
		
		private int _Garage;
		
		private string _SalePrice;
		
		private string _SaleDate;
		
		private System.Nullable<System.DateTime> _DateCreated;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccountNumberChanging(string value);
    partial void OnAccountNumberChanged();
    partial void OnAddressChanging(string value);
    partial void OnAddressChanged();
    partial void OnSQFTChanging(int value);
    partial void OnSQFTChanged();
    partial void OnBedsChanging(int value);
    partial void OnBedsChanged();
    partial void OnBathsChanging(string value);
    partial void OnBathsChanged();
    partial void OnGarageChanging(int value);
    partial void OnGarageChanged();
    partial void OnSalePriceChanging(string value);
    partial void OnSalePriceChanged();
    partial void OnSaleDateChanging(string value);
    partial void OnSaleDateChanged();
    partial void OnDateCreatedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateCreatedChanged();
    #endregion
		
		public Property()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountNumber", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this.OnAddressChanging(value);
					this.SendPropertyChanging();
					this._Address = value;
					this.SendPropertyChanged("Address");
					this.OnAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SQFT", DbType="Int NOT NULL")]
		public int SQFT
		{
			get
			{
				return this._SQFT;
			}
			set
			{
				if ((this._SQFT != value))
				{
					this.OnSQFTChanging(value);
					this.SendPropertyChanging();
					this._SQFT = value;
					this.SendPropertyChanged("SQFT");
					this.OnSQFTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Beds", DbType="Int NOT NULL")]
		public int Beds
		{
			get
			{
				return this._Beds;
			}
			set
			{
				if ((this._Beds != value))
				{
					this.OnBedsChanging(value);
					this.SendPropertyChanging();
					this._Beds = value;
					this.SendPropertyChanged("Beds");
					this.OnBedsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Baths", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string Baths
		{
			get
			{
				return this._Baths;
			}
			set
			{
				if ((this._Baths != value))
				{
					this.OnBathsChanging(value);
					this.SendPropertyChanging();
					this._Baths = value;
					this.SendPropertyChanged("Baths");
					this.OnBathsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Garage", DbType="Int NOT NULL")]
		public int Garage
		{
			get
			{
				return this._Garage;
			}
			set
			{
				if ((this._Garage != value))
				{
					this.OnGarageChanging(value);
					this.SendPropertyChanging();
					this._Garage = value;
					this.SendPropertyChanged("Garage");
					this.OnGarageChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SalePrice", DbType="VarChar(10)")]
		public string SalePrice
		{
			get
			{
				return this._SalePrice;
			}
			set
			{
				if ((this._SalePrice != value))
				{
					this.OnSalePriceChanging(value);
					this.SendPropertyChanging();
					this._SalePrice = value;
					this.SendPropertyChanged("SalePrice");
					this.OnSalePriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SaleDate", DbType="VarChar(10)")]
		public string SaleDate
		{
			get
			{
				return this._SaleDate;
			}
			set
			{
				if ((this._SaleDate != value))
				{
					this.OnSaleDateChanging(value);
					this.SendPropertyChanging();
					this._SaleDate = value;
					this.SendPropertyChanged("SaleDate");
					this.OnSaleDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="Date")]
		public System.Nullable<System.DateTime> DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.SSaleRecord")]
	public partial class SSaleRecord : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _AccountNumber;
		
		private string _Price;
		
		private string _Note;
		
		private System.Nullable<System.DateTime> _SaleDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAccountNumberChanging(string value);
    partial void OnAccountNumberChanged();
    partial void OnPriceChanging(string value);
    partial void OnPriceChanged();
    partial void OnNoteChanging(string value);
    partial void OnNoteChanged();
    partial void OnSaleDateChanging(System.Nullable<System.DateTime> value);
    partial void OnSaleDateChanged();
    #endregion
		
		public SSaleRecord()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AccountNumber", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string AccountNumber
		{
			get
			{
				return this._AccountNumber;
			}
			set
			{
				if ((this._AccountNumber != value))
				{
					this.OnAccountNumberChanging(value);
					this.SendPropertyChanging();
					this._AccountNumber = value;
					this.SendPropertyChanged("AccountNumber");
					this.OnAccountNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Note", DbType="VarChar(1000)")]
		public string Note
		{
			get
			{
				return this._Note;
			}
			set
			{
				if ((this._Note != value))
				{
					this.OnNoteChanging(value);
					this.SendPropertyChanging();
					this._Note = value;
					this.SendPropertyChanged("Note");
					this.OnNoteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SaleDate", DbType="Date")]
		public System.Nullable<System.DateTime> SaleDate
		{
			get
			{
				return this._SaleDate;
			}
			set
			{
				if ((this._SaleDate != value))
				{
					this.OnSaleDateChanging(value);
					this.SendPropertyChanging();
					this._SaleDate = value;
					this.SendPropertyChanged("SaleDate");
					this.OnSaleDateChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591