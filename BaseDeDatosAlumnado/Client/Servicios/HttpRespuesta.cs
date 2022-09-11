﻿namespace BaseDeDatosAlumnado.Client.Servicios
{
    public class HttpRespuesta<T>
    {
        public T Respuesta { get; }
        public bool Error { get; }
        public HttpResponseMessage httpResponseMessage { get; }
        public HttpRespuesta(T respuesta,
                             bool error,
                             HttpResponseMessage httpResponseMessage)
        {
            Respuesta = respuesta;
            Error = error;
            this.httpResponseMessage = httpResponseMessage;
        }

        public async Task<string> GetBody()
        {
            var resp = await httpResponseMessage.Content.ReadAsStringAsync();
            return resp;
        }
    }
}
