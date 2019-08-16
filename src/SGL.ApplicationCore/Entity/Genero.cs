using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGL.ApplicationCore.Entity
{
    public class Genero
    {
        public int GeneroId { get; set; }
        [Display(Name = "Gênero")]
        public string Descricao { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
