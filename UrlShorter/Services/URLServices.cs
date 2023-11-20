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
            { URLToCreate.IdCategoria = _context.Categorias.SingleOrDefault(u => u.Name == categoria).Id; }
            else URLToCreate.IdCategoria = 1;



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




        //public void StoreUrlMapping(string longUrl, string shortUrl)

        //        //    // Almacena la asociación entre la URL larga y la URL corta en la base de datos
        //        //    // Debes implementar esta función según tu sistema de base de datos
        //        //    // Ejemplo ficticio:
        //        //    // using (var dbContext = new YourDbContext())
        //        {
        //            _context.URLs.Add(new URL { URLLong = longUrl, URLShort = shortUrl });
        //            _context.SaveChanges();
        //        }

        //public string CreateShortUrl(string longUrl)
        //{
        //    string shortUrl = ;

        //    // Verifica la unicidad de la URL corta en la base de datos (puedes adaptar esto a tu sistema de base de datos)
        //    bool isUnique = IsShortUrlUnique(shortUrl);

        //    if (isUnique)
        //    {
        //        // Almacena la asociación entre la URL larga y la URL corta en la base de datos
        //        StoreUrlMapping(longUrl, shortUrl);
        //        return shortUrl;
        //    }
        //    else
        //    {
        //        // En caso de conflicto, vuelve a intentar la generación de URL corta
        //        return CreateShortUrl(longUrl);
        //    }
        //}

        //private bool IsShortUrlUnique(string shortUrl)
        //{

        //    //    // Verifica la base de datos para asegurarte de que la URL corta sea única
        //    //    // Debes implementar esta función según tu sistema de base de datos
        //    //    // Puedes usar Entity Framework, Dapper u otras bibliotecas para acceder a la base de datos.
        //    //    // Devuelve verdadero si la URL corta es única y falsa si ya está en uso.
        //    //    // Ejemplo ficticio:
        //    //    // using (var dbContext = new YourDbContext())
        //    {
        //        return !_context.URLs.Any(u => u.URLShort == shortUrl);
        //    }
        //    return true;
        //    //}



        //}
    }
}
