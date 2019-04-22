namespace PrototipoVendas.Web.Models
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ProdutoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]        
        public String Nome { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória", AllowEmptyStrings = false)]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto", AllowEmptyStrings = false)]
        public string Preco { get; set; }
        
        [DataType(DataType.Upload)]
        public IFormFile ImageUpload { get; set; }

        public string Foto { get; set; }
    }
}
