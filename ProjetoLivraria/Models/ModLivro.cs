﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ProjetoLivraria.Models
{
    public class ModLivro
    {
        [DisplayName("Código do Livro")]
        public string codLivro { get; set; }
        [DisplayName("Nome do Livro")]

        public string nomeLivro { get; set; }

        public string codAutor { get; set; }
        [DisplayName("Nome do Autor")]

        public string nomeAutor { get; set; }
    }
}