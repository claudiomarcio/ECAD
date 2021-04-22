using Domain.Models.Entities;
using Infra.EntityConfiguration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using webapi.Controllers;

namespace webapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var dataContext = new ApplicationDbContext())
            {
                if(ApplicationDbContext.isCreated)
                {
                    GenerateGenders(dataContext);
                    GenerateCategorys(dataContext);
                    GenerateAuthors(dataContext);                  
                }               
            }
           
            BuildWebHost(args).Run();
        }

        private static void GenerateCategorys(ApplicationDbContext dataContext)
        {
            dataContext.Category.Add(new Category() { Name = "Autor" });
            dataContext.Category.Add(new Category() { Name = "Compositor" });
            dataContext.Category.Add(new Category() { Name = "Intérprete" });
            dataContext.Category.Add(new Category() { Name = "Músico" });
            dataContext.SaveChanges();
        }

        private static void GenerateGenders(ApplicationDbContext dataContext)
        {
            dataContext.Gender.Add(new Gender() { Name = "Samba" });
            dataContext.Gender.Add(new Gender() { Name = "Sertanejo" });
            dataContext.Gender.Add(new Gender() { Name = "Rock" });
            dataContext.Gender.Add(new Gender() { Name = "Pop" });
            dataContext.SaveChanges();
        }

        private static void GenerateAuthors(ApplicationDbContext dataContext)
        {
            var listAuthor = new List<string>();
            listAuthor.Add("Chiquinha Gonzaga");
            listAuthor.Add("Heitor Villa-Lobos");
            listAuthor.Add("Pixinguinha");
            listAuthor.Add("Ary Barroso");

            var categoryes = dataContext.Category.ToList();

            for (int i = 0; i < categoryes.Count; i++)
            {
                dataContext.Author.Add(new Author() { Name = listAuthor[i], Category = categoryes[i] });
            }

            dataContext.SaveChanges();
        }

        public static IWebHost BuildWebHost(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                .UseApplicationInsights()
                 .UseStartup<Startup>()
                 .UseIISIntegration()
                 .Build();

     
    }
}
