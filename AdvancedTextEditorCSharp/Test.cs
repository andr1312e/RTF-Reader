using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mytest
{
    public class Test
    {
        string question;
        string[] answers = new string[4];
        int rightAnswer = -1;
        Test()
        {

        }
        Test(string question, string[] answers, int rightAnswer)
        {

        }
        public void mixAnswers()
        {
            Random rand = new Random();
            List<int> index = Enumerable.Range(0, 4).ToList();
            string[] copy = new string[4];
            bool notAnswer = true;
            for (int i = 0; i < 4; i++)
            {
                int num = rand.Next(index.Count);              
                copy[i] = answers[index[num]];
                if (index[num] == rightAnswer && notAnswer == true)
                {
                    rightAnswer = i;
                    notAnswer = false;
                }
                index.Remove(index[num]);
            }
            answers = copy;
        }
        public bool check(int ans)
        {
            if (ans == rightAnswer)
                return true;
            return false;
        }
        public string getQuestion()
        {
            return question;
        }
        public string getAnswer(int ans)
        {
            return answers[ans];
        }
        public static List<Test> openTests(string path)
        {
            List<Test> list = new List<Test>();
            try
            {
                var file = File.OpenRead(path);              
                StreamReader reader = new StreamReader(file);
                while (reader.EndOfStream != true)
                {
                    string tmp = reader.ReadLine();
                    if (tmp.Length == 0)
                        continue;
                    //read question
                    string num = tmp[0].ToString();
                    try
                    {
                        Convert.ToInt32(num);
                        Test t = new Test();
                        t.question = tmp;
                        //read 4 answers
                        for (int i = 0; i < 4; i++)
                        {
                            string s = reader.ReadLine();
                            if (s.Length == 0)
                            {
                                i--;
                                continue;
                            }
                            //if this is true answer
                            else if (s == "#ttt")
                            {
                                t.rightAnswer = i - 1;
                                i--;
                            }
                            else
                            {                             
                                t.answers[i] = s.Substring(2);
                            }
                        }
                        if (t.rightAnswer == -1)
                        {
                            t.rightAnswer = 3;
                            string key = reader.ReadLine();
                        }
                        list.Add(t);
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Тест не найден");
            }
            return list;
        }
    }
}
