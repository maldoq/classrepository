using System.ComponentModel.DataAnnotations;

namespace TutoWebAspL3.Models
{
    public class Commune
    {
        [Key]
        public int CommuneId { get; set; }
        public string comNom { get; set; } = "";
    }
}
