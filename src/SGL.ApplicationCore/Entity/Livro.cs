using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SGL.ApplicationCore.Entity
{
    public class Livro
    {
        public int LivroId { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Titulo { get; set; }
        public int GeneroId { get; set; }
        public virtual Genero Genero { get; set; }
        [Display(Name = "Publicação")]
        public DateTime DataPublicacao { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public int Paginas { get; set; }
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
        public int EditoraId { get; set; }
        public virtual Editora Editora { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Sinopse { get; set; }
        [Required(ErrorMessage = "Obrigatório")]
        public string Capa { get; set; }
        public virtual ICollection<Link> Links { get; set; }
    }
}
