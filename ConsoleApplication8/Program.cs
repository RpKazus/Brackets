using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        public static int GetTeamType(char ch)
        {
            if (ch == '{' || ch == '}')
                return 1;
            else if (ch == '[' || ch == ']')
                return 2;
            else if (ch == '(' || ch == ')')
                return 3;
            else if (ch == '<' || ch == '>')
                return 4;
            return 0;
        }
        public static void ColorWriteLine(string str,ConsoleColor c1)
        {
            Console.ForegroundColor = c1;
            Console.WriteLine(str);
            Console.ResetColor();
        }
        public static int GetDirection(char ch)
        {
            if (ch == '{' || ch == '(' || ch == '[' || ch == '<')
                return 1;
            if (ch == '}' || ch == ')' || ch == ']' || ch == '>')
                return 2;
            return 0;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите скобки: ");
                string brackets = Console.ReadLine();
                int sqtr = 0, round = 0, curly = 0, bird = 0;
                //Console.WriteLine(brackets);
                bool isTrue = true;
                char lastChar = '{';
                if (brackets != "")
                    foreach (char ch in brackets)
                    {

                        switch (ch)
                        {
                            case '[':
                                sqtr++;
                                break;
                            case ']':
                                sqtr--;
                                break;
                            case '{':
                                curly++;
                                break;
                            case '}':
                                curly--;
                                break;
                            case '(':
                                round++;
                                break;
                            case ')':
                                round--;
                                break;
                            case '<':
                                bird++;
                                break;
                            case '>':
                                bird--;
                                break;
                        }
                        if (sqtr < 0 || curly < 0 || round < 0 || bird < 0)
                        {
                            ColorWriteLine("Скобки расставлены не верно!", ConsoleColor.Red);
                            isTrue = false;
                        }
                        else if ((GetTeamType(lastChar) != GetTeamType(ch)) && GetDirection(lastChar) == 1 && GetDirection(ch) == 2)
                        {
                            ColorWriteLine("Скобки расставлены не верно! ", ConsoleColor.Red);
                            isTrue = false;
                        }
                        lastChar = ch;
                    }
                else
                    ColorWriteLine("Строчка пуста!",ConsoleColor.Red);
                if(isTrue)
                    if (sqtr == 0 && curly == 0 && round == 0 && bird == 0)
                        ColorWriteLine("Все скобки расставлены верно!", ConsoleColor.Green);
                    else
                        ColorWriteLine("Скобки расставлены не верно!", ConsoleColor.Red);
                Console.ReadLine();
            }
        }
    }
}
