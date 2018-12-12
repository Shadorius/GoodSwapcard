using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connexion
    {
        private readonly string Cnstr = @"Data Source=PORTABLE-AXEL;Initial Catalog=GoodSwapCardDB;Persist Security Info=True;User ID=sa;Password=tftic@2012";
        //private readonly string Cnstr = @"Data Source=PREDATOR;Initial Catalog = GoodSwapCardDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        //private readonly string Cnstr = @"Data Source=DESKTOP-BK95MHE\SQLEXPRESS;Initial Catalog=GoodSwapCardDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private SqlConnection oConn;
        private SqlCommand oCmd;

        public bool Connect()
        {
            try
            {
                oConn = new SqlConnection(Cnstr);
                oConn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Disconnect()
        {
            try
            {
                oConn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert(String Query)
        {
            if (Connect())
            {
                oCmd = oConn.CreateCommand();
                oCmd.CommandText = Query;
                bool test;
                try
                {
                    oCmd.ExecuteNonQuery();

                    test = true;
                }
                catch (Exception)
                {
                    test = false;
                }
                Disconnect();
                return test;
            }
            return false;
        }
        public bool Update(String Query)
        {
            if (Connect())
            {
                oCmd = oConn.CreateCommand();
                oCmd.CommandText = Query;
                bool test;
                try
                {
                    oCmd.ExecuteNonQuery();

                    test = true;
                }
                catch (Exception)
                {
                    test = false;
                }
                Disconnect();
                return test;
            }
            return false;
        }
        public List<Dictionary<string, object>> getData(string Query)
        {
            if (Connect())
            {
                SqlDataReader oDr;
                oCmd = oConn.CreateCommand();
                oCmd.CommandText = Query;  //Query = "Select * from...."
                List<Dictionary<string, object>> Enregistrements = new List<Dictionary<string, object>>();
                try
                {
                    oDr = oCmd.ExecuteReader();
                    while (oDr.Read())
                    {
                        //Pour récupérer soit 
                        // oDr[0] ==> 1er champs en tant qu'objet
                        //oDr["id"]==> Champs colonne id en tant qu'objet
                        //oDr.GetInt32(0)==> Premier champs en tant qu'Int
                        // string NomCol = oDr.GetName(0);==> nom de la première colonne
                        //int nbChamps = oDr.FieldCount;==> Nombre de colonne
                        //oDr.HasRows ==> Y'a-t-il des résultats ?
                        Dictionary<string, object> Row = new Dictionary<string, object>();
                        for (int i = 0; i < oDr.FieldCount; i++)
                        {
                            string Key = oDr.GetName(i);
                            object Value = oDr[i];
                            Row.Add(Key, Value);

                        }
                        Enregistrements.Add(Row);
                    }
                    oDr.Close();
                }
                catch (Exception)
                {

                    //throw;
                }
                Disconnect();

                return Enregistrements;
            }
            return null;
        }
        public bool Delete(string Query)
        {
            bool isOk = false;
            if (Connect())
            {
                oCmd = oConn.CreateCommand();
                oCmd.CommandText = Query;
                try
                {
                    oCmd.ExecuteNonQuery();
                    isOk = true;
                }
                catch (Exception)
                {
                    isOk = false;
                }
                Disconnect();
            }
            return isOk;
        }
    }
}
