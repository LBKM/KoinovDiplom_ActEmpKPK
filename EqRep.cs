
// Авторизация:

string ConnectionStg = "строка подключения";
string login = textBox1.Text;
string password = textBox2.Text;
using (SqlConnection connection = new SqlConnection(ConnectionStg))
{
    connection.Open();
    // проверка пользователя на наличие в базе данных  помощью запроса
    string authquery = "SELECT COUNT(*) FROM [user] WHERE [login] = @Login AND [password] = @Password";
    SqlCommand sqlCommand = new SqlCommand(authquery, connection);
    sqlCommand.Parameters.AddWithValue("Login", login);
    sqlCommand.Parameters.AddWithValue("Password", password);
    int count = (int)sqlCommand.ExecuteScalar();
    {
        //Если пользователь есть, открываем доступ к приложению
        if (count > 0)
        {
            MainMenuForm mainMenuForm = new MainMenuForm();
            this.Hide();
            mainMenuForm.ShowDialog();
            this.Close();
        }
        //В ином случае, вывод с ошибкой
        else
        {
            MessageBox.Show("Неправильный ввод данных при авторизации!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}



// Вывод в ListView: 
// во время загрузки название FillListView

private void FillListView_KSV()
{
    listView1.Items.Clear();
foreach(DataRow row in equipmentRepairDataSet.Requests.Rows)
    {
    string[] items = new string[7];
    DataRow tempRow;
    items[1] = row[1].ToString();

    tempRow = row.GetParentRow("FK__Requests__Equipm__3A81B327");
    items[2] = tempRow[1].ToString();

    items[3] = row[3].ToString();

    items[4] = row[4].ToString();

    tempRow = row.GetParentRow("FK__Requests__Client__3B75D760");
    items[5] = tempRow[1].ToString();

    items[6] = row[6].ToString();


    ListViewItem item = new ListViewItem();
    item.Text = row[0].ToString();
    item.SubItems.AddRange(items);
    listView1.Items.Add(item);
    listView1.Items[listView1.Items.Count - 1].BackColor = items[6] == "ого!!!" ? Color.LightGreen : Color.White;
    }


    labelCount.Text = $"Количество чего-то {ListView.Items.Count} из {DataSet.table.Count}";
}



// Фильтрация данных:
// По возрастанию:

listView1.Items.Clear();
foreach (DataRow row in equipmentRepairDataSet.Requests.OrderBy(p => p.Problem_Description))
{
    DataRow TempRow;

    string[] items = new string[7];
    DataRow tempRow;
    items[1] = row[1].ToString();

    tempRow = row.GetParentRow("FK__Requests__Equipm__3A81B327");
    items[2] = tempRow[1].ToString();

    items[3] = row[3].ToString();

    items[4] = row[4].ToString();

    tempRow = row.GetParentRow("FK__Requests__Client__3B75D760");
    items[5] = tempRow[1].ToString();

    items[6] = row[6].ToString();


    ListViewItem item = new ListViewItem();
    item.Text = row[0].ToString();
    item.SubItems.AddRange(items);
    listView1.Items.Add(item);
    listView1.Items[listView1.Items.Count - 1].BackColor = items[6] == "ого!!!" ? Color.LightGreen : Color.White;
}
labelCount.Text = $"Количество чего-то {ListView.Items.Count} из {DataSet.table.Count}";





// По убывания:
listView1.Items.Clear();
foreach (DataRow row in equipmentRepairDataSet.Requests.OrderByDescending(p => p.Problem_Description))
{
    DataRow TempRow;

    string[] items = new string[7];
    DataRow tempRow;
    items[1] = row[1].ToString();

    tempRow = row.GetParentRow("FK__Requests__Equipm__3A81B327");
    items[2] = tempRow[1].ToString();

    items[3] = row[3].ToString();

    items[4] = row[4].ToString();

    tempRow = row.GetParentRow("FK__Requests__Client__3B75D760");
    items[5] = tempRow[1].ToString();

    items[6] = row[6].ToString();


    ListViewItem item = new ListViewItem();
    item.Text = row[0].ToString();
    item.SubItems.AddRange(items);
    listView1.Items.Add(item);
    listView1.Items[listView1.Items.Count - 1].BackColor = items[6] == "ого!!!" ? Color.LightGreen : Color.White;
}
labelCount.Text = $"Количество чего-то {ListView.Items.Count} из {DataSet.table.Count}";





// Фильтрация по тексту:
string strFindMDK = TextBox1.Text;
ListView.Items.Clear();
foreach (DataRow row in user2DataSet.ACTIVITY_EMPLOYEE.Select("[таблицв] LIKE '%" + strFindMDK + "*'"))
    {
        DataRow TempRow;

    string[] items = new string[7];
    DataRow tempRow;
    items[1] = row[1].ToString();

    tempRow = row.GetParentRow("FK__Requests__Equipm__3A81B327");
    items[2] = tempRow[1].ToString();

    items[3] = row[3].ToString();

    items[4] = row[4].ToString();

    tempRow = row.GetParentRow("FK__Requests__Client__3B75D760");
    items[5] = tempRow[1].ToString();

    items[6] = row[6].ToString();


    ListViewItem item = new ListViewItem();
    item.Text = row[0].ToString();
    item.SubItems.AddRange(items);
    listView1.Items.Add(item);
    listView1.Items[listView1.Items.Count - 1].BackColor = items[6] == "ого!!!" ? Color.LightGreen : Color.White;
}
labelCount.Text = $"Количество чего-то {ListView.Items.Count} из {DataSet.table.Count}";





// Фильтр по комбокс:

//Заполним комбобокс, для начала в Load:
comboBox1.Items.Add("Все типы");
foreach (DataRow Row_WP in equipmentRepairDataSet.Requests) comboBox1.Items.Add(Row_WP["Malfunction_Type"]);

// Создадим новый вывод FillListFilter
private void FillListViewCBFilt()
{

    listView1.Items.Clear();
    foreach (DataRow row in equipmentRepairDataSet.Requests.Rows)
    {
        DataRow DataRowStatus = equipmentRepairDataSet.Requests.Select("Malfunction_Type = '" + comboBox1.SelectedItem + "'")[0];
        if (row["Malfunction_Type"].ToString() == DataRowStatus["Malfunction_Type"].ToString())
        {
            string[] items = new string[7];
            DataRow tempRow;
            items[1] = row[1].ToString();

            tempRow = row.GetParentRow("FK__Requests__Equipm__3A81B327");
            items[2] = tempRow[1].ToString();

            items[3] = row[3].ToString();

            items[4] = row[4].ToString();

            tempRow = row.GetParentRow("FK__Requests__Client__3B75D760");
            items[5] = tempRow[1].ToString();

            items[6] = row[6].ToString();


            ListViewItem item = new ListViewItem();
            item.Text = row[0].ToString();
            item.SubItems.AddRange(items);
            listView1.Items.Add(item);
            listView1.Items[listView1.Items.Count - 1].BackColor = items[6] == "ого!!!" ? Color.LightGreen : Color.White;
        }
        labelCount.Text = $"Количество чего-то {ListView.Items.Count} из {DataSet.table.Count}";

    }
}



//А в обработчике напишем:
private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
{
    switch (comboBox1.SelectedItem)
    {
        case "Все типы":
            FillListView();
            break;
        default:
            FillListViewCBFilt();
            break;
    }
}



//Добавление данных:

int InsertedRows = tableadapter.Insert( //Добавление данных в БД через поля приложения:
           TextBoxActEmpID.Text,
           Convert.ToInt32(Discipline),
           Convert.ToInt32(Worker),
           Convert.ToInt32(EducationForm),
           Convert.ToInt32(Speciality),
           TextBoxNameAetEmp.Text,
           Convert.ToInt32(Event));

try
{
    if (InsertedRows > 0)
        MessageBox.Show("Успешное добавление!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
}
catch (Exception ex)
{
    if (InsertedRows == 0)
        // Если произошла ошибка, отобразите сообщение об ошибке
        MessageBox.Show("Не удалось добавить новые данные. Причина: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
}

this.aCTIVITY_EMPLOYEETableAdapter.Fill(this.user2DataSet.ACTIVITY_EMPLOYEE);
this.DialogResult = System.Windows.Forms.DialogResult.OK;
this.Close();




//Удаление:
private void ButDel_Click(object sender, EventArgs e)
{
    foreach (ListViewItem item in listViewProducts.SelectedItems)
    {
        DataRow Row = demo3DataSet_HAU.Product_HAU.Select("ProductArticleNumber = '" + item.Text + "''")[0]; 
        DataRow[] TempRows = Row.GetChildRows("FK_OrderProduct_HAU_Product_HAU"); 
        if(TempRows.Length != 0)
        {
            MessageBox.Show("Этот товар есть в чьем-то заказе.\nHевозможно удалить!", "Ошибка удаления", MessageBoxButtons.ОK, MessageBoxIcon.Exclamation);
            return;
        }
        
    item.Remove();
    try { 
            Row.Delete(); 
        }
    catch (Exception ex) 
        { 
            MessageBox.Show(ex.ToString(), "Вызов исключений"); 
        }
    }
        
     product_HAUTableAdapter.Update(demo3DataSet_HAU.Product_HAU); 
     orderProduct_HAUTableAdapter.Update(demo3DataSet_HAU.OrderProduct_HAU); 
     product_HAUTableAdapter.Fill(demo3DataSet_HAU.Product_HAU); 
     orderProduct_HAUTableAdapter.Fill(demo3DataSet_HAU.OrderProduct_HAU); 
     FillProductList_HAU();
}


// Изменение ты знаешь как делать


//Хранимая процедура, ну на всякий прост так:
CREATE PROCEDURE PageViewLOLOLO
-- Add the parameters for the stored procedure here 
@pageNumber int,
@pageSize int
AS
BEGIN
SELECT *
FROM dbo.ACTIVITY_EMPLOYEE
ORDER BY ActEmp_ID OFFSET ((@pageNumber)*@pageSize)
ROWS FETCH NEXT @pageSize ROWS ONLY
END
GO


//В КОДЕ:
namespace BeautySalon
{
    public partial class PageViewForm : Form
    {
        int pageSize = 5, pageNumber = 0; ...


//Далее видоизменим код заполнение записей в ListView, добавив в него строку заполнения данными DataSet на основе запроса.
void FillServiceList()
{
            this.serviceTableAdapter.FillByPageView(this.salonDataSet.Service, pageNumber, pageSize);
            //Очистили ServiceListView от всеx строк
            ServiceListView.Items.Clear();
            //Открыли цикл foreach в котором Row - представляет все строк таблицы Service
            foreach (DataRow Row in salonDataSet.Service.Rows)
            { ... }


//В кнопках переключения страниц добавим изменение переменной pageNumber зависимости от типа кнопки.
private void iconButton4_Click(object sender, EventArgs e)
{
    pageNumber++;
    FillActEmpListPageView();
}

private void iconButton3_Click(object sender, EventArgs e)
{
    if (pageNumber > 0)
    {
        pageNumber--;
        FillActEmpListPageView();
    }
}


            // Unit-Тест (правильный):
            [TestMethod]
            public void TestValidLogin()
            {
                // Арранжировка (Arrange)
                string connectionString = "строка подключения";
                string login = "valid_user";
                string password = "valid_password";
                bool expectedResult = true;

                // Действие (Act)
                bool actualResult = Authorize(connectionString, login, password);

                // Утверждение (Assert)
                Assert.AreEqual(expectedResult, actualResult);
            }


            // Unit-Тест (неправильный):
            [TestMethod]
            public void TestInvalidLogin()
            {
                // Арранжировка (Arrange)
                string connectionString = "строка подключения";
                string login = "invalid_user";
                string password = "invalid_password";
                bool expectedResult = false;

                // Действие (Act)
                bool actualResult = Authorize(connectionString, login, password);

                // Утверждение (Assert)
                Assert.AreEqual(expectedResult, actualResult);
            }
