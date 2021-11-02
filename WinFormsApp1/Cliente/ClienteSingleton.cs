using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Front.Cliente
{
    class ClienteSingleton
    {
        private static ClienteSingleton instancia;
        private HttpClient cliente;
        

        private ClienteSingleton()
        {
            cliente = new HttpClient();
        }

        public static ClienteSingleton GetInstancia()
        {
            if (instancia == null)
                instancia = new ClienteSingleton();
            return instancia;
        }

        public async Task<string> GetAsync(string url)
        {
            var result = await cliente.GetAsync(url);
            var content = "";
            if (result.IsSuccessStatusCode)
                content = await result.Content.ReadAsStringAsync();
            return content;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, string clienteJson)
        {
            var result = await cliente.PostAsync(url, new StringContent(clienteJson, Encoding.UTF8, "application/json"));
            return result;
        }




        //private async void button1_Click(object sender, EventArgs e)
        //{
        //    string url = "http://localhost:59453/api/Cliente";
        //    using (var cliente = new HttpClient())
        //    {
        //        var json = JsonConvert.SerializeObject(new Cliente
        //        {
        //            nombre = txtNombre.Text,
        //            apellido = txtApellido.Text,
        //            dni = long.Parse(txtDni.Text),
        //            FechaAlta = DateTime.Parse(txtFecha.Text)
        //        });

        //        var result = await cliente.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        //    }
        //}





        //private async void btnDelete_Click(object sender, EventArgs e)
        //{
        //    long dni = long.Parse(txtDni.Text); 
        //    string url = "http://localhost:59453/api/Cliente/" + dni;
        //    using (var cliente = new HttpClient())

        //    using (var result = await cliente.DeleteAsync(url))

        //    {
        //        result.EnsureSuccessStatusCode();
        //        Console.WriteLine("success");
        //    }

        //}

        //private async void Consultar()
        //{
        //    string url = "http://localhost:59453/api/Cliente";
        //    using (var cliente = new HttpClient())
        //    {
        //        var result = await cliente.GetAsync(url);
        //        var content = await result.Content.ReadAsStringAsync();
        //        List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
        //    }
        //}

        //private async void ConsultarPorDni()
        //{
        //    long dni = long.Parse(txtDni.Text);
        //    string url = "http://localhost:59453/api/Cliente" + dni;
        //    using (var cliente = new HttpClient())
        //    {
        //        var result = await cliente.GetAsync(url);
        //        var content = await result.Content.ReadAsStringAsync();
        //        List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(content);
        //    }
        //}
    }
    
}
