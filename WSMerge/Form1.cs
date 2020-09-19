using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace WSMerge
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
            txtBxMergecap.Text = Properties.Settings.Default.wspath;
            if (!File.Exists(txtBxMergecap.Text))
            {
                MessageBox.Show("Programa \"mergecap.exe\" não encontrado", "Erro");
                if (openFileDialFindWS.ShowDialog() == DialogResult.OK)
                {
                    txtBxMergecap.Text = openFileDialFindWS.FileName;
                    Properties.Settings.Default.wspath = openFileDialFindWS.FileName;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           if (openFileDlgSource.ShowDialog() == DialogResult.OK)
            {
                foreach(string fname in openFileDlgSource.FileNames)
                {
                    listViewSourceFiles.Items.Add(fname);
                }                
            }
        }

        private void Btn_clear_Click(object sender, EventArgs e)
        {
            listViewSourceFiles.Items.Clear();
        }

        private void OpenFileDlgSource_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void BtnMerge_Click(object sender, EventArgs e)
        {
            if(listViewSourceFiles.Items.Count < 1)
            {
                MessageBox.Show("Nenhum arquivo selecionado","Erro");
                return;
            }
            else if(listViewSourceFiles.Items.Count == 1)
            {
                MessageBox.Show("Por favor, selecione mais de um arquivo para merge", "Selecione mais de um arquivo");
                return;
            }
            
            if(!File.Exists(txtBxMergecap.Text))
            {
                MessageBox.Show("Programa \"mergecap.exe\" não encontrado", "Erro");
                return;
            }

            if (saveFileDialMerged.ShowDialog() == DialogResult.OK)
            {
                string fileout = saveFileDialMerged.FileName;
                string filein = "";
                for (int i = 0; i < listViewSourceFiles.Items.Count; i++)
                {
                    filein += "\"" + listViewSourceFiles.Items[i].Text + "\" ";
                }
                Process p = new Process();
                p.StartInfo.FileName = txtBxMergecap.Text;
                p.StartInfo.Arguments = "-v -w " + fileout + " " + filein;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();

                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                MessageBox.Show("Merge concluído", "Concluído");
                if (File.Exists(fileout))
                {
                    Process.Start("explorer.exe", "/select, " + fileout);
                }

                //Console.WriteLine(filein);
            }
        }

        private void BrnSelMergecap_Click(object sender, EventArgs e)
        {
            if (openFileDialFindWS.ShowDialog() == DialogResult.OK)
            {
                txtBxMergecap.Text = openFileDialFindWS.FileName;
                Properties.Settings.Default.wspath = openFileDialFindWS.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
