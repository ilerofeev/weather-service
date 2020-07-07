using System.Data;

namespace WeatherApplication
{
    // Класс для получения данных погоды за сегодня
    class TodayWeather
    {
        // Метод для получения данных
        public void GetWeather(WeatherForm form)
        {
            // Массив, критериев для оценки погоды
            string[,] properties = new string[6, 2];
            // Заполнение массива
            properties[0, 0] = "Погода: ";
            properties[1, 0] = "Давление: ";
            properties[2, 0] = "Влажность: ";
            properties[3, 0] = "Температура днем: ";
            properties[4, 0] = "Температура ночью:   ";

            // Создание табличных данных и двух столбцов
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Свойство");
            dataTable.Columns.Add("Значение");

            // Получение данных о погоде за сегодня
            int days = 1;
            WeatherData weatherResponse = WeatherResponse.getData(days);

            // Заполнение значений из полученного запроса
            for (int i = 0; i < days; i++)
            {
                properties[0, 1] = weatherResponse.List[i].Weather[0].Description;
                properties[1, 1] = weatherResponse.List[i].Pressure + " мм рт. ст.";
                properties[2, 1] = weatherResponse.List[i].Humidity + "%";
                properties[3, 1] = weatherResponse.List[i].Temp.Day.ToString() + " °C";
                properties[4, 1] = weatherResponse.List[i].Temp.Night.ToString() + " °C";
            }
            // Заполнение столбцов таблицы
            for (int i = 0; i < 5; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Свойство"] = properties[i, 0];
                dataRow["Значение"] = properties[i, 1];
                dataTable.Rows.Add(dataRow);
            }
            // Отправка табличных данных элементу формы
            form.TableToday = dataTable;
        }
    }
}
