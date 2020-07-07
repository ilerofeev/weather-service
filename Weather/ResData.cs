namespace WeatherApplication
{
    // Класс для получения данных определенного уровня из файла в формате "JSON"
    class WeatherData
    { 
        // Массив, содержащий данные за все запрошенные дни
        public ResDaysList[]List { get; set; }
    }
}
