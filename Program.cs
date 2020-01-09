using System;

namespace Revisao
{
    class Program
    {
        enum Grau {
            F, D, C, B, A
        }
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            short indiceAluno = 0;
            string opcaoUsuario = "";
            
            while(opcaoUsuario.ToUpper() != "X"){

                switch(opcaoUsuario){
                    case "1":
                        Aluno a;
                        decimal nota;
                        string nome;

                        Console.WriteLine("Informe o nome do aluno:");
                        nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        if(decimal.TryParse(Console.ReadLine(), out nota)){
                            a = new Aluno(nome, nota);
                            alunos[indiceAluno] = a;
                            indiceAluno++;
                        }
                        else
                            throw new ArgumentOutOfRangeException("Valor inválido!");                        
                        break;
                    case "2":
                        foreach(Aluno aluno in alunos){
                            if(aluno != null)
                                Console.WriteLine($"Aluno: {aluno.Nome} - Nota: {aluno.Nota}\n");
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        int nrAlunos = indiceAluno;
                        for(int i = 0; i < indiceAluno; i++){
                            notaTotal += alunos[i].Nota;
                        }
                        decimal mediaGeral = notaTotal / nrAlunos;
                        
                        Grau g = mediaGeral < 3 ? Grau.F :
                                 mediaGeral < 5 ? Grau.D :
                                 mediaGeral < 7 ? Grau.C :
                                 mediaGeral < 9 ? Grau.B :
                                 Grau.A;

                        Console.WriteLine($"Média geral das notas: {mediaGeral}");
                        
                        string respostaFinal = "";
                        switch(g){
                            case Grau.F:
                                respostaFinal = "Essa sala é horrível!";
                                break;
                            case Grau.D:
                                respostaFinal = "Essa sala está ruim...";
                                break;
                            case Grau.C:
                                respostaFinal = "A sala está na média.";
                                break;
                            case Grau.B:
                                respostaFinal = "Essa sala é boa :)";
                                break;
                            case Grau.A:
                                respostaFinal = "Essa sala é a melhor da escola!";
                                break;
                        }
                        
                        Console.WriteLine($"\n{respostaFinal}");
                        
                        break;
                    default:
                        if(opcaoUsuario != "")
                            throw new ArgumentOutOfRangeException(
                                "Convém usar as opção designadas no menu."
                            );
                        break;
                }

                Console.WriteLine("Informe a opção desejada:"
                    +"\n1 - Inserir novo aluno"
                    +"\n2 - Listar alunos"
                    +"\n3 - Calcular média geral"
                    +"\nX - Sair"
                );

                opcaoUsuario = Console.ReadLine();
            }
        }
    }
}
