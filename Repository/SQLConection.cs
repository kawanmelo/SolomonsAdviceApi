using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class SqlConnectionBank{
  public static void ConectProverbsBank(){
    try{
        string connetionString;
        SqlConnection cnn;
        connetionString = "Data Source=localhost;Initial Catalog=ProverbsDataBank;";
        cnn = new SqlConnection(connetionString);
        cnn.Open();
    }
    catch (SqlException erro){

    }
  }
}

