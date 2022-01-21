using System;

namespace Palavras
{
    class Program
    {
        static Random random = new Random();
        static string[] lines = System.IO.File.ReadAllLines("./Lista-de-Palavras.txt");
        static string palavra = "CABINE";
        static List<string> chutes = new List<string>();
        static void Main(string[] args) {

            Console.Clear();
            Console.WriteLine("");

            palavra = SortearPalavra();

            while (true) {
                
                Console.ForegroundColor = ConsoleColor.White;

                if (chutes.Count == 6){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("VOCÊ PERDEU!!! A PALAVRA ERA " + palavra);
                    break;
                }
                
                var chute = Console.ReadLine();

                if (lines.Contains<string>(chute))
                {
                    if (chute.Length == palavra.Length)
                    {
                        if (chute == palavra)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("VOCÊ GANHOU!!!");
                            break;

                        } else {
                            chutes.Add(chute);
                        }

                    } else {
                        Desenhar();
                        Console.WriteLine("Tem que ter o mesmo tamanho");
                    }

                } else {
                    Desenhar();
                    Console.WriteLine("Palavras que existam");
                }
                
                Desenhar();
            }
        }
        static string SortearPalavra()
            {
                while (true){
                    var palavra = lines[random.Next(0, lines.Length)];
                    if (palavra.Length == 6 && !palavra.Contains('-')){
                        return palavra;
                    }
                } 
            }

        static void Desenhar(){
            Console.Clear();

            foreach(string chute in chutes)
            {
                for(int i = 0; i < palavra.Length; i++)
                {
                    if (palavra.Contains(chute[i]))
                    {
                        if (chute[i] == palavra[i]){
                            Console.ForegroundColor = ConsoleColor.Green;
                        } else {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                    } else {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.Write(chute[i]);   
                }

                Console.WriteLine();
            }
            
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}