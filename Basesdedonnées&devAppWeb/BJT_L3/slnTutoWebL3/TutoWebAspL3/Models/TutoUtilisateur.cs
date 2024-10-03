using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutoWebAspL3.Models
{
    public class TutoUtilisateur
    {
        public int id { get; set; }
        public string userLogin { get; set; }="";

        public string userPassword { get; set; }="";
        public string userEmail { get; set; } = "";
        public DateOnly userDateNaiss { get; set; }

        public int userCotisation { get; set; } = 0;


        [Column(TypeName = "varchar(100)")]
        [DisplayName("Nom de image")]
        public required string NomImage { get; set; }


        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile FichierImage { get; set; }

    }
}
