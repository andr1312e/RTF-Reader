using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mytest
{
    public partial class Form1 : Form
    {
        
        List<Tuple<string, bool>> userAnswer = new List<Tuple<string, bool>>();
        List<Test> tests = new List<Test>();
        int currentTest = 0;
        int points = 0;
        string path = "";
        
        void setTest(Test t)
        {
            t.mixAnswers();
            label1.Text = t.getQuestion();
            radioButton1.Text = t.getAnswer(0);
            radioButton2.Text = t.getAnswer(1);
            radioButton3.Text = t.getAnswer(2);
            radioButton4.Text = t.getAnswer(3);
        }
        int getNumAns()
        {
            if (radioButton1.Checked)
                return 0;
            if (radioButton2.Checked)
                return 1;
            if (radioButton3.Checked)
                return 2;
            if (radioButton4.Checked)
                return 3;
            return -1;
        }
        public Form1(string path)
        {
            this.path = path;
            InitializeComponent();
            tests = Test.openTests(path);
            if (tests.Count > 0)
                setTest(tests[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getNumAns() == -1)
                MessageBox.Show("Выберите ответ");
            else
            {
                int ans = getNumAns();
                bool isAnsRight = tests[currentTest].check(ans);
                if (isAnsRight)
                    points++;
                userAnswer.Add(new Tuple<string, bool>(tests[currentTest].getAnswer(ans), isAnsRight));
                if (currentTest + 1 < tests.Count)
                {
                    currentTest++;
                    setTest(tests[currentTest]);
                }
                else
                {
                    radioButton1.Visible = false;
                    radioButton2.Visible = false;
                    radioButton3.Visible = false;
                    radioButton4.Visible = false;

                    button1.Visible = false;
                    label1.Text = "Итого:\n";
                    for (int i = 0; i < userAnswer.Count; i++)
                    {
                        label1.Text += (i + 1).ToString() + ") " + userAnswer[i].Item1 + " - ";
                        if (userAnswer[i].Item2 == true)
                            label1.Text += "верно\n";
                        else
                            label1.Text += "не верно\n";
                    }
                    label1.Text += "Ваши результаты " + points.ToString() + " из " + userAnswer.Count;
                }

            }
        }
    }
}
