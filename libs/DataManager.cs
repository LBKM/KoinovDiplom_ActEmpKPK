using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KoinovDiplom_ActEmpKPK
{
    public class DataManager
    {
        private user2DataSet user2DataSet;
        private ListView listViewActEmp;
        private Label countLabel;

        public DataManager(user2DataSet dataSet, ListView listView, Label label)
        {
            user2DataSet = dataSet;
            listViewActEmp = listView;
            countLabel = label;
        }

        public void FillActEmpList()
        {
            listViewActEmp.Items.Clear();

            foreach (DataRow Row in user2DataSet.ACTIVITY_EMPLOYEE.Rows)
            {
                string[] items = new string[10];
                DataRow tempRow;

                tempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_DISCIPLINE");
                items[1] = tempRow[1].ToString();

                tempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_WORKER");
                items[2] = tempRow["Name"].ToString();
                items[3] = tempRow["Surname"].ToString();
                items[4] = tempRow["Lastname"].ToString();

                tempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EDUCATION_FORM");
                items[5] = tempRow["Education_Form"].ToString();

                tempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_SPECIALITY");
                items[6] = tempRow["Name"].ToString();

                items[7] = Row[4].ToString();

                tempRow = Row.GetParentRow("FK_ACTIVITY_EMPLOYEE_EVENT");
                items[8] = tempRow["Name"].ToString();

                ListViewItem it = new ListViewItem();
                it.Text = Row["ActEmp_ID"].ToString();
                it.SubItems.AddRange(items);
                listViewActEmp.Items.Add(it);
            }

            countLabel.Text = $"{listViewActEmp.Items.Count} из {user2DataSet.ACTIVITY_EMPLOYEE.Rows.Count}";
        }
    }

}
