using System;
using System.Data;

namespace WeatherApplication
{
    // Класс для получения данных погоды за диапазон дней
    class RangeWeather
    {
        // Метод для получения данных. Параметры: форма, кол-во дней
        public void GetRangeWeather(WeatherForm form, int days)
        {
            // Создние табличных данных и задание столбцов
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Дата");
            dataTable.Columns.Add("Погода");
            dataTable.Columns.Add("Давление (мм рт. ст.)");
            dataTable.Columns.Add("Влажность (%)");
            dataTable.Columns.Add("Температура днем (°C)");
            dataTable.Columns.Add("Температура ночью (°C)");

            // Получение данных о погоде за заданное кол-во дней
            WeatherData weatherResponse = WeatherResponse.getData(days);
            
            // Создание массива, который будет содержать все числа с выбранного диапазона дней
            string[] dates = new string[days];
            DateTime today = DateTime.Now;
            // Первый день заполняется автоматически. Берется сегодняшнее число
            string todayString = String.Format("{0:dd.MM.yyyy}", today);
            dates[0] = todayString;

            // Выбранное количество дней вперед
            for (int i = 1; i < days; i++)
            {
                // Прибавляем каждый раз на 1 день больше и полученное число помещаем в массив
                DateTime next = today.AddDays(i);
                string nextString = String.Format("{0:dd.MM.yyyy}", next);
                dates[i] = nextString;
            }

            // Заполнения таблицы строками, содержащими данные из запроса
            for (int i = 0; i < days; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow["Дата"] = dates[i];
                dataRow["Погода"] = weatherResponse.List[i].Weather[0].Description;
                dataRow["Давление (мм рт. ст.)"] = weatherResponse.List[i].Pressure;
                dataRow["Влажность (%)"] = weatherResponse.List[i].Humidity;
                dataRow["Температура днем (°C)"] = weatherResponse.List[i].Temp.Day.ToString();
                dataRow["Температура ночью (°C)"] = weatherResponse.List[i].Temp.Night.ToString();
                dataTable.Rows.Add(dataRow);
            }
            // Заполнение элемента формы табличными данными 
            form.TableRange = dataTable;
        }
    }
}
