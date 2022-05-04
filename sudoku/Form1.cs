using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace sudoku
{
    public partial class Form1 : Form
    {
        TextBox[,] cells;
        int a = 0;
        public Form1()
        {
            InitializeComponent();
            cells = new TextBox[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new TextBox();
                    cells[i, j].Multiline = true;
                    cells[i, j].TextAlign = HorizontalAlignment.Center;
                    cells[i, j].Font = new Font("Tahoma", 25);
                    cells[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
                    tableLayoutPanel1.Controls.Add(cells[i, j], i, j);
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();

            if (x.ShowDialog() == DialogResult.OK)
            {
                reset();
                string file_path = x.FileName;

                StreamReader my_file_reader = new StreamReader(file_path);

                string big_text = my_file_reader.ReadToEnd();

                //MessageBox.Show(big_text);

                char[] my_seperators = { ' ', '\r' };
                big_text = big_text.Replace("\n", "");

                string[] numbers = big_text.Split(my_seperators);

                int index = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (numbers[index] != "0")
                        {
                            cells[j, i].ReadOnly = true;
                            cells[j, i].Text = numbers[index];
                        }
                        index++;
                    }
                }
            }
        }
        private void reset()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[j, i].ReadOnly = false;
                    cells[j, i].Text = "";
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int list;
            int[] row, column ,sq;
          
            for (int i = 0; i < 9; i++)
            {
                row = new int[9];
                column = new int[9];
                for (int j = 0; j < 9; j++)
                {
                    if (cells[i, j].Text != "" && cells[i, j].Text != "")
                    {
                        int cellrow = Convert.ToInt16(cells[j, i].Text);
                        int cellcolumn = Convert.ToInt16(cells[i, j].Text);
                        if (0 < cellrow && cellrow < 10 && !row.Contains(cellrow) &&
                            0 < cellcolumn && cellcolumn < 10 && !column.Contains(cellcolumn))
                        {
                            row[j] = cellrow;
                            column[i] = cellcolumn;
                            continue;
                        }
                    }
                    MessageBox.Show("try again");
                    return;
                }
            }
            for (int k = 1, b1 = 0, d1 = 3, b2 = 0, d2 = 3; k <= 9; k++, b2 += 3, d2 += 3)

            {
                if ((k - 1) % 3 == 0)

                {
                    b2 = 0;
                    d2 = 3;
                }
                sq = new int[9];
                list = 0;

                for (int i = b1; i < d1; i++)

                {
                    for (int j = b2; j < d2; j++)

                    {
                        int cell = Convert.ToInt16(cells[j, i].Text);

                        if (!sq.Contains(cell))

                        {
                            sq[list++] = cell;

                            continue;
                        }

                        MessageBox.Show("Try again");

                        return;

                    }

                }

                if (k % 3 == 0)

                {
                    b1 += 3;

                    d1 += 3;
                }
            }

            MessageBox.Show("thats right");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
   
