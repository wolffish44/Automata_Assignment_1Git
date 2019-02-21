﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Automata_Assignment_1.Automatons;

namespace Automata_Assignment_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileInterpreter fi = new FileInterpreter();
            Analyzer analyzer = new Analyzer();
            var generatedAutomaton = fi.generateAutomaton();
     
            dotFileWriter dw = new dotFileWriter();
            dw.writeToDotFile(generatedAutomaton);
            generateGraph();
            isDetLbl.Text = analyzer.isDfa(generatedAutomaton).ToString();
            Console.WriteLine(analyzer.isLegalWord(generatedAutomaton, "menno").ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        void generateGraph()
        {
           

            Process dot = new Process();

            dot.StartInfo.FileName = "dot.exe";

            dot.StartInfo.Arguments = "-Tpng -oresult.png automaton.txt";
            dot.Start();

            dot.WaitForExit();
            pictureBox1.ImageLocation = "result.png";



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void inputWordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            FileInterpreter fi = new FileInterpreter();
            Analyzer analyzer = new Analyzer();
            var generatedAutomaton = fi.generateAutomaton();
            resultLabel.Text = analyzer.isLegalWord(generatedAutomaton, inputWordBox.Text).ToString();


        }

        private void resultLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
