﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::System.Data.Objects.DataClasses.EdmSchemaAttribute()]

// Original file name:
// Generation date: 9/17/2008 11:23:42 AM
namespace Csla.Test.Data
{
    
    /// <summary>
    /// There are no comments for DataPortalTestDatabaseEntities in the schema.
    /// </summary>
    public partial class DataPortalTestDatabaseEntities : global::System.Data.Objects.ObjectContext
    {
        /// <summary>
        /// Initializes a new DataPortalTestDatabaseEntities object using the connection string found in the 'DataPortalTestDatabaseEntities' section of the application configuration file.
        /// </summary>
        public DataPortalTestDatabaseEntities() : 
                base("name=DataPortalTestDatabaseEntities", "DataPortalTestDatabaseEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DataPortalTestDatabaseEntities object.
        /// </summary>
        public DataPortalTestDatabaseEntities(string connectionString) : 
                base(connectionString, "DataPortalTestDatabaseEntities")
        {
            this.OnContextCreated();
        }
        /// <summary>
        /// Initialize a new DataPortalTestDatabaseEntities object.
        /// </summary>
        public DataPortalTestDatabaseEntities(global::System.Data.EntityClient.EntityConnection connection) : 
                base(connection, "DataPortalTestDatabaseEntities")
        {
            this.OnContextCreated();
        }
        partial void OnContextCreated();
        /// <summary>
        /// There are no comments for Table2 in the schema.
        /// </summary>
        public global::System.Data.Objects.ObjectQuery<Table2> Table2
        {
            get
            {
                if ((this._Table2 == null))
                {
                    this._Table2 = base.CreateQuery<Table2>("[Table2]");
                }
                return this._Table2;
            }
        }
        private global::System.Data.Objects.ObjectQuery<Table2> _Table2;
        /// <summary>
        /// There are no comments for Table2 in the schema.
        /// </summary>
        public void AddToTable2(Table2 table2)
        {
            base.AddObject("Table2", table2);
        }
    }
    /// <summary>
    /// There are no comments for DataPortalTestDatabaseModel.Table2 in the schema.
    /// </summary>
    /// <KeyProperties>
    /// FirstName
    /// LastName
    /// SmallColumn
    /// </KeyProperties>
    [global::System.Data.Objects.DataClasses.EdmEntityTypeAttribute(NamespaceName="DataPortalTestDatabaseModel", Name="Table2")]
    [global::System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [global::System.Serializable()]
    public partial class Table2 : global::System.Data.Objects.DataClasses.EntityObject
    {
        /// <summary>
        /// Create a new Table2 object.
        /// </summary>
        /// <param name="firstName">Initial value of FirstName.</param>
        /// <param name="lastName">Initial value of LastName.</param>
        /// <param name="smallColumn">Initial value of SmallColumn.</param>
        public static Table2 CreateTable2(string firstName, string lastName, string smallColumn)
        {
            Table2 table2 = new Table2();
            table2.FirstName = firstName;
            table2.LastName = lastName;
            table2.SmallColumn = smallColumn;
            return table2;
        }
        /// <summary>
        /// There are no comments for Property FirstName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this._FirstName;
            }
            set
            {
                this.OnFirstNameChanging(value);
                this.ReportPropertyChanging("FirstName");
                this._FirstName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("FirstName");
                this.OnFirstNameChanged();
            }
        }
        private string _FirstName;
        partial void OnFirstNameChanging(string value);
        partial void OnFirstNameChanged();
        /// <summary>
        /// There are no comments for Property LastName in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this._LastName;
            }
            set
            {
                this.OnLastNameChanging(value);
                this.ReportPropertyChanging("LastName");
                this._LastName = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("LastName");
                this.OnLastNameChanged();
            }
        }
        private string _LastName;
        partial void OnLastNameChanging(string value);
        partial void OnLastNameChanged();
        /// <summary>
        /// There are no comments for Property SmallColumn in the schema.
        /// </summary>
        [global::System.Data.Objects.DataClasses.EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [global::System.Runtime.Serialization.DataMemberAttribute()]
        public string SmallColumn
        {
            get
            {
                return this._SmallColumn;
            }
            set
            {
                this.OnSmallColumnChanging(value);
                this.ReportPropertyChanging("SmallColumn");
                this._SmallColumn = global::System.Data.Objects.DataClasses.StructuralObject.SetValidValue(value, false);
                this.ReportPropertyChanged("SmallColumn");
                this.OnSmallColumnChanged();
            }
        }
        private string _SmallColumn;
        partial void OnSmallColumnChanging(string value);
        partial void OnSmallColumnChanged();
    }
}
