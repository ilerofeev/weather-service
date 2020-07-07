using System;
using MaterialSkin.Controls;

namespace WeatherApplication
{
    // Наследование придает элементам формы более современный вид
    public partial class WeatherForm : MaterialForm
    {
        // Инициализация формы
        public WeatherForm()
        {
            InitializeComponent();
        }
        // Далее объявляются доступы к элементам формы посредством геттеров и 
        // Таблица с погодой на сегодня
        public object TableToday
        {
            get { return todayWeather.DataSource; }
            set { todayWeather.DataSource = value; }
        }
        // Таблица с погодой по диапозону дней
        public object TableRange
        {
            get { return rangeWeather.DataSource; }
            set { rangeWeather.DataSource = value; }
        }
        // Дата пикер с началом диапазона дней
        public DateTime PickerToday
        {
            get { return firstPicker.Value; }
            set { firstPicker.Value = value; }
        }
        // Дата пикер с концом диапозона дней
        public DateTime PickerNext
        {
            get { return secondPicker.Value; }
            set { secondPicker.Value = value; }
        }
        // Минимальное значение конца диапазона дней
        public DateTime PickerMin
        {
            get { return secondPicker.MinDate; }
            set { secondPicker.MinDate = value; }
        }
        // Максимальное значение конца диапозона дней
        public DateTime PickerMax
        {
            get { return secondPicker.MaxDate; }
            set { secondPicker.MaxDate = value; }
        }
        // Действия при создании новой формы
        // (оно осуществляется при запуске приложения в классе "Program.cs")
        private void Weather_Load(object sender, EventArgs e)
        {
            // Создание экземпляра тайм пикера
            TimePicker tp = new TimePicker();
            // Задание доступного для выбора диапазона дней
            tp.SetDatesRanges(this);

            // Создание экземпляра "Погода сегодня"
            TodayWeather tw = new TodayWeather();
            // Загрузка данных в форму из онлайн сервиса
            tw.GetWeather(this);
        }
        // При выборе нового диапазона дней в тайм икере
        private void SecondPicker_ValueChanged(object sender, EventArgs e)
        {
            // Создание экземпляра тайм пикера
            TimePicker tp = new TimePicker();
            // Получение разницы выбранной даты и сегодняшнего дня
            int days = tp.getDaysRange(this);

            // Создание экземпляра "Погода по диапазону дней"
            RangeWeather rw = new RangeWeather();
            // Загрузка данных в форму из онлайн сервиса
            rw.GetRangeWeather(this, days);
        }
    }
}
