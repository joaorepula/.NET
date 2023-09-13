namespace API.Models;
﻿using System.ComponentModel.DataAnnotations;
public class Produto{
    [Key]
    [Required]
    public int Idproduto {get; set;}
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public int Quantidade { get; set; }
    public double Preco { get; set; }
    public DateTime CriadoEm { get; set; }
}