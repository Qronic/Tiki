using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace tikiServer
{
    class dbHandler
    {
        private MySqlConnection dbConn;
        private string server;
        private string database;
        private string uid;
        private string password;


        public dbHandler()
        {
            init();
        }
        public bool dbConnected()
        {
            bool connectionGood = false;
            connectionGood = OpenConnection();
            CloseConnection();
            return (connectionGood);
        }
        private void init()
        {
            server = "localhost";
            database = "users";
            uid = "server";
            password = @"a5cN7UQ@&";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
                "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            dbConn = new MySqlConnection(connectionString);
        }

        //open db connection
        private bool OpenConnection()
        {
            try
            {

                dbConn.Open();
                return true;

            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        System.Windows.Forms.MessageBox.Show("Cannot connect to server. Contact Administrator.");
                        break;
                    case 1045:
                        System.Windows.Forms.MessageBox.Show("Invalid username/password combination, please try again.");
                        break;
                    default:
                        System.Windows.Forms.MessageBox.Show("Error: " + ex.Number + " has occured.");
                        break;

                }

                return false;


            }

        }
        //close db connection
        private bool CloseConnection()
        {
            try
            {
                dbConn.Close();
                return true;
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return false;
            }
        }
        //insert table data
        public void Insert(string query)
        {
            //open conn
            //System.Windows.Forms.MessageBox.Show("Inserting!");
            if (this.OpenConnection() == true)
            {
                //  System.Windows.Forms.MessageBox.Show("In if!");
                //crate a command and assign query and connection
                MySqlCommand cmd = new MySqlCommand(query, dbConn);

                //execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //update table data
        private void Update(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //assign the query using commandtext
                cmd.CommandText = query;
                //assign the connection using our db connection
                cmd.Connection = dbConn;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();

            }
        }
        //delete table data
        private void Delete(string query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, dbConn);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        //select function for using "SELECT *" command

        //public funcItem Select(string query)
        //{
        //    //create a list to store the results
        //    List<funcItem> results = new List<funcItem>();

        //    //open connection
        //    if (this.OpenConnection() == true)
        //    {
        //        //create command
        //        MySqlCommand cmd = new MySqlCommand(query, dbConn);
        //        //create a data reader and execute the command
        //        MySqlDataReader dataReader = cmd.ExecuteReader();
        //        funcItem myItem = new funcItem();

        //        //Read the data and store the results
        //        while (dataReader.Read())
        //        {

        //            myItem.setFuncId(int.Parse(dataReader["funcid"].ToString()));
        //            myItem.setStoreNum(int.Parse(dataReader["storenumber"].ToString()));
        //            myItem.setRegister(int.Parse(dataReader["register"].ToString()));
        //            myItem.setTransId(int.Parse(dataReader["transid"].ToString()));
        //            myItem.setDate(dataReader["date"].ToString());
        //            myItem.setBrand(dataReader["brand"].ToString());
        //            myItem.setModel(dataReader["model"].ToString());
        //            myItem.setMissAcc(dataReader["missingacc"].ToString());
        //            myItem.setMissAccNotes(dataReader["missaccnotes"].ToString());
        //            myItem.setCondition(dataReader["cond"].ToString());
        //            myItem.setConditionNotes(dataReader["conditionnotes"].ToString());
        //            myItem.setReset(dataReader["reset"].ToString());
        //            myItem.setResetNotes(dataReader["resetnotes"].ToString());
        //            myItem.setTested(dataReader["tested"].ToString());
        //            myItem.setTestedNotes(dataReader["testnotes"].ToString());
        //            myItem.setSecondReset(dataReader["secondreset"].ToString());
        //            myItem.setSecondResetNotes(dataReader["secondresetnotes"].ToString());
        //            myItem.setAgentSig(dataReader["agentsig"].ToString());
        //            results.Add(myItem);
        //            break;
        //        }
        //        Console.WriteLine(results[0].getStoreNum());
        //        Console.WriteLine(results[0].getAgentSig());
        //        dataReader.Close();
        //    }
        //    this.CloseConnection();
        //    return results[0];

        //}

        //handles login
        public int login(string username, string password)
        {
            if (dbConn.State != System.Data.ConnectionState.Open)
                this.OpenConnection();
            string query;
            string results = "none";
            query = @"SELECT userid FROM funkyflow.users 
WHERE username='" + username + "' AND password='" + password + "'";
            MySqlCommand cmd = new MySqlCommand(query, dbConn);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                results = dataReader["userid"].ToString();
            }
            if (results != "none")
            {
                Console.WriteLine(results);
                dataReader.Close();
                return (0);
            }
            else
            {
                Console.WriteLine("Not a valid username/password combo!");
                dataReader.Close();
                return (1);
            }
            this.CloseConnection();
        }
    }
}
