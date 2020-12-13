using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SearchCore;

namespace math_modeling
{
    public partial class AnalizeForm2 : Form
    {
        public AnalizeForm2()
        {
            InitializeComponent();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            RecordSearcher searcher = new RecordSearcher();
            searcher.RunRecord();
            File.WriteAllLines("searches_data.txt", searcher.dataArray.ToArray());
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {

        }
    }
}
