using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace KoinovDiplom_ActEmpKPK
{
    public class MethodicalCodeValidator
    {
        // Метод для проверки корректности методического кода
        public bool IsValidMethodicalCode(string code)
        {
            // Ожидаемый формат кода "XX.XX.XX"
            string expectedFormat = "XX.XX.XX";

            // Проверка длины кода
            if (code.Length != expectedFormat.Length)
            {
                return false; // Код имеет неправильную длину
            }

            // Проверка каждого символа в коде
            for (int i = 0; i < code.Length; i++)
            {
                // Ожидается цифра в позиции 'X'
                if (expectedFormat[i] == 'X' && !char.IsDigit(code[i]))
                {
                    return false;
                }
                // Ожидается точка в позиции '.'
                else if (expectedFormat[i] == '.' && code[i] != '.')
                {
                    return false;
                }
            }
            return true; // Код соответствует ожидаемому формату
        }

        // Внутренний класс для подсчета количества учителей
        public class TeacherCounter
        {
            protected string connectionString; // Строка подключения к базе данных

            // Конструктор для инициализации строки подключения
            public TeacherCounter(string dbConnectionString)
            {
                connectionString = dbConnectionString;
            }

            // Метод для получения количества учителей в базе данных
            public int GetTeacherCount()
            {
                int teacherCount = 0;

                // Использование блока using для автоматического закрытия соединения с базой данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Открытие соединения

                    // SQL-запрос для подсчета количества учителей
                    string query = "SELECT COUNT(*) FROM WORKER";

                    // Использование блока using для автоматического освобождения ресурсов команды
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Выполнение запроса и преобразование результата к целочисленному значению
                        teacherCount = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
                return teacherCount; // Возвращение количества учителей
            }
        }
    }
}
