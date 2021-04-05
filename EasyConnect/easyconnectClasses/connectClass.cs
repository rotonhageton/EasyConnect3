using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyConnect.easyconnectClasses
{
    class ConnectClass
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender  { get; set; }

        static string myconnectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;


        public DataTable Select()
        {
            ///Krok 1: Połączenie bazy
            SqlConnection conn = new SqlConnection(myconnectionString);
            DataTable dt = new DataTable();
            try
            {
                //Krok 2: Tworzenie zapytania SQL
                string sql = "SELECT * FROM Table_Contact";

                //Tworzenie cmd przy użyciu sql i conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Tworzenie SQL DataAdapter przy użyciu cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        /// <summary>
        /// //Wstawianie danych do bazy danych
        /// </summary>
        /// <param name="c"></param>
        /// <returns>isSuccess</returns>
        //Wstawianie danych do bazy danych
        public bool Insert (ConnectClass c)
        {
            //Tworzenie domyślnej intrukcji powrotu i ustawienie jej wartości na fałsz
            bool isSucces = false;

            //Krok 1: Połączenie bazy danych
            SqlConnection conn = new SqlConnection(myconnectionString);
            try
            {
                //Krok 2: Tworzenie zapytania SQL aby wstawic dane
                string sql = "INSERT INTO Table_Contact (FirstName, LastName, ContactNo, Address, Gender) VALUES (@FirstName, @LastName, @ContactNo, @Address, @Gender)";

                //Tworzenie komendy SQL przy użyciu sql i conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Tworzenie parametrów
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                //Otwarte połączenie z bazą danych
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //Jeżeli zapytanie będzie prawdziwe to wartość bedzie wieksza od 0, w przeciwnym wypadku wartosc bedzie 0.
                if (rows > 0)
                {
                    isSucces = true;
                }
                else
                {
                    isSucces = false;
                }
            }
            catch(Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSucces;
        }

        /// <summary>
        /// //Metoda do aktualizowania danych w naszej bazie.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>isSuccess</returns>

        public bool Update(ConnectClass c)
        {
            //Tworzenie domyślnej intrukcji powrotu i ustawienie jej wartości na fałsz
            bool isSuccess = false;

            //Krok 1: Połączenie bazy danych
            SqlConnection conn = new SqlConnection(myconnectionString);
            try
            {
                //Tworzenie zapytania SQL do aktualizacji danych w bazie
                string sql = "UPDATE Table_Contact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";

                //Tworzenie komendy SQL
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Tworzenie parametrów w celu dodania wartości
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //Otwarte połączenie z bazą danych
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //Jeżeli zapytanie będzie prawdziwe to wartość bedzie wieksza od 0, w przeciwnym wypadku wartosc bedzie 0.
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        /// <summary>
        /// //Metoda do usuwania danych z bazy danych.
        /// </summary>
        /// <param name="c"></param>
        /// <returns>isSuccess</returns>
        public bool Delete(ConnectClass c)
        {
            //Tworzenie domyślnej intrukcji powrotu i ustawienie jej wartości na fałsz
            bool isSuccess = false;

            //Krok 1: Połączenie bazy danych
            SqlConnection conn = new SqlConnection(myconnectionString);
            try
            {
                //Tworzenie zapytania SQL do usuwania danych w bazie
                string sql = "DELETE FROM Table_Contact WHERE ContactID=@ContactID";

                //Tworzenie komendy SQL
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Tworzenie parametrów w celu dodania wartości
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //Otwarte połączenie z bazą danych
                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                //Jeżeli zapytanie będzie prawdziwe to wartość bedzie wieksza od 0, w przeciwnym wypadku wartosc bedzie 0.
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
