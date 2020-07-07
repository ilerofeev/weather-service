using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WeatherApplication
{
    // Класс для отправки запроса на сервис Openweathermap и получения данных о погоде в ответе
    class WeatherResponse
    {
        // Метод для получения данных о погоде. Параметр: кол-во запрашиваемых дней
        public static WeatherData getData(int days)
        {
            // Полная ссылка запроса, содержащая сам текст запроса, данные о городе, кол-ве дней, персональный ключ, тип запроса
            string url = "http://api.openweathermap.org/data/2.5/forecast/daily?q=Petrozavodsk&units=metric&lang=ru&cnt=" + days + "&appid=6fa095c114c44b8983cf448560847507";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string response;
            // Создаем ридер для считывания полученной запросом информации
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            // Десериализируем JSON объект и возвращаем его
            WeatherData weatherResponse = JsonConvert.DeserializeObject<WeatherData>(response);
            return weatherResponse;
        }

    }
}
