using System;
using System.Data.SqlClient;
using SolomonsAdviceApi.SolomonAdviceClass;

namespace SolomonsAdviceApi.Repository.CreateObject{
    public interface ICreateObject{
        public SolomonAdvice Create(int Id, string Advice, string Reference);
    }
}