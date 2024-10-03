namespace TutoWebAspL3.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        public string catDesignation { get; set; } = "";
        public virtual ICollection<Etudiant>? lesEtudiants { get; set; }
    }
}
