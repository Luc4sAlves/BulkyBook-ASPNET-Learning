﻿using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Controllers
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
//Classe que funciona como um modelo para uma table da database.