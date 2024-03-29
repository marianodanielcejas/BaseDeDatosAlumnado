﻿using System.Text;
using System.Text.Json;

namespace BaseDeDatosAlumnado.Client.Servicios
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient http;

        public HttpService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpRespuesta<T>> Get<T>(string url)
        {
            var respuestaHttp = await http.GetAsync(url);

            if (respuestaHttp.IsSuccessStatusCode)
            {
                var respuesta = await DeserealizarRespuesta<T>(respuestaHttp);
                return new HttpRespuesta<T>(respuesta,
                           false,
                           respuestaHttp);
            }
            else
            {
                return new HttpRespuesta<T>(default,
                                           true,
                                           respuestaHttp);
            }

        }

        public async Task<HttpRespuesta<object>> Post<T>(string url, T enviar)
        {
            try
            {
                var enviarJSON = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJSON,
                                                      Encoding.UTF8,
                                                      "application/json");
                var respuestaHTTP = await http.PostAsync(url, enviarContent);
                return new HttpRespuesta<object>(null,
                                                 !respuestaHTTP.IsSuccessStatusCode,
                                                 respuestaHTTP);
            }
            catch (System.Exception e){throw;}

        }

        public async Task <HttpRespuesta<object>> Put<T> (string url, T enviar)
        {
            try
            {
                var enviarJSON = JsonSerializer.Serialize(enviar);
                var enviarContent = new StringContent(enviarJSON,
                                                      Encoding.UTF8,
                                                      "application/json");
                var respuestaHTTP = await http.PutAsync(url, enviarContent);
                return new HttpRespuesta<object>(null,
                                                 !respuestaHTTP.IsSuccessStatusCode,
                                                 respuestaHTTP);
            }
            catch (System.Exception e) { throw; }
        }

        public async Task<HttpRespuesta<object>> Delete (string url)
        {
            var respuestaHTTP = await http.DeleteAsync(url);

            return new HttpRespuesta<object>(null,
                                             !respuestaHTTP.IsSuccessStatusCode,
                                             respuestaHTTP);
        }
        private async Task<T> DeserealizarRespuesta<T>(HttpResponseMessage httpRespuesta)
        {
            var RespuestaString = await httpRespuesta.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(RespuestaString,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }
    }
}
