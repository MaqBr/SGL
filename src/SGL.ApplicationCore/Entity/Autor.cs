using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGL.ApplicationCore.Entity
{
    public class Autor
    {
        public int AutorId { get; set; }
        [Display(Name = "Autor")]
        public string Nome { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
