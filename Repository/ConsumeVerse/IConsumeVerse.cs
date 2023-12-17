using System;
using SolomonsAdviceApi.SolomonAdviceClass;
using System.Data.SqlClient;

namespace SolomonsAdviceApi.Repository.Consume{
    public interface IConsumeVerse{
        public SolomonAdvice ConsumeUniqueVerse(string sqlQuery, object parameters = null);
        public List<SolomonAdvice> ConsumeMutipleVerse(string sqlQuery, object parameters = null);
    }
}