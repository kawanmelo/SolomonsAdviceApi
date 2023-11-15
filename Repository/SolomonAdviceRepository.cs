using Microsoft.VisualBasic;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient
;
namespace SolomonsAdviceApi.Repository{
    public  class SolomonAdviceRepository{
        public  List<SolomonAdvice> ProverbsBank = new List<SolomonAdvice>();

        public SolomonAdviceRepository(){
            SolomonAdvice solomonAdvice01 = new SolomonAdvice("Proverbs 9 '8", "Não repreenda o zombador, caso contrário ele o odiará; repreenda o sábio, e ele o amará.", 1);
            SolomonAdvice solomonAdvice02 = new SolomonAdvice("", "Se você for sábio, o benefício será seu; se for zombador, sofrerá as conseqüências.", 2);
            SolomonAdvice solomonAdvice03 = new SolomonAdvice("Proverbs 15 '14", "O coração do inteligente busca o conhecimento; mas a boca dos tolos se apascenta de estultícia.", 3);
            ProverbsBank.Add(solomonAdvice01);
            ProverbsBank.Add(solomonAdvice02);
            ProverbsBank.Add(solomonAdvice03);
        }
        public string ConsumeDataProverbsBank(string SqlQuery){
            string connectionString =  "Data Source=localhost;Initial Catalog=ProverbsDataBank;User ID=sa;Password=SQLmelo.cs;Integrated Security=False;";;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string result="";
                using (SqlCommand command = new SqlCommand(SqlQuery, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = (reader.GetString(0) + "," + reader.GetString(1));
                    }
                    return result;
                }
            }
        }
    }
}