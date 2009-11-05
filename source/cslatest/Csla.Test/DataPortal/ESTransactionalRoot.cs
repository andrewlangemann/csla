using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Csla.Test.DataPortal
{
    [Serializable()]
    public class ESTransactionalRoot : BusinessBase<ESTransactionalRoot>
    {
        #region "Business methods"

        private int _ID;
        private string _firstName;
        private string _lastName;
        private string _smallColumn;
        //get the configurationmanager to work right
        public static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["Csla.Test.Properties.Settings.DataPortalTestDatabaseConnectionString"].ConnectionString;

        public int ID
        {
            get { return _ID; }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                PropertyHasChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                PropertyHasChanged("LastName");
            }
        }

        public string SmallColumn
        {
            get { return _smallColumn; }
            set
            {
                _smallColumn = value;
                PropertyHasChanged("SmallColumn");
            }
        }

        #endregion

        #region "Object ID value"

        protected override object GetIdValue()
        {
            return _ID;
        }

        #endregion

        protected override void AddBusinessRules()
        {
            //normally, we would add a rule that prevents SmallColumn from being too long
            //but to easily test the transactional functionality of the server-side dataportal
            //we are going to allow strings that are longer than what the database allows
        }

        #region "constructors"

        private ESTransactionalRoot()
        {
            //require factory method 
        }

        #endregion

        #region "Factory Methods"

        public static ESTransactionalRoot NewESTransactionalRoot()
        {
            return Csla.DataPortal.Create<ESTransactionalRoot>();
        }

        public static ESTransactionalRoot GetESTransactionalRoot(int ID)
        {
            return Csla.DataPortal.Fetch<ESTransactionalRoot>(new Criteria(ID));
        }

        public static void DeleteESTransactionalRoot(int ID)
        {
            Csla.DataPortal.Delete(new Criteria(ID));
        }

        #endregion

        public override ESTransactionalRoot Save()
        {
            return base.Save();
        }

        #region "Criteria"

        [Serializable()]
        private class Criteria
        {
            public int _id;

            public Criteria(int id)
            {
                this._id = id;
            }
        }

        #endregion

        #region "Data Access"

        [RunLocal()]
        protected override void DataPortal_Create()
        {
            Csla.ApplicationContext.GlobalContext.Clear();
            Csla.ApplicationContext.GlobalContext.Add("ESTransactionalRoot", "Created");
            ValidationRules.CheckRules();
            Console.WriteLine("DataPortal_Create");
        }

        protected override void DataPortal_Fetch(object criteria)
        {
            Console.WriteLine("DataPortal_Fetch");
            Csla.ApplicationContext.GlobalContext.Clear();
            Csla.ApplicationContext.GlobalContext.Add("ESTransactionalRoot", "Fetched");
            ValidationRules.CheckRules();
        }

        protected override void DataPortal_Insert()
        {
            SqlConnection cn = new SqlConnection(CONNECTION_STRING);
            string firstName = this._firstName;
            string lastName = this._lastName;
            string smallColumn = this._smallColumn;

            //this command will always execute successfully
            //since it inserts a string less than 5 characters
            //into SmallColumn
            SqlCommand cm1 = new SqlCommand();
            cm1.Connection = cn;
            cm1.CommandText = "INSERT INTO Table2(FirstName, LastName, SmallColumn) VALUES('Bill', 'Thompson', 'abc')";

            //this command will throw an exception
            //if SmallColumn is set to a string longer than 
            //5 characters
            SqlCommand cm2 = new SqlCommand();
            cm2.Connection = cn;
            //use stringbuilder
            cm2.CommandText = "INSERT INTO Table2(FirstName, LastName, SmallColumn) VALUES('";
            cm2.CommandText += firstName;
            cm2.CommandText += "', '" + lastName + "', '" + smallColumn + "')";

            cn.Open();
            cm1.ExecuteNonQuery();
            cm2.ExecuteNonQuery();
            cn.Close();

            Csla.ApplicationContext.GlobalContext.Clear();
            Csla.ApplicationContext.GlobalContext.Add("ESTransactionalRoot", "Inserted");
            Console.WriteLine("DataPortal_Insert");
        }

        [Transactional(TransactionalTypes.EnterpriseServices)]
        protected override void DataPortal_Update()
        {
            Console.WriteLine("DataPortal_Update");
            Csla.ApplicationContext.GlobalContext.Clear();
            Csla.ApplicationContext.GlobalContext.Add("ESTransactionalRoot", "Updated");
        }

        protected override void DataPortal_DeleteSelf()
        {
            Console.WriteLine("DataPortal_DeleteSelf");
            Csla.ApplicationContext.GlobalContext.Clear();
            Csla.ApplicationContext.GlobalContext.Add("ESTransactionalRoot", "Deleted Self");
        }

        protected override void DataPortal_Delete(object criteria)
        {
            Console.WriteLine("DataPortal_Delete");
            Csla.ApplicationContext.GlobalContext.Clear();
            Csla.ApplicationContext.GlobalContext.Add("ESTransactionRoot", "Deleted");
        }

        #endregion
    }
}