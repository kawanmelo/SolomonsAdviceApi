using System;
using System.Data.SqlClient;
using MeloSolution.SolomonsAdviceApi.Entities;

namespace MeloSolution.SolomonsAdviceApi.Repository{
    public class CreateSolomonAdvice{
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