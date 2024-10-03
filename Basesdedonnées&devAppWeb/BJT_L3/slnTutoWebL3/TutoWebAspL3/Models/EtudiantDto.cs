using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace TutoWebAspL3.Models
{
    public class EtudiantDto
    {

        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nom Etudiant")]
        public string etuNom { get; set; } = "";

        [Column(TypeName = "varchar(50)")]
        [DisplayName("prenom Etudiant")]
        public string etuPrenom { get; set; } = "";
        [Required]
        public string etuSexe { get; set; } = "";
        [Required]
        public DateTime etuDateNaiss { get; set; }

        [Required,MaxLength(50)]
        public string etuEmail { get; set; } = "";
        public int etuCotisation { get; set; } = 0;

        public IFormFile? ImageFile { get; set; }
        [Required]
        public int CategorieId { get; set; }
        [Required]
        public int CommuneId { get; set; }
    }
}
