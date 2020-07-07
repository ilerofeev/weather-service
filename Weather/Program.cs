using System;
using System.Windows.Forms;

namespace WeatherApplication
{
    /* ОПИСАНИЕ
    Все логика работы приложения описана в классе "WeatherForm.cs", запрос к сервису
    "Openweathermap" осуществляется с помощью класса "WeatherResponse". Запись данных в таблицы
    формы осуществляется с помощью классов "WeatherToday"(погода сегодня) и "WeatherRange"(погода
    по диапозону дней). Классы с приставкой "Res" необходимы для правильной обработки JSON-ответа
    с сервера. Класс "TimePicker" необходим для задания диапазонов Дата-пикера по-умолчанию
    и вычисления количества дней, для которых надо сделать запрос.
    */
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Создание новой формы, все дальнейшии действия происходят в классе формы
            Application.Run(new WeatherForm());
        }
    }
}
