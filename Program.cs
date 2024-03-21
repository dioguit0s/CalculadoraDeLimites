using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_Limites_Final
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DECLARAÇÃO DE VARIÁVEL INICIAL
            char EscolhaSobreDivisao;
            int QNTNumerador, QNTDenominador, QNTTermos, ValorX;
            double LimiteEsquerda = 0, LimiteDireita = 0;

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Por Diogo, Leonardo, Ryan e Gustavo");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" _ _ | _   | _  _| _ ._ _ \r\n(_(_||(_|_||(_|(_|(_)| (_|");
            Console.WriteLine("   _| _   |. _ _ ._|_ _  _\r\n  (_|(/_  ||| | || | (/__\\\r\n                          ");
            Console.ResetColor();

            Console.WriteLine(" ");
            Console.WriteLine(" ");

            //LAÇO DE REPETIÇÃO (SE HÁ DIVISÃO OU NÃO)
            do
            { 
                Console.WriteLine("Sua função tem divisão? (S/N)");
                Console.ForegroundColor = ConsoleColor.Green;
                EscolhaSobreDivisao = Char.Parse(Console.ReadLine());
                Console.ResetColor(); //RESETAR PARA BRANCO

                EscolhaSobreDivisao = Char.ToUpper(EscolhaSobreDivisao); //TRANSFORMAR EM MAIÚSCULO

                if (EscolhaSobreDivisao == 'S') //CASO HÁ DIVISÃO
                {


                    Console.Clear(); //APAGAR CONSOLE ANTERIOR


                    //QUANTIDADE DE TERMOS NUMERADOR E DENOMINADOR
                    Console.WriteLine("Quantos termos estão presentes no seu numerador?");
                    Console.ForegroundColor = ConsoleColor.Yellow; //RESPOSTA DO USUARIO = AMARELO
                    QNTNumerador = Int32.Parse(Console.ReadLine());
                    Console.ResetColor(); //RESETAR PARA BRANCO
                    Console.WriteLine("Quantos termos estão presentes no seu denominador?");
                    Console.ForegroundColor = ConsoleColor.Yellow; //RESPOSTA DO USUARIO = AMARELO
                    QNTDenominador = Int32.Parse(Console.ReadLine());
                    Console.ResetColor(); //RESETAR PARA BRANCO


                    //DECLARAÇÃO DOS VETORES (QUANDO TEM DIVISÃO)
                    string[] TermoNumerador = new string[QNTNumerador];
                    string[] OperacaoNumerador = new string[QNTNumerador - 1];
                    string[] TermoDenominador = new string[QNTDenominador];
                    string[] OperacaoDenominador = new string[QNTDenominador - 1];
                    double[] ResultadosNumerador = new double[QNTNumerador];
                    double[] ResultadosDenominador = new double[QNTDenominador];


                    //TELA NUMERADOR
                    Console.Clear(); //APAGAR CONSOLE ANTERIOR
                    Console.WriteLine("Determinando o enumerador...");

                    for (int i = 0; i < QNTNumerador; i++)
                    {
                        //PERGUNTANDO UM TERMO POR VEZ (DO NUMERADOR)
                        Console.WriteLine($"Qual o valor do seu {i + 1}º termo do numerador?");
                        TermoNumerador[i] = Console.ReadLine();

                        //PERGUNTANDO UMA OPERAÇÃO POR VEZ (DO NUMERADOR)
                        if (i != QNTNumerador - 1)
                        {
                            Console.WriteLine($"Qual é a sua {i + 1}ª operação do numerador? ");
                            OperacaoNumerador[i] = Console.ReadLine();
                        }
                    }


                    //TELA DENOMINADOR
                    Console.Clear(); //APAGAR CONSOLE ANTERIOR
                    Console.WriteLine("Passando para o denominador...");

                    for (int u = 0; u < QNTDenominador; u++)
                    {
                        //PERGUNTANDO UM TERMO POR VEZ (DO DENOMINADOR)
                        Console.WriteLine($"Qual é o valor do seu {u + 1}º termo do denominador?");
                        TermoDenominador[u] = Console.ReadLine();

                        //PERGUNTANDO UMA OPERAÇÃO POR VEZ (DO DENOMINADOR)
                        if (u != QNTDenominador - 1)
                        {
                            Console.WriteLine($"Qual é a sua {u + 1}ª operação do denominador? ");
                            OperacaoDenominador[u] = Console.ReadLine();
                        }
                    }




                    //TELA LIMITE
                    Console.Clear(); //APAGAR CONSOLE ANTERIOR

                    Console.WriteLine("Sua função é:");

                    //PRINTAR O NUMERADOR
                    Console.ForegroundColor = ConsoleColor.Blue; //NUMERADOR = AZUL
                    for (int a = 0; a < QNTNumerador; a++)
                    {
                        if (a != QNTNumerador - 1)
                        {
                            Console.Write($"{TermoNumerador[a]}{OperacaoNumerador[a]}");
                        }
                        else
                            Console.Write($"{TermoNumerador[a]}");
                    }
                    Console.ResetColor(); //RESETAR COR PARA BRANCO

                    Console.Write("/"); //LINHA ENTRE NUMERADOR E DENOMINADOR

                    //PRINTAR O DENOMINADOR
                    Console.ForegroundColor = ConsoleColor.Red; //NUMERADOR = VERMELHO
                    for (int a = 0; a < QNTDenominador; a++)
                    {
                        if (a != QNTDenominador - 1)
                        {
                            Console.Write($"{TermoDenominador[a]}{OperacaoDenominador[a]}");
                        }
                        else
                            Console.WriteLine($"{TermoDenominador[a]}");
                    }
                    Console.ResetColor(); //RESETAR COR PARA BRANCO

                    Console.WriteLine(" ");
                    Console.WriteLine(" ");


                    //DETERMINAR VALOR DE X
                    Console.WriteLine("O seu limite tende a que (Valor de x)?");
                    Console.Write(" X = ");
                    Console.ForegroundColor = ConsoleColor.Green; //X = VERDE
                    ValorX = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor (); //RESETAR COR PARA BRANCO



                    Console.WriteLine(" ");
                    Console.WriteLine(" ");



                    //INICIO DOS CÁLCULOS



                    // 1 - SUBSTIUIR OS TERMOS COM X PARA UM NUMERO - NUMERADOR
                    for (int c = 0; c < QNTNumerador; c++)
                    {
                        double ResultadoNumerador = 0;

                        if (TermoNumerador[c].ToLower().IndexOf("x") == -1)
                        {
                            ResultadoNumerador = double.Parse(TermoNumerador[c]);
                        }
                        else
                        {
                            String[] FatoresdeX = TermoNumerador[c].ToLower().Split('x');

                            if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                            {
                                ResultadoNumerador = Math.Pow(ValorX, double.Parse(FatoresdeX[1]));
                                ResultadoNumerador = ResultadoNumerador * double.Parse(FatoresdeX[0]);
                            }
                            else
                                ResultadoNumerador = ValorX * double.Parse(FatoresdeX[0]);
                        }

                        ResultadosNumerador[c] = ResultadoNumerador;

                    }



                    // 2 - SUBSTITUIR OS TERMOS COM X PARA UM NUMERO - DENOMINADOR
                    for (int c = 0; c < QNTDenominador; c++)
                    {
                        double ResultadoDenominador = 0;

                        if (TermoDenominador[c].ToLower().IndexOf("x") == -1)
                        {
                            ResultadoDenominador = double.Parse(TermoDenominador[c]);
                        }
                        else
                        {
                            String[] FatoresdeX = TermoDenominador[c].ToLower().Split('x');

                            if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                            {
                                ResultadoDenominador = Math.Pow(ValorX, double.Parse(FatoresdeX[1]));
                                ResultadoDenominador = ResultadoDenominador * double.Parse(FatoresdeX[0]);
                            }
                            else
                                ResultadoDenominador = ValorX * double.Parse(FatoresdeX[0]);
                        }

                        ResultadosDenominador[c] = ResultadoDenominador;
                    }



                    // 3 - CALCULO NUMERADOR
                    double ResultadoNumerador1 = ResultadosNumerador[0];

                    for (int i = 0; i < ResultadosNumerador.Length - 1; i++)
                    {
                        string Operador = OperacaoNumerador[i];

                        if (Operador == "+" || Operador == "-")
                        {
                            double numero = ResultadosNumerador[i + 1];

                            if (Operador == "+")
                            {
                                ResultadoNumerador1 += numero;
                            }
                            else if (Operador == "-")
                            {
                                ResultadoNumerador1 -= numero;
                            }
                        }
                    }



                    // 4 - CALCULO DENOMINADOR
                    double ResultadoDenominador1 = ResultadosDenominador[0];

                    for (int i = 0; i < ResultadosDenominador.Length - 1; i++)
                    {
                        string operador = OperacaoDenominador[i];

                        if (operador == "+" || operador == "-")
                        {
                            double numero = ResultadosDenominador[i + 1];

                            if (operador == "+")
                                ResultadoDenominador1 += numero;
                            else if (operador == "-")
                                ResultadoDenominador1 -= numero;
                        }
                    }

                    Console.WriteLine(" ");

                    
                    //DETERMINAR O OBSTÁCULO (SE HOUVER)
                    if (ResultadoDenominador1 == 0 && ResultadoNumerador1 == 0)
                    {
                        Console.WriteLine("Obstáculo: 0/0");
                    }
                    else if (ResultadoDenominador1 == 0)
                    {
                        Console.WriteLine("Obstáculo: Denominador = 0");
                    }
                    else
                    {
                        Console.WriteLine("Não há obstaculos.");
                    }

                    Console.WriteLine(" ");

                    //CALCULO DAS TABELAS LATERAIS



                    // 1 - ESQUERDA DO LIMITE LATERAL
                    for (double a = 0.1; a >= 0.00001; a /= 10)
                    {
                        double ValorEsquerda = ValorX - a;

                        // SUBSTITUIÇÃO DO X NO NUMERADOR COM O NOVO X ESQUERDA
                        for (int c = 0; c < QNTNumerador; c++)
                        {
                            double ResultadoNumerador = 0;

                            if (TermoNumerador[c].ToLower().IndexOf("x") == -1)
                            {
                                ResultadoNumerador = double.Parse(TermoNumerador[c]);
                            }
                            else
                            {
                                String[] FatoresdeX = TermoNumerador[c].ToLower().Split('x');

                                if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                                {
                                    ResultadoNumerador = Math.Pow(ValorEsquerda, double.Parse(FatoresdeX[1]));
                                    ResultadoNumerador = ResultadoNumerador * double.Parse(FatoresdeX[0]);
                                }
                                else
                                    ResultadoNumerador = ValorEsquerda * double.Parse(FatoresdeX[0]);
                            }

                            ResultadosNumerador[c] = ResultadoNumerador;
                        }

                        // SUBSTITUIÇÃO DO X NO DENOMINADOR COM O NOVO X ESQUERDA
                        for (int c = 0; c < QNTDenominador; c++)
                        {
                            double ResultadoDenominador = 0;

                            if (TermoDenominador[c].ToLower().IndexOf("x") == -1)
                            {
                                ResultadoDenominador = double.Parse(TermoDenominador[c]);
                            }
                            else
                            {
                                String[] FatoresdeX = TermoDenominador[c].ToLower().Split('x');

                                if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                                {
                                    ResultadoDenominador = Math.Pow(ValorEsquerda, double.Parse(FatoresdeX[1]));
                                    ResultadoDenominador = ResultadoDenominador * double.Parse(FatoresdeX[0]);
                                }
                                else
                                    ResultadoDenominador = ValorEsquerda * double.Parse(FatoresdeX[0]);
                            }

                            ResultadosDenominador[c] = ResultadoDenominador;
                        }

                        // CALCULO DO NUMERADOR COM O NOVO X ESQUERDA
                        ResultadoNumerador1 = ResultadosNumerador[0];

                        for (int i = 0; i < ResultadosNumerador.Length - 1; i++)
                        {
                            string Operador = OperacaoNumerador[i];

                            if (Operador == "+" || Operador == "-")
                            {
                                double numero = ResultadosNumerador[i + 1];

                                if (Operador == "+")
                                {
                                    ResultadoNumerador1 += numero;
                                }
                                else if (Operador == "-")
                                {
                                    ResultadoNumerador1 -= numero;
                                }
                            }
                        }

                        // CALCULO DO DENOMINADOR COM O NOVO X ESQUERDA
                        ResultadoDenominador1 = ResultadosDenominador[0];

                        for (int i = 0; i < ResultadosDenominador.Length - 1; i++)
                        {
                            string operador = OperacaoDenominador[i];

                            if (operador == "+" || operador == "-")
                            {
                                double numero = ResultadosDenominador[i + 1];

                                if (operador == "+")
                                    ResultadoDenominador1 += numero;
                                else if (operador == "-")
                                    ResultadoDenominador1 -= numero;
                            }
                        }

                        LimiteEsquerda = ResultadoNumerador1 / ResultadoDenominador1;

                        // PRINTAR O VALOR ESQUERDO
                        Console.Write($"Se x for {ValorEsquerda}, o valor do limite é: ");
                        Console.ForegroundColor = ConsoleColor.Magenta; // VALOR ESQUERDA = MAGENTA
                        Console.WriteLine($"{LimiteEsquerda}");
                        Console.ResetColor();
                    }


                    Console.WriteLine(" ");


                    // 2 - DIREITA DO LIMITE LATERAL
                    for (double a = 0.1; a >= 0.00001; a /= 10)
                    {
                        double ValorDireita = ValorX + a;

                        // SUBSTITUIÇÃO DO X NO NUMERADOR COM O NOVO X DIREITA
                        for (int c = 0; c < QNTNumerador; c++)
                        {
                            double ResultadoNumerador = 0;

                            if (TermoNumerador[c].ToLower().IndexOf("x") == -1)
                            {
                                ResultadoNumerador = double.Parse(TermoNumerador[c]);
                            }
                            else
                            {
                                String[] FatoresdeX = TermoNumerador[c].ToLower().Split('x');

                                if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                                {
                                    ResultadoNumerador = Math.Pow(ValorDireita, double.Parse(FatoresdeX[1]));
                                    ResultadoNumerador = ResultadoNumerador * double.Parse(FatoresdeX[0]);
                                }
                                else
                                    ResultadoNumerador = ValorDireita * double.Parse(FatoresdeX[0]);
                            }

                            ResultadosNumerador[c] = ResultadoNumerador;
                        }

                        // SUBSTITUIÇÃO DO X NO DENOMINADOR COM O NOVO X DIREITA
                        for (int c = 0; c < QNTDenominador; c++)
                        {
                            double ResultadoDenominador = 0;

                            if (TermoDenominador[c].ToLower().IndexOf("x") == -1)
                            {
                                ResultadoDenominador = double.Parse(TermoDenominador[c]);
                            }
                            else
                            {
                                String[] FatoresdeX = TermoDenominador[c].ToLower().Split('x');

                                if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                                {
                                    ResultadoDenominador = Math.Pow(ValorDireita, double.Parse(FatoresdeX[1]));
                                    ResultadoDenominador = ResultadoDenominador * double.Parse(FatoresdeX[0]);
                                }
                                else
                                    ResultadoDenominador = ValorDireita * double.Parse(FatoresdeX[0]);
                            }

                            ResultadosDenominador[c] = ResultadoDenominador;
                        }

                        // CALCULO DO NUMERADOR COM O NOVO X DIREITA
                        ResultadoNumerador1 = ResultadosNumerador[0];

                        for (int i = 0; i < ResultadosNumerador.Length - 1; i++)
                        {
                            string Operador = OperacaoNumerador[i];

                            if (Operador == "+" || Operador == "-")
                            {
                                double numero = ResultadosNumerador[i + 1];

                                if (Operador == "+")
                                {
                                    ResultadoNumerador1 += numero;
                                }
                                else if (Operador == "-")
                                {
                                    ResultadoNumerador1 -= numero;
                                }
                            }
                        }

                        // CALCULO DO DENOMINADOR COM O NOVO X DIREITA
                        ResultadoDenominador1 = ResultadosDenominador[0];

                        for (int i = 0; i < ResultadosDenominador.Length - 1; i++)
                        {
                            string operador = OperacaoDenominador[i];

                            if (operador == "+" || operador == "-")
                            {
                                double numero = ResultadosDenominador[i + 1];

                                if (operador == "+")
                                    ResultadoDenominador1 += numero;
                                else if (operador == "-")
                                    ResultadoDenominador1 -= numero;
                            }
                        }

                        LimiteDireita = ResultadoNumerador1 / ResultadoDenominador1;

                        // PRINTAR O VALOR DIREITO
                        Console.Write($"Se x for {ValorDireita}, o valor do limite é:");
                        Console.ForegroundColor = ConsoleColor.Cyan; // VALOR DIREITA = CIANO
                        Console.WriteLine(LimiteDireita);
                        Console.ResetColor();
                    }


                    Console.WriteLine(" ");
                    Console.WriteLine(" ");



                    // ANÁLISE DA TABELA
                    LimiteEsquerda = Math.Round(LimiteEsquerda, 1);
                    LimiteDireita = Math.Round(LimiteDireita, 1);

                    if (LimiteEsquerda != LimiteDireita)
                    {
                        Console.WriteLine("Os limites laterais não tendem ao mesmo valor, portanto, não existe um limite para a sua função.");
                    }
                    else
                    {
                        Console.Write($"O valor dos limites laterais se aproximam de: ");
                        Console.ForegroundColor = ConsoleColor.Green; // RESPOSTA = VERDE
                        Console.WriteLine(LimiteEsquerda);
                        Console.ResetColor();
                    }
                }



                // CASO NÃO HÁ DIVISÃO
                else if (EscolhaSobreDivisao == 'N')
                {



                    Console.Clear(); //APAGAR CONSOLE ANTERIOR


                    //QUANTIDADE DE TERMOS DA FUNÇÃO SEM DIVISÃO
                    Console.WriteLine("Quantos termos estão presentes na sua função?");
                    Console.ForegroundColor = ConsoleColor.Yellow; // USUARIO = AMARELO
                    QNTTermos = Int32.Parse(Console.ReadLine());
                    Console.ResetColor();

                    //DECLARAÇÃO DOS VETORES (QUANDO NÃO TEM DIVISÃO)
                    string[] TermosDaNormal = new string[QNTTermos];
                    string[] OperacaoDaNormal = new string[QNTTermos - 1];
                    double[] ResultadosNormal = new double[QNTTermos];

                    Console.Clear(); //APAGAR CONSOLE ANTERIOR

                    for (int i = 0; i < QNTTermos; i++)
                    {
                        //PERGUNTANDO UM TERMO POR VEZ (QUANDO NÃO É DIVISÃO)
                        Console.WriteLine($"Qual o valor do seu {i + 1}º termo do numerador?");
                        Console.ForegroundColor = ConsoleColor.Yellow; // USUARIO = AMARELO
                        TermosDaNormal[i] = Console.ReadLine();
                        Console.ResetColor();

                        //PERGUNTANDO UMA OPERAÇÃO POR VEZ (QUANDO NÃO É DIVISÃO)
                        if (i != QNTTermos - 1)
                        {
                            Console.WriteLine($"Qual é a sua {i + 1}ª operação do numerador? ");
                            Console.ForegroundColor = ConsoleColor.Yellow; // USUARIO = AMARELO
                            OperacaoDaNormal[i] = Console.ReadLine();
                            Console.ResetColor();
                        }
                    }




                    //TELA LIMITE
                    Console.Clear(); //APAGAR CONSOLE ANTERIOR

                    Console.WriteLine("Sua função é:");

                    //PRINTAR A FUNÇÃO NORMAL
                    Console.ForegroundColor = ConsoleColor.Blue;//FUNÇÃO PADRÃO = AZUL
                    for (int a = 0; a < QNTTermos; a++)
                    {
                        if (a != QNTTermos - 1)
                        {
                            Console.Write($"{TermosDaNormal[a]}{OperacaoDaNormal[a]}");
                        }
                        else
                            Console.WriteLine($"{TermosDaNormal[a]}");
                    }
                    Console.ResetColor();


                    Console.WriteLine(" ");
                    Console.WriteLine(" ");


                    //DETERMINAR VALOR DE X
                    Console.WriteLine("O seu limite tende a que (Valor de x)?");
                    Console.Write(" X = ");
                    Console.ForegroundColor = ConsoleColor.Green; //X = VERDE
                    ValorX = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor(); //RESETAR COR PARA BRANCO

                    Console.WriteLine(" ");
                    Console.WriteLine(" ");

                    //INICIO DO CALCULO - FUNÇÃO NORMAL

                    // 1 - SUBSTIUIR OS TERMOS COM X PARA UM NUMERO - FUNÇÃO NORMAL
                    for (int c = 0; c < QNTTermos; c++)
                    {
                        double ResultadoNormal = 0;

                        if (TermosDaNormal[c].ToLower().IndexOf("x") == -1)
                        {
                            ResultadoNormal = double.Parse(TermosDaNormal[c]);
                        }
                        else
                        {
                            String[] FatoresdeX = TermosDaNormal[c].ToLower().Split('x');

                            if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                            {
                                ResultadoNormal = Math.Pow(ValorX, double.Parse(FatoresdeX[1]));
                                ResultadoNormal = ResultadoNormal * double.Parse(FatoresdeX[0]);
                            }
                            else
                                ResultadoNormal = ValorX * double.Parse(FatoresdeX[0]);
                        }

                        ResultadosNormal[c] = ResultadoNormal;

                    }



                    // 2 - CÁLCULO DA FUNÇÃO NORMAL

                    double ResultadoNormal1 = ResultadosNormal[0];

                    for (int i = 0; i < ResultadosNormal.Length - 1; i++)
                    {
                        string Operador = OperacaoDaNormal[i];

                        if (Operador == "+" || Operador == "-")
                        {
                            double numero = ResultadosNormal[i + 1];

                            if (Operador == "+")
                            {
                                ResultadoNormal1 += numero;
                            }
                            else if (Operador == "-")
                            {
                                ResultadoNormal1 -= numero;
                            }
                        }
                    }
                    


                    // 3 - ESQUERDA DO LIMITE LATERAL
                    for (double a = 0.1; a >= 0.00001; a /= 10)
                    {
                        double ValorEsquerda = ValorX - a;

                        // SUBSTITUIÇÃO DO X NO NUMERADOR COM O NOVO X ESQUERDA
                        for (int c = 0; c < QNTTermos; c++)
                        {
                            double ResultadoNormal = 0;

                            if (TermosDaNormal[c].ToLower().IndexOf("x") == -1)
                            {
                                ResultadoNormal = double.Parse(TermosDaNormal[c]);
                            }
                            else
                            {
                                String[] FatoresdeX = TermosDaNormal[c].ToLower().Split('x');

                                if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                                {
                                    ResultadoNormal = Math.Pow(ValorEsquerda, double.Parse(FatoresdeX[1]));
                                    ResultadoNormal = ResultadoNormal * double.Parse(FatoresdeX[0]);
                                }
                                else
                                    ResultadoNormal = ValorEsquerda * double.Parse(FatoresdeX[0]);
                            }

                            ResultadosNormal[c] = ResultadoNormal;
                        }

                        // CALCULO DO NUMERADOR COM O NOVO X ESQUERDA
                        ResultadoNormal1 = ResultadosNormal[0];

                        for (int i = 0; i < ResultadosNormal.Length - 1; i++)
                        {
                            string Operador = OperacaoDaNormal[i];

                            if (Operador == "+" || Operador == "-")
                            {
                                double numero = ResultadosNormal[i + 1];

                                if (Operador == "+")
                                {
                                    ResultadoNormal1 += numero;
                                }
                                else if (Operador == "-")
                                {
                                    ResultadoNormal1 -= numero;
                                }
                            }
                        }

                        LimiteEsquerda = ResultadoNormal1;

                        // PRINTAR O VALOR ESQUERDO
                        Console.Write($"Se x for {ValorEsquerda}, o valor do limite é: ");
                        Console.ForegroundColor = ConsoleColor.Magenta; // VALOR ESQUERDA = MAGENTA
                        Console.WriteLine(LimiteEsquerda);
                        Console.ResetColor();
                    }

                    Console.WriteLine(" ");


                    // 4 - DIREITA DO LIMITE LATERAL
                    for (double a = 0.1; a >= 0.00001; a /= 10)
                    {
                        double ValorDireita = ValorX + a;

                        // SUBSTITUIÇÃO DO X NA NORMAL COM O NOVO X DIREITA
                        for (int c = 0; c < QNTTermos; c++)
                        {
                            double ResultadoNormal = 0;

                            if (TermosDaNormal[c].ToLower().IndexOf("x") == -1)
                            {
                                ResultadoNormal = double.Parse(TermosDaNormal[c]);
                            }
                            else
                            {
                                String[] FatoresdeX = TermosDaNormal[c].ToLower().Split('x');

                                if (FatoresdeX.Length == 2 && FatoresdeX[1] != "")
                                {
                                    ResultadoNormal = Math.Pow(ValorDireita, double.Parse(FatoresdeX[1]));
                                    ResultadoNormal = ResultadoNormal * double.Parse(FatoresdeX[0]);
                                }
                                else
                                    ResultadoNormal = ValorDireita * double.Parse(FatoresdeX[0]);
                            }

                            ResultadosNormal[c] = ResultadoNormal;
                        }

                        // CALCULO DO NUMERADOR COM O NOVO X ESQUERDA
                        ResultadoNormal1 = ResultadosNormal[0];

                        for (int i = 0; i < ResultadosNormal.Length - 1; i++)
                        {
                            string Operador = OperacaoDaNormal[i];

                            if (Operador == "+" || Operador == "-")
                            {
                                double numero = ResultadosNormal[i + 1];

                                if (Operador == "+")
                                {
                                    ResultadoNormal1 += numero;
                                }
                                else if (Operador == "-")
                                {
                                    ResultadoNormal1 -= numero;
                                }
                            }
                        }

                        LimiteDireita = ResultadoNormal1;

                        // PRINTAR O VALOR DIREITO
                        Console.Write($"Se x for {ValorDireita}, o valor do limite é:");
                        Console.ForegroundColor = ConsoleColor.Cyan; // VALOR DIREITA = CIANO
                        Console.WriteLine(LimiteDireita);
                        Console.ResetColor();
                    }

                    Console.WriteLine(" ");
                    Console.WriteLine(" ");


                    // ANÁLISE DA TABELA
                    LimiteEsquerda = Math.Round(LimiteEsquerda, 1);
                    LimiteDireita = Math.Round(LimiteDireita, 1);

                    if (LimiteEsquerda != LimiteDireita)
                    {
                        Console.WriteLine("Os limites laterais não tendem ao mesmo valor, portanto, não existe um limite para a sua função.");
                    }
                    else
                    {
                        Console.Write($"O valor dos limites laterais se aproximam de: ");
                        Console.ForegroundColor = ConsoleColor.Green; // RESPOSTA = VERDE
                        Console.WriteLine(LimiteEsquerda);
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("Escolha inválida! Insira novamente.");
                }
            }
            while (EscolhaSobreDivisao != 'N' && EscolhaSobreDivisao != 'S');

            Console.ReadKey();
        }

    }
}
