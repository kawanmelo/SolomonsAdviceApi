namespace SolomonsAdviceApi.SolomonAdviceClass{
    public class SolomonAdvice{
        public int Id{
            get; set;
        }
        public string Advice{
            get; set;
        }
        public string Reference{
            get; set;
        }

        public SolomonAdvice(int Id, string Advice, string Reference){
            this.Advice = Advice;
            this.Reference = Reference;
            this.Id = Id;
        }
    }
}