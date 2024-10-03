using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoWebAspL3.Models
{
    public class Etudiant
    {      
        [Key]
        public int EtudiantId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        [DisplayName("Nom Etudiant")]
        public string etuNom { get; set; } = "";

        [Column(TypeName = "varchar(50)")]
        [DisplayName("prenom Etudiant")]
        public string etuPrenom { get; set; } = "";

        public string etuSexe { get; set; } = "";

        public DateTime etuDateNaiss { get; set; }

        [MaxLength(50)]
        public string etuEmail { get; set; } = "";

        public int etuCotisation { get; set; }

        [MaxLength(100)]
        public string cheminImage { get; set; } = "";

        public int CategorieId { get; set; }
        public Categorie unCategorie { get; set; }

        public int CommuneId { get; set; }
        public Commune unCommune { get; set; }
        public virtual IList<Quittance> listQuittances { get; set; }
    }
}
