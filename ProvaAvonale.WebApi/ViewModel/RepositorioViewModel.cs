using ProvaAvonale.ApplicationService.Models;
using ProvaAvonale.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProvaAvonale.WebApi.Models.ViewModel
{
    public class RepositorioViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string NomeCompleto { get; set; }

        public string Privado { get; set; }

        public OwnerDTO Owner { get; set; }

        public string Descricao { get; set; }
        
        public string LanguagesUrl { get; set; }

        public IEnumerable<Linguagem> Linguagens { get; set; }

        public string ContributorsUrl { get; set; }
        public bool IsFavorito { get; set; }
        
        public IEnumerable<Contribuidor> Contribuidores { get; set; }

        public DateTime DataAtualizacao { get; set; }
    }
}