using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UrlShorter.Data;
using UrlShorter.entities;
using UrlShorter.Entities;

namespace UrlShorter.Services
{
    public class URLServices
    {
        private readonly URLShortContext _context;
        public URLServices(URLShortContext context)
        {
            _context = context;
        }

        public List<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public string CrearShortUrl(string url)
        {
            // Genera una cadena aleatoria para la URL corta
            StringBuilder shortUrl = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 6; i++)
            {
                string CharSet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                shortUrl.Append(CharSet[random.Next(CharSet.Length)]);
            }

            return shortUrl.ToString();
        }

        public string GuardarURL(string URLUser, string ShortURL, string? categoria, int IdUser)
        {
            

            URL URLToCreate = new URL();
            URLToCreate.URLLong = URLUser;
            URLToCreate.URLShort = ShortURL;
            URLToCreate.IdUser = IdUser;

            if (categoria != null)
            {

                try
                {
                    int IdCat = _context.Categorias.SingleOrDefault(u => u.Name == categoria).Id;
                    URLToCreate.IdCategoria = IdCat;
                }
                catch
                {
                    int IdCat = 3;
                    URLToCreate.IdCategoria = IdCat;
                }


            }


            else { URLToCreate.IdCategoria = 1; }



            _context.URLs.Add(URLToCreate);
            Console.WriteLine(URLToCreate.ToString());
            _context.SaveChanges();

            return URLToCreate.ToString();
        }

        public int SumarContador(string URLUser)
        {
            URL URLToCreate = new URL();
            if (URLUser.Length > 6)
                URLToCreate = _context.URLs.SingleOrDefault(u => u.URLLong == URLUser);
            else { URLToCreate = _context.URLs.SingleOrDefault(u => u.URLShort == URLUser); }
            URLToCreate.contador++;
            _context.URLs.Update(URLToCreate);
            _context.SaveChanges();

            return URLToCreate.contador;

        }

        public List<string> GetUrlsPorUsuario(int IdUserClient)
        {
            List<string> URLSPorUsuario = _context.URLs.Where(x=> x.IdUser == IdUserClient).Select(x=> x.URLLong).ToList();


            return URLSPorUsuario;
        }

        public string GetURLLongForShort(string URLCliente)
        {

            string URLLong = _context.URLs.SingleOrDefault(x => x.URLShort == URLCliente).URLLong;


            return URLLong ;
        }




        
    }
}
