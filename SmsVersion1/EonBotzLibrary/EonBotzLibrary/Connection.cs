using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace EonBotzLibrary
{
    public class Connection
    {
          public  MySqlConnection conn;
          public  MySqlCommand cmd;
          public MySqlDataReader dr;
          public string res;
          

        public MySqlConnection getcon()
        {
            //conn = new MySqlConnection("server=192.168.0.100; user id=drpsms; password=eonbotz2016!a;database=smsdb;port=3306");
            conn = new MySqlConnection("server=192.168.1.3;user id=smsadmin; password=SmsEonbotz2016!;database=smsdb;port=3306");
            //conn = new MySqlConnection("server=localhost;user id=root; password=;database=smsdb;port=3306");

            return conn;
        }

        public MySqlConnection getconn()
        {

            StreamReader sr = new StreamReader("C:\\Users\\chevy\\Desktop\\Randel\\demo\\SmsVersion1\\ip.txt");
            string line = sr.ReadLine();
            sr.Close();

            //conn = new MySqlConnection("server=192.168.0.100; user id=drpsms; password=eonbotz2016!a;database=smsdb;port=3306");
            conn = new MySqlConnection("server=192.168.1.3;user id=smsadmin; password=SmsEonbotz2016!;database=bseddb;port=3306");
            //conn = new MySqlConnection("server=localhost;user id=root; password=;database=smsdb;port=3306");

            return conn;
        }



    }
}
