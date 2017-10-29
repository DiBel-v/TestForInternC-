using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondTry
{
    class MyTask
    {
        public int iterator;
      
        public static void Main(string[] args)
        {
            MyTask mt = new MyTask();
            //Ведет подсчет '?' в строке
            int amount = 0;
            int count = 0;
            //Создаем словарь и заполняем его
            Dictionary<string, char> words = new Dictionary<string, char>(26);
            words.Add(".", 'E');
            words.Add("-", 'T');
            words.Add("..", 'I');
            words.Add(".-", 'A');
            words.Add("-.", 'N');
            words.Add("--", 'M');
            words.Add("...", 'S');
            words.Add("..-", 'U');
            words.Add(".-.", 'R');
            words.Add(".--", 'W');
            words.Add("-..", 'D');
            words.Add("-.-", 'K');
            words.Add("....", 'H');
            words.Add("...-", 'V');
            words.Add("..-.", 'F');
            words.Add(".-..", 'L');
            words.Add(".--.", 'P');
            words.Add(".---", 'J');
            words.Add("-...", 'B');
            words.Add("-..-", 'X');
            words.Add("-.-.", 'C');
            words.Add("-.--", 'Y');
            words.Add("--..", 'Z');
            words.Add("--.-", 'Q');

        //Проверка на вхождение символа '?' в строке
        WriteString:
            string line = Console.ReadLine();
            for (int j = 0; j < line.Length; j++)
            {
                if ((line[j] != '-') && (line[j] != '.') && (line[j] != '?') && (line.Length > 4))
                {
                    Console.WriteLine("Данная страка не отвечает требованиям, попробуйте ввести строку заново: ");
                    goto WriteString;
                }
            }
            if (line.Contains("?"))
            {
                //Создаем промежуточные переменные
                string line1 = line;
                string line2 = line;
                string line3 = line;
                string line4 = line;
               
                //Записываем в переменную amount кол-во '?' в строке, чтобы в дальнейшем выполнялось нужное условие
                foreach (char symbol in line)
                {
                    if (symbol == '?')
                        amount += 1;
                }
                for (int i = 0; i < line.Length; i++)
                {
                    //Если присутствует символ '?', то меняем его либо на '.', либо на '-'
                    if (line[i] == '?')
                    {
                        //count нужен для подсчета, какой по счету идет ? в строке
                        count += 1;
                        //Выполняем данное условие, при одном знаке '?' в строке
                        if (amount == 1)
                        {
                            line1 = line1.Remove(i, 1);
                            line1 = line1.Insert(i, ".");
                            mt.checkWord(line1, words);
                            line1 = line1.Remove(i, 1);
                            line1 = line1.Insert(i, "-");
                            mt.checkWord(line1, words);
                        }

                        //Выполняем данное условие, при двух знаках '?' в строке
                        if (amount == 2)
                        {
                            line1 = line1.Remove(i, 1);
                            line1 = line1.Insert(i, ".");
                            mt.checkWord(line1, words);
                            line1 = line1.Remove(i, 1);
                            line1 = line1.Insert(i, "-");
                            mt.checkWord(line1, words);

                            line2 = line2.Remove(i, 1);
                            line2 = line2.Insert(i, "-");
                            mt.checkWord(line2, words);
                            line2 = line2.Remove(i, 1);
                            line2 = line2.Insert(i, ".");
                            mt.checkWord(line2, words);

                        }

                        //Выполняем данное условие, при трех знаках '?' в строке
                        if (amount == 3)
                        {
                            line1 = line1.Remove(i, 1);
                            line1 = line1.Insert(i, ".");
                            mt.checkWord(line1, words);
                            if (count == 2)
                            {
                                line3 = line1;
                            }
                            line1 = line1.Remove(i, 1);
                            line1 = line1.Insert(i, "-");
                            mt.checkWord(line1, words);


                            line2 = line2.Remove(i, 1);
                            line2 = line2.Insert(i, "-");
                            mt.checkWord(line2, words);
                            if(count == 2)
                            {
                                line4 = line2;
                            }
                            line2 = line2.Remove(i, 1);
                            line2 = line2.Insert(i, ".");
                            mt.checkWord(line2, words);
                            if (count == 3)
                            {
                                line3 = line3.Remove(i, 1);
                                line3 = line3.Insert(i, ".");
                                mt.checkWord(line3, words);
                                line3 = line3.Remove(i, 1);
                                line3 = line3.Insert(i, "-");
                                mt.checkWord(line3, words);

                                line4 = line4.Remove(i, 1);
                                line4 = line4.Insert(i, ".");
                                mt.checkWord(line4, words);
                                line4 = line4.Remove(i, 1);
                                line4 = line4.Insert(i, "-");
                                mt.checkWord(line4, words);
                            }
                        }

                        //Выполняем данное условие, при четырех знаках '?' в строке, данное условие будет исключением, можно воспользоваться перебором
                        if (amount == 4)
                        {
                            mt.checkWord("....", words);
                            mt.checkWord("...-", words);
                            mt.checkWord("..-.", words);
                            mt.checkWord("..--", words);
                            mt.checkWord(".-..", words);
                            mt.checkWord(".-.-", words);
                            mt.checkWord(".--.", words);
                            mt.checkWord(".---", words);
                            mt.checkWord("-...", words);
                            mt.checkWord("-..-", words);
                            mt.checkWord("-.-.", words);
                            mt.checkWord("-.--", words);
                            mt.checkWord("--..", words);
                            mt.checkWord("--.-", words);
                            mt.checkWord("---.", words);
                            mt.checkWord("----", words);

                        }
                    }

                }
                //Если в строке нет знаков '?', то просто отправляем в метод checkWord строку
            } else { mt.checkWord(line, words); }
            Console.ReadKey();
            
        }

        char[] arr = new char[16];

        //В метод подается сравниваемая строка и словарь, данная строка проверяет есть ли в словаре нужный нам ключ, если есть, то записываем в массив значение этого ключа
        public void checkWord(string inline, Dictionary<string, char> words)
        {
            foreach (KeyValuePair<string, char> keyValue in words)
            {
                if (inline == keyValue.Key)
                {
                    arr[iterator] = keyValue.Value;
                    Console.Write(arr[iterator]);
                    break;
                }
            }
            iterator++;
        }
    }
}
