using BookClub.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BookClub.DAL
{
    public class MyDbContext : DbContext
    {
        public DbSet<Name> Names { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<UserBooks> UserBooks { get; set; }

        

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Name>().HasData(
                new Name[]
                {
                new Name {  LoginID="Саша"},
                new Name {  LoginID="Вася"},
                new Name {  LoginID="Петя"},
                new Name {  LoginID="Коля"},
                });
            modelBuilder.Entity<Book>().HasData(
               new Book[]
               {
                    new Book{ id =1, NameBook ="Программирование на C#"},
                    new Book{ id =2, NameBook ="Программирование на C++"},
                    new Book{ id =3, NameBook ="Программирование на GS"},
                    new Book{ id =4, NameBook ="Программирование на Java"},
                    new Book{ id =5, NameBook ="Программирование на Python"},
                    new Book{ id =6, NameBook ="Программирование на Ruby"},
                    new Book{ id =7, NameBook ="Программирование на Алгол"},
                    new Book{ id =8, NameBook ="Программирование на Rust"}
               });
            modelBuilder.Entity<UserBooks>().HasData(
               new UserBooks[]
               {
                   new UserBooks { id =1, LoginName ="Саша",  SelectedBook = "Программирование на C#"},
                   new UserBooks { id =2, LoginName ="Саша",  SelectedBook = "Программирование на C++"},
                   new UserBooks { id =3, LoginName ="Вася",  SelectedBook = "Программирование на C#"},
                   new UserBooks { id =4, LoginName ="Саша",  SelectedBook = "Программирование на GS"},
                   new UserBooks { id =5, LoginName ="Вася",  SelectedBook = "Программирование на C++"},
                   new UserBooks { id =6, LoginName ="Вася",  SelectedBook = "Программирование на Java"},
                   new UserBooks { id =7, LoginName ="Саша",  SelectedBook = "Программирование на Java"},
                   new UserBooks { id =8, LoginName ="Саша",  SelectedBook = "Программирование на Python"},
                   new UserBooks { id =9, LoginName ="Петя",  SelectedBook = "Программирование на Rust"},
                   new UserBooks { id =10, LoginName ="Саша",  SelectedBook = "Программирование на Rust"},
                   new UserBooks { id =11, LoginName ="Петя",  SelectedBook = "Программирование на C#"}
               });
        }


    }
}
