namespace Revisao
{
    public class Aluno
    {
        private decimal nota;
        private string nome;

        public Aluno(string nome, decimal nota){
            this.nome = nome;
            this.nota = nota;
        }

        public string Nome{
            get{return nome;}
            set{nome = value;}
        }

        public decimal Nota{
            get{return nota;}
            set{nota = value;}
        }
    }
}