using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortedListExTask
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private SortedList<DateTime, string> taskList = new SortedList<DateTime, string>();

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTask.Text == string.Empty)
                {
                    MessageBox.Show("You must enter a task", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(taskList.ContainsKey(dtpTaskDate.Value.Date))
                {

                    MessageBox.Show("Only one task for per date is allowed","Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error));
                    return;

                }
                else
                {
                    taskList.Add(dtpTaskDate.Value.Date, txtTask.Text);
                    lstTasks.Items.Add(dtpTaskDate.Value.Date);
                    txtTask.Text = string.Empty;
                    
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = Convert.ToDateTime(lstTasks.SelectedItem);

            lblTaskDetails.Text = taskList[selectedDate];
        }

        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("You must select a task to remove", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DateTime selectedDate = Convert.ToDateTime(lstTasks.SelectedItem);
                //string task = txtTask.Text.Trim();

                //taskList.Remove();
            }

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            foreach (var s in taskList)
            {
                msg += ($"{s.Key} {s.Value}\n");
            }
            MessageBox.Show(msg);
        }
    }
}
