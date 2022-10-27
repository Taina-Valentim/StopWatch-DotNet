using System;
using System.Threading;

namespace StopWatch{
    class Program{
        static void Main(string[] args){
            Menu();
        }

        static void PreStart(){
            Console.Clear();
            Console.WriteLine("Ready...");
            Thread.Sleep(1000);
            Console.WriteLine("Set...");
            Thread.Sleep(1000);
            Console.WriteLine("Go!!!");
            Thread.Sleep(2000);
        }

        static void Menu(){
            Console.Clear();
            Console.WriteLine("S = Segundos => 10s = 10 segundos");
            Console.WriteLine("M = Minutos => 1m = 1 minuto");
            Console.WriteLine("H = Horas => 2h = 2 horas");
            Console.WriteLine("0 = Sair");
            Console.WriteLine("Digite o tempo desejado:");
            string valor = Console.ReadLine().ToLower();
            char tipo = char.Parse(valor.Substring(valor.Length-1,1));
            int tempo = 0;
            if(valor != "0")
                tempo = int.Parse(valor.Substring(0, valor.Length-1));
            switch(tipo){
                case 's':
                    Start(0, 0, tempo);
                    break;
                case 'm':
                    Start(0, tempo, 0);
                    break;
                case 'h':
                    Start(tempo, 0, 0);
                    break;
                case '0':
                    System.Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }
        }
        static void Start(int horaLimite, int minutoLimite, int segundoLimite){
            PreStart();
            var segundoAtual = 0;
            var minutoAtual = 0;
            var horaAtual = 0;
            var tempoEsgotado = false;
            while(!tempoEsgotado){
                Console.Clear();
                if(segundoAtual == 60){
                    minutoAtual++;
                    segundoAtual = 0;
                }
                if( minutoAtual == 60){
                    horaAtual++;
                    minutoAtual = 0;
                }
                tempoEsgotado = (horaAtual == horaLimite) && (minutoAtual == minutoLimite) && (segundoAtual == segundoLimite);
                string str = $"";
                if(horaAtual < 10)
                    str += $"0{horaAtual} : ";
                else
                    str += $"{horaAtual} : ";

                if(minutoAtual < 10)
                    str += $"0{minutoAtual} : ";
                else
                    str += $"{minutoAtual} : ";

                if(segundoAtual < 10)
                    str += $"0{segundoAtual}";
                else
                    str += $"{segundoAtual}";

                Console.WriteLine($"{str}");
                Thread.Sleep(1000);
                segundoAtual++;
                
            }
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Stopwatch finalizado!");
        }
    }
}