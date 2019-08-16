using SGL.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SGL.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SGLContext context)
        {
            if (context.Livros.Any())
            {
                return;
            }

            var autores = new Autor[]
            {
                new Autor {
                    Nome = "Autor 01",
                    Email = "autor1@teste.com"
                },

                 new Autor {
                    Nome = "Autor 02",
                    Email = "autor2@teste.com"
                }
            };

            context.AddRange(autores);

            var editoras = new Editora[]
            {
                new Editora {
                    Descricao = "Editora 1",
                    Email = "editora1@teste.com",
                },
               new Editora {
                    Descricao = "Editora 2",
                    Email = "editora2@teste.com",
                }
            };

            context.AddRange(editoras);

            var generos = new Genero[]
            {
                new Genero {
                    Descricao = "Genero 1"
                },
                new Genero {
                    Descricao = "Genero 2"
                }
            };

            context.AddRange(editoras);


            var links = new Link[]
            {
                new Link {
                    Descricao = "Link 1",
                    Url = "http://www.link1.com",
                    Icone = "~/Images/Icon1.png"
                },
                new Link {
                    Descricao = "Link 2",
                    Url = "http://www.link2.com",
                    Icone = "~/Images/Icon2.png"
                }
            };
            context.AddRange(links);


            var livros = new Livro[]
            {
                new Livro {
                    Titulo = "Titulo 01",
                    Descricao = "Descrição 01",
                    Capa = "~/Images/Capa1.png",
                    Autor = autores[0],
                    Editora = editoras[0],
                    Genero = generos[0],
                    Links = new List<Link> { links[0], links[1] },
                    Paginas = 3,
                    Sinopse = "Sinopse do livro título 01",
                    DataPublicacao = DateTime.Now
                },

                new Livro {
                    Titulo = "Titulo 02",
                    Descricao = "Descrição 02",
                    Capa = "~/Images/Capa2.png",
                    Autor = autores[1],
                    Editora = editoras[1],
                    Genero = generos[1],
                    Links = new List<Link> { links[0], links[1] },
                    Paginas = 5,
                    Sinopse = "Sinopse do livro título 02",
                    DataPublicacao = DateTime.Now
                },


            };

            context.AddRange(livros);
            context.SaveChanges();
        }
    }
}
