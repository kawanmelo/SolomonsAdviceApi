using System;

namespace MeloSolution.Repository.CUD{
    public interface ICud{
        public bool CudObject(string sqlQuery, object parameters = null);
    }
}