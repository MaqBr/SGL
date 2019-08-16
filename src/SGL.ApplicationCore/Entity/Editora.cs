using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGL.ApplicationCore.Entity
{
    public class Editora
    {
        public int EditoraId { get; set; }
        [Display(Name = "Editora")]
        public string Descricao { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }
    }
}
