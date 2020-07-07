using System;

namespace WeatherApplication
{
    // Класс для работы с тайм пикерами
    class TimePicker
    {
        // Метод для получения разницы выбранных дней в дата пикерах формы
        public int getDaysRange(WeatherForm form)
        {
            DateTime dt1 = form.PickerToday;
            DateTime dt2 = form.PickerNext;
            TimeSpan x = dt2 - dt1;
            int days = ((int)x.TotalDays + 1) + 1;
            return days;
        }
        // Метод задания максимально и минимально возможной для выбора даты в дата пикере
        public void SetDatesRanges(WeatherForm form)
        {
            // Получаем завтрашнее число и задаем его как минимально возможную для выбора дату
            DateTime today = DateTime.Now;
            DateTime next = today.AddDays(1);
            string nextString = String.Format("{0:dd.MM.yyyy}", next);
            DateTime minDate = DateTime.ParseExact(nextString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            form.PickerMin = minDate;
            // Получаем число на две недели вперед и задаем его как максимльновозможную для выбора дату
            next = today.AddDays(14);
            nextString = String.Format("{0:dd.MM.yyyy}", next);
            DateTime maxDate = DateTime.ParseExact(nextString, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);
            form.PickerMax = maxDate;
        }
    }
}
