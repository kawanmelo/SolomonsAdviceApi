using System;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient;

namespace SolomonsAdviceApi.Repository.Consume{
    public interface IConsumeData{
        public string ConsumeInfo(string sqlQuery, object parameters = null);
        public int ConsumeInfoInteger(string sqlQuery, object parameters = null);
    }
}