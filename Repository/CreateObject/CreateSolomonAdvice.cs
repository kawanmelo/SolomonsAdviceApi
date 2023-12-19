using System;
using System.Data.SqlClient;
using SolomonsAdviceApi.SolomonAdviceClass;

namespace SolomonsAdviceApi.Repository.CreateObject{
    public class CreateSolomonAdvice:ICreateObject{
        public SolomonAdvice Create(int Id, string Advice, string Reference){
            try{
                SolomonAdvice solomonAdvice = new SolomonAdvice(Id, Advice, Reference);
                return solomonAdvice;
            }catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}