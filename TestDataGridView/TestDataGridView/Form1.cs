using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeDataGridView()
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {


            for (int n = 0; n < 10; n++)
            {
                //  DataGridViewColumn column = dataGridView1.Columns[n];
                //  column.Width = 30;

                n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = "0";
                dataGridView1.Rows[n].Cells[1].Value = "0";
                dataGridView1.Rows[n].Cells[2].Value = "0";
                dataGridView1.Rows[n].Cells[3].Value = "0";
                dataGridView1.Rows[n].Cells[4].Value = "0";
                dataGridView1.Rows[n].Cells[5].Value = "0";
                dataGridView1.Rows[n].Cells[6].Value = "0";
                dataGridView1.Rows[n].Cells[7].Value = "0";
                dataGridView1.Rows[n].Cells[8].Value = "0";
                dataGridView1.Rows[n].Cells[9].Value = "0";
                //  dataGridView1.Rows[n].Cells[10].Value = "0";
            }


            for (int i = 1; i < dataGridView1.Rows.Count; i++)       // нумерация строк
            {
                dataGridView1.Rows[i - 1].HeaderCell.Value
                    = i.ToString();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();



            for (int n = 0; n < 4; n++)                                                // однопалубные
            {
                bool already1 = false;
            Again1:
                if (!already1)
                {
                    int k = rnd.Next(0, 9);
                    int m = rnd.Next(0, 9);
                    if (k == 0 && m == 0)                                                    // проверка углов
                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                    if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")
                                    {
                                        dataGridView1.Rows[k].Cells[m].Value = "1";
                                        already1 = true;
                                    }
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;
                        else goto Again1;



                    if (!already1)
                        if (k == 0 && m == 9)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")
                                        {
                                            dataGridView1.Rows[k].Cells[m].Value = "1";
                                            already1 = true;
                                        }
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;



                    if (!already1)
                        if (k == 9 && m == 0)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                        {
                                            dataGridView1.Rows[k].Cells[m].Value = "1";
                                            already1 = true;
                                        }
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;



                    if (!already1)
                        if (k == 9 && m == 9)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                        {
                                            dataGridView1.Rows[k].Cells[m].Value = "1";
                                            already1 = true;
                                        }
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;



                    if (!already1)
                        if (k == 0 && m > 0 && m < 9)                                             // верхняя линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                        if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")
                                                {
                                                    dataGridView1.Rows[k].Cells[m].Value = "1";
                                                    already1 = true;
                                                }
                                                else goto Again1;
                                            else goto Again1;
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;



                    if (!already1)
                        if (k == 9 && m > 0 && m < 9)                                             // нижняя линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                                {
                                                    dataGridView1.Rows[k].Cells[m].Value = "1";
                                                    already1 = true;
                                                }
                                                else goto Again1;
                                            else goto Again1;
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;


                    if (!already1)
                        if (k > 0 && k < 9 && m == 0)                                             // левая линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")
                                                {
                                                    dataGridView1.Rows[k].Cells[m].Value = "1";
                                                    already1 = true;
                                                }
                                                else goto Again1;
                                            else goto Again1;
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;



                    if (!already1)
                        if (k > 0 && k < 9 && m == 9)                                             // правая линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")
                                                {
                                                    dataGridView1.Rows[k].Cells[m].Value = "1";
                                                    already1 = true;
                                                }
                                                else goto Again1;
                                            else goto Again1;
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;




                    if (!already1)                                                                // расстановка однопалубых в поле
                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m - 1].Value == null)
                                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0" || dataGridView1.Rows[k + 1].Cells[m].Value == null)
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m + 1].Value == null)
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "1";
                                                            already1 = true;
                                                        }
                                                        else goto Again1;
                                                    else goto Again1;
                                                else goto Again1;
                                            else goto Again1;
                                        else goto Again1;
                                    else goto Again1;
                                else goto Again1;
                            else goto Again1;
                        else goto Again1;

                    //  if (already1)
                    //       dataGridView1.Rows[k].Cells[m].Style.BackColor = System.Drawing.Color.Green;
                }
            }


            for (int n = 0; n < 3; n++)                                        // двухпалубные
            {
                bool already2 = false;
            Again2:                                                             // вертикально
                if (!already2)
                {
                    int k = rnd.Next(0, 8);
                    int m = rnd.Next(0, 8);

                    if (k == 0 && m == 0)                                                    // проверка углов
                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                    if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                        if (dataGridView1.Rows[k + 2].Cells[m].Value == "0")
                                            if (dataGridView1.Rows[k + 2].Cells[m + 1].Value == "0")
                                                if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                    if (dataGridView1.Rows[k + 1].Cells[m + 2].Value == "0")
                                                    {
                                                        dataGridView1.Rows[k].Cells[m].Value = "2";
                                                        dataGridView1.Rows[k].Cells[m + 1].Value = "2";
                                                        already2 = true;
                                                    }
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;
                        else goto Again2;

                    if (!already2)
                        if (k == 0 && m == 9)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")

                                            if (dataGridView1.Rows[k].Cells[m - 2].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 2].Value == "0")
                                                    if (dataGridView1.Rows[k + 2].Cells[m - 1].Value == "0")
                                                        if (dataGridView1.Rows[k + 2].Cells[m].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k].Cells[m - 1].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)
                        if (k == 9 && m == 0)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")

                                            if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m + 2].Value == "0")
                                                    if (dataGridView1.Rows[k - 2].Cells[m].Value == "0")
                                                        if (dataGridView1.Rows[k - 2].Cells[m + 1].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k].Cells[m + 1].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)
                        if (k == 9 && m == 9)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")

                                            if (dataGridView1.Rows[k].Cells[m - 2].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m - 2].Value == "0")
                                                    if (dataGridView1.Rows[k - 2].Cells[m - 1].Value == "0")
                                                        if (dataGridView1.Rows[k - 2].Cells[m].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k].Cells[m - 1].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)
                        if (k == 0 && m > 0 && m < 8)                                             // верхняя линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                        if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                                    if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 2].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k].Cells[m + 1].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)
                        if (k == 9 && m > 0 && m < 8)                                             // нижняя линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")

                                                    if (dataGridView1.Rows[k - 1].Cells[m + 2].Value == "0")
                                                        if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k].Cells[m + 1].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)
                        if (k > 0 && k < 8 && m == 0)                                             // левая линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                                    if (dataGridView1.Rows[k + 2].Cells[m].Value == "0")
                                                        if (dataGridView1.Rows[k + 2].Cells[m + 1].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k + 1].Cells[m].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)
                        if (k > 0 && k < 8 && m == 9)                                             // правая линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")

                                                    if (dataGridView1.Rows[k + 2].Cells[m - 1].Value == "0")
                                                        if (dataGridView1.Rows[k + 2].Cells[m].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "2";
                                                            dataGridView1.Rows[k + 1].Cells[m].Value = "2";
                                                            already2 = true;
                                                        }
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;



                    if (!already2)                                                                   // двухпалубные в поле
                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m - 1].Value == null)
                                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0" || dataGridView1.Rows[k + 1].Cells[m].Value == null)
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m + 1].Value == null)
                                                            if (dataGridView1.Rows[k + 2].Cells[m - 1].Value == "0" || dataGridView1.Rows[k + 2].Cells[m - 1].Value == null)
                                                                if (dataGridView1.Rows[k + 2].Cells[m + 1].Value == "0" || dataGridView1.Rows[k + 2].Cells[m + 1].Value == null)
                                                                    if (dataGridView1.Rows[k + 2].Cells[m].Value == "0" || dataGridView1.Rows[k + 2].Cells[m].Value == null)
                                                                    {
                                                                        dataGridView1.Rows[k].Cells[m].Value = "2";
                                                                        dataGridView1.Rows[k + 1].Cells[m].Value = "2";
                                                                        already2 = true;
                                                                    }
                                                                    else goto Again25;
                                                                else goto Again25;
                                                            else goto Again25;
                                                        else goto Again25;
                                                    else goto Again25;
                                                else goto Again25;
                                            else goto Again25;
                                        else goto Again25;
                                    else goto Again25;
                                else goto Again25;
                            else goto Again25;
                        else goto Again25;


                Again25:
                    if (!already2)
                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m - 1].Value == null)
                                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0" || dataGridView1.Rows[k + 1].Cells[m].Value == null)
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m + 1].Value == null)
                                                            if (dataGridView1.Rows[k - 1].Cells[m + 2].Value == "0")
                                                                if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                                    if (dataGridView1.Rows[k + 1].Cells[m + 2].Value == "0")
                                                                    {
                                                                        dataGridView1.Rows[k].Cells[m].Value = "2";
                                                                        dataGridView1.Rows[k].Cells[m + 1].Value = "2";
                                                                    }
                                                                    else goto Again2;
                                                                else goto Again2;
                                                            else goto Again2;
                                                        else goto Again2;
                                                    else goto Again2;
                                                else goto Again2;
                                            else goto Again2;
                                        else goto Again2;
                                    else goto Again2;
                                else goto Again2;
                            else goto Again2;
                        else goto Again2;
                }
            }


            for (int n = 0; n < 2; n++)                                        // трехпалубные
            {
                bool already3 = false;
            Again3:                                                            // вертикально
                if (!already3)
                {
                    int k = rnd.Next(1, 7);
                    int m = rnd.Next(1, 7);


                    if (k == 0 && m == 0)                                                    // проверка углов
                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                    if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                        if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m + 2].Value == "0")

                                                if (dataGridView1.Rows[k].Cells[m + 3].Value == "0")
                                                    if (dataGridView1.Rows[k + 1].Cells[m + 3].Value == "0")
                                                    {
                                                        dataGridView1.Rows[k].Cells[m].Value = "3";
                                                        dataGridView1.Rows[k].Cells[m + 1].Value = "3";
                                                        dataGridView1.Rows[k].Cells[m + 2].Value = "3";
                                                        already3 = true;
                                                    }
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;
                        else goto Again3;



                    if (!already3)
                        if (k == 0 && m == 9)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")

                                            if (dataGridView1.Rows[k].Cells[m - 2].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 2].Value == "0")

                                                    if (dataGridView1.Rows[k].Cells[m - 3].Value == "0")
                                                        if (dataGridView1.Rows[k + 1].Cells[m - 3].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "3";
                                                            dataGridView1.Rows[k].Cells[m - 1].Value = "3";
                                                            dataGridView1.Rows[k].Cells[m - 2].Value = "3";
                                                            already3 = true;
                                                        }
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;



                    if (!already3)
                        if (k == 9 && m == 0)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")

                                            if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m + 2].Value == "0")

                                                    if (dataGridView1.Rows[k].Cells[m + 3].Value == "0")
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 3].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "3";
                                                            dataGridView1.Rows[k].Cells[m + 1].Value = "3";
                                                            dataGridView1.Rows[k].Cells[m + 2].Value = "3";
                                                            already3 = true;
                                                        }
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;



                    if (!already3)
                        if (k == 9 && m == 9)
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")

                                            if (dataGridView1.Rows[k].Cells[m - 2].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m - 2].Value == "0")

                                                    if (dataGridView1.Rows[k - 1].Cells[m - 3].Value == "0")
                                                        if (dataGridView1.Rows[k].Cells[m - 3].Value == "0")
                                                        {
                                                            dataGridView1.Rows[k].Cells[m].Value = "3";
                                                            dataGridView1.Rows[k].Cells[m - 1].Value = "3";
                                                            dataGridView1.Rows[k].Cells[m - 2].Value = "3";
                                                            already3 = true;
                                                        }
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;



                    if (!already3)
                        if (k == 0 && m > 1 && m < 7)                                             // верхняя линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                        if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                                    if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 2].Value == "0")

                                                            if (dataGridView1.Rows[k].Cells[m + 3].Value == "0")
                                                                if (dataGridView1.Rows[k + 1].Cells[m + 3].Value == "0")
                                                                {
                                                                    dataGridView1.Rows[k].Cells[m].Value = "3";
                                                                    dataGridView1.Rows[k].Cells[m + 1].Value = "3";
                                                                    dataGridView1.Rows[k].Cells[m + 2].Value = "3";
                                                                    already3 = true;
                                                                }
                                                                else goto Again3;
                                                            else goto Again3;
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;



                    if (!already3)
                        if (k == 9 && m > 1 && m < 7)                                             // нижняя линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")

                                                    if (dataGridView1.Rows[k - 1].Cells[m + 2].Value == "0")
                                                        if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")

                                                            if (dataGridView1.Rows[k - 1].Cells[m + 3].Value == "0")
                                                                if (dataGridView1.Rows[k].Cells[m + 3].Value == "0")
                                                                {
                                                                    dataGridView1.Rows[k].Cells[m].Value = "3";
                                                                    dataGridView1.Rows[k].Cells[m + 1].Value = "3";
                                                                    dataGridView1.Rows[k].Cells[m + 2].Value = "3";
                                                                    already3 = true;
                                                                }
                                                                else goto Again3;
                                                            else goto Again3;
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;



                    if (!already3)
                        if (k > 1 && k < 7 && m == 0)                                             // левая линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                                    if (dataGridView1.Rows[k + 2].Cells[m].Value == "0")
                                                        if (dataGridView1.Rows[k + 2].Cells[m + 1].Value == "0")

                                                            if (dataGridView1.Rows[k + 3].Cells[m].Value == "0")
                                                                if (dataGridView1.Rows[k + 3].Cells[m + 1].Value == "0")
                                                                {
                                                                    dataGridView1.Rows[k].Cells[m].Value = "3";
                                                                    dataGridView1.Rows[k + 1].Cells[m].Value = "3";
                                                                    dataGridView1.Rows[k + 2].Cells[m].Value = "3";
                                                                    already3 = true;
                                                                }
                                                                else goto Again3;
                                                            else goto Again3;
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;



                    if (!already3)
                        if (k > 1 && k < 7 && m == 9)                                             // правая линия
                            if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                    if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                                            if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")

                                                    if (dataGridView1.Rows[k + 2].Cells[m - 1].Value == "0")
                                                        if (dataGridView1.Rows[k + 2].Cells[m].Value == "0")

                                                            if (dataGridView1.Rows[k + 3].Cells[m - 1].Value == "0")
                                                                if (dataGridView1.Rows[k + 3].Cells[m].Value == "0")
                                                                {
                                                                    dataGridView1.Rows[k].Cells[m].Value = "3";
                                                                    dataGridView1.Rows[k + 1].Cells[m].Value = "3";
                                                                    dataGridView1.Rows[k + 2].Cells[m].Value = "3";
                                                                    already3 = true;
                                                                }
                                                                else goto Again3;
                                                            else goto Again3;
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;




                    if (!already3)
                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0")
                                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0")
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0")

                                                            if (dataGridView1.Rows[k + 3].Cells[m - 1].Value == "0")
                                                                if (dataGridView1.Rows[k + 3].Cells[m].Value == "0")
                                                                    if (dataGridView1.Rows[k + 3].Cells[m + 1].Value == "0")

                                                                        if (dataGridView1.Rows[k + 2].Cells[m - 1].Value == "0" || dataGridView1.Rows[k + 2].Cells[m - 1].Value == null)
                                                                            if (dataGridView1.Rows[k + 2].Cells[m + 1].Value == "0" || dataGridView1.Rows[k + 2].Cells[m + 1].Value == null)
                                                                                if (dataGridView1.Rows[k + 2].Cells[m].Value == "0" || dataGridView1.Rows[k + 2].Cells[m].Value == null)
                                                                                {
                                                                                    dataGridView1.Rows[k].Cells[m].Value = "3";
                                                                                    dataGridView1.Rows[k + 1].Cells[m].Value = "3";
                                                                                    dataGridView1.Rows[k + 2].Cells[m].Value = "3";
                                                                                    already3 = true;
                                                                                }
                                                                                else goto Again35;
                                                                            else goto Again35;
                                                                        else goto Again35;
                                                                    else goto Again35;
                                                                else goto Again35;
                                                            else goto Again35;
                                                        else goto Again35;
                                                    else goto Again35;
                                                else goto Again35;
                                            else goto Again35;
                                        else goto Again35;
                                    else goto Again35;
                                else goto Again35;
                            else goto Again35;
                        else goto Again35;


                Again35:
                    if (!already3)
                        if (dataGridView1.Rows[k - 1].Cells[m - 1].Value == "0")
                            if (dataGridView1.Rows[k - 1].Cells[m].Value == "0")
                                if (dataGridView1.Rows[k - 1].Cells[m + 1].Value == "0")
                                    if (dataGridView1.Rows[k].Cells[m - 1].Value == "0")
                                        if (dataGridView1.Rows[k].Cells[m].Value == "0")
                                            if (dataGridView1.Rows[k].Cells[m + 1].Value == "0")
                                                if (dataGridView1.Rows[k + 1].Cells[m - 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m - 1].Value == null)
                                                    if (dataGridView1.Rows[k + 1].Cells[m].Value == "0" || dataGridView1.Rows[k + 1].Cells[m].Value == null)
                                                        if (dataGridView1.Rows[k + 1].Cells[m + 1].Value == "0" || dataGridView1.Rows[k + 1].Cells[m + 1].Value == null)
                                                            if (dataGridView1.Rows[k - 1].Cells[m + 2].Value == "0")
                                                                if (dataGridView1.Rows[k].Cells[m + 2].Value == "0")
                                                                    if (dataGridView1.Rows[k + 1].Cells[m + 2].Value == "0")

                                                                        if (dataGridView1.Rows[k - 1].Cells[m + 3].Value == "0")
                                                                            if (dataGridView1.Rows[k].Cells[m + 3].Value == "0")
                                                                                if (dataGridView1.Rows[k + 1].Cells[m + 3].Value == "0")
                                                                                {
                                                                                    dataGridView1.Rows[k].Cells[m].Value = "3";
                                                                                    dataGridView1.Rows[k].Cells[m + 1].Value = "3";
                                                                                    dataGridView1.Rows[k].Cells[m + 2].Value = "3";
                                                                                }
                                                                                else goto Again3;
                                                                            else goto Again3;
                                                                        else goto Again3;
                                                                    else goto Again3;
                                                                else goto Again3;
                                                            else goto Again3;
                                                        else goto Again3;
                                                    else goto Again3;
                                                else goto Again3;
                                            else goto Again3;
                                        else goto Again3;
                                    else goto Again3;
                                else goto Again3;
                            else goto Again3;
                        else goto Again3;
                }
            }
            for (int l = 0; l < 10; l++)
                for (int y = 0; y < 10; y++)
                {
                    if (dataGridView1.Rows[l].Cells[y].Value == "0")
                        dataGridView1.Rows[l].Cells[y].Style.BackColor = System.Drawing.Color.Blue;
                }
        }
    }
}
