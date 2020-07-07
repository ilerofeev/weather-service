namespace WeatherApplication
{
    // Класс для получения данных определенного уровня из файла в формате "JSON"
    class ResDaysList
    {
        // Значение давления
        public string Pressure { get; set; }
        // Значение влажности воздуха
        public string Humidity { get; set; }
        // Значение погоды
        public WeatherInfo []Weather { get; set; }
        // Значение температура
        public TemperatureInfo Temp { get; set; } 
    }
}
