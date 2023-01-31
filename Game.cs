 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdleGameThread
{
    public class Game
    {
        double taxa = 0;
        double lucroDoacao, dinheiro;
        double precoDoacao = 5;
        int qntdDoacao = 0;
        double precoMulti = 10;
        double clickMulti = 1;
        int qntdMulti = 0;
        ConsoleKeyInfo tecla = new();
        public Game() { }

        public void Click()
        {
            while (true)
            {
                tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.K)
                {
                    if (qntdMulti == 0)
                    {
                        dinheiro += 1;
                    }
                    else
                    {
                        dinheiro += clickMulti * 1 / qntdMulti;
                    }
                }

                else if (tecla.Key == ConsoleKey.D && dinheiro >= precoDoacao)
                {
                    dinheiro -= precoDoacao;
                    qntdDoacao += 1;
                    precoDoacao += 5 * taxa;
                    taxa += 0.1 * qntdDoacao;
                    lucroDoacao += taxa;
                }

                else if (tecla.Key == ConsoleKey.M && dinheiro >= precoMulti)
                {
                    dinheiro -= precoMulti;
                    qntdMulti += 1;
                    precoMulti += 10 * taxa;
                    taxa += 0.05 * qntdMulti;
                    clickMulti += taxa / 5;
                }
            }
        }

        public void Farm()
        {
            while(true)
            {
                dinheiro += lucroDoacao;
                Thread.Sleep(1000);
            }
        }

        public void Hud()
        {
            while (true)
            {
                string hud = $"""
                                  IDLE GAME 

                     Pressione 'k' para ganhar dinheiro
                     Pressione 'm' para multiplicar o dinheiro K
                     Pressione 'd' para aumentar a doação

                     {qntdMulti} multiplicador(es) aumentando {Math.Round(clickMulti, 2)} vezes
                     {qntdDoacao} doação(ões) recebendo {lucroDoacao.ToString("C")} reais

                     Você possui {dinheiro.ToString("C")} reais
                    """;
                Console.WriteLine(hud);
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }

}
