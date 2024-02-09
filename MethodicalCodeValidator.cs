using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoinovDiplom_ActEmpKPK
{
    public class MethodicalCodeValidator
    {
        public bool IsValidMethodicalCode(string code)
        {
            // Проверка правильности кода может зависеть от определенных правил
            // В этом примере, мы сравниваем введенный код с ожидаемым форматом "XX.XX.XX"
            string expectedFormat = "XX.XX.XX";

            if (code.Length != expectedFormat.Length)
            {
                return false; //Код имеет неправильную длину
            }

            for (int i = 0; i < code.Length; i++)
            {
                if (expectedFormat[i] == 'X' && !char.IsDigit(code[i]))
                {
                    return false; // Ожидается цифра в позиции X
                }
                else if (expectedFormat[i] == '.' && code[i] != '.')
                {
                    return false; // Ожидается точка в позиции "."
                }
            }
            return true;
        }

        public class TeacherCounter
        {
            private string connectionString = "Server=PR59\\SQLEXPRESS;Database=user2;User Id=user2;Password=212345;"; // Строка подключения к вашей базе данных
            public TeacherCounter(string dbConnectionString)
            {
                connectionString = dbConnectionString;
            }

            public int GetTeacherCount()
            {
                int teacherCount = 0;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM WORKER";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        teacherCount = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                return teacherCount;
            }
        }
    }
}
