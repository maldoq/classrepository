namespace TutoWebAspL3.Models
{
    public class Quittance
    {
        public int id { get; set; }
        public DateTime quitDate { get; set; } 
        public string quitLibelle { get; set; } = "";
        public int quitMontantEmis { get; set; }

        public int EtudiantId { get; set; }
        public  Etudiant unEtudiant { get; set; }
    }
}
