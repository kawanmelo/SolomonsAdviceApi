using System;
using System.Data.SqlClient;
using SolomonsAdviceApi.SolomonAdviceClass;

namespace SolomonsAdviceApi.Repository.CreateObject{
    public interface ICreateSolomonAdvice{
        public SolomonAdvice Create(int Id, string Advice, string Reference);
    }
}