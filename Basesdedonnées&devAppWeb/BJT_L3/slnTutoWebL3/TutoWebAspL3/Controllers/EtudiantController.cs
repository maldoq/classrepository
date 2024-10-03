using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel.Design;
using TutoWebAspL3.Models;
using TutoWebAspL3.Services;

namespace TutoWebAspL3.Controllers
{
    public class EtudiantController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public EtudiantController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }
        public IActionResult Index()
        {
            /*
             * var vEtudiants=context.Etudiant.ToList();
             */  //on déclare un variable "vEtudiants" qui va recevoir les enregistrements de la table ETUDIANT
            var vEtudiants = context.Etudiant.OrderByDescending(p=>p.EtudiantId).ToList(); //triée selon le nom
            return View(vEtudiants);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EtudiantDto unEtuDto)
        {
            if(unEtuDto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image obligatoire!");
            }
            if (!ModelState.IsValid) 
            { 
                return View(unEtuDto);
            }

            //sauvegarde de l'image dans le dossier "Images"
            string vNomImage = DateTime.Now.ToString("yyyyMMddssfff");
            vNomImage += Path.GetExtension(unEtuDto.ImageFile!.FileName);

            string CheminComplet = environment.WebRootPath + "/Images/" + vNomImage;
            using (var stream = System.IO.File.Create(CheminComplet))
            { 
                unEtuDto.ImageFile.CopyTo(stream);
            }

            //On enregistre l"étudiant saisie (unEtuDto) dans la BD
            //on crée  donc un objet Etudiant et on récupere les elts de unEtuDto

            Etudiant etudiant = new Etudiant()
            {
                etuNom = unEtuDto.etuNom,
                etuPrenom = unEtuDto.etuPrenom,
                etuSexe = unEtuDto.etuSexe,
                etuDateNaiss = unEtuDto.etuDateNaiss,
                etuEmail = unEtuDto.etuEmail,
                cheminImage = vNomImage,
                CategorieId = unEtuDto.CategorieId,
                CommuneId = unEtuDto.CommuneId,
            };
            context.Etudiant.Add(etudiant);
            context.SaveChanges();
            return RedirectToAction("Index","Etudiant");
        }

        public IActionResult Edit(int id)
        {
            var unEtudiant = context.Etudiant.Find(id);
            if(unEtudiant == null)
            {
                return RedirectToAction("Index", "Etudiant");
            }

            //crée un EtudiantDto avec les donnees de Etudiant
            var EtudiantDto = new EtudiantDto()
            {
                etuNom = unEtudiant.etuNom,
                etuPrenom = unEtudiant.etuPrenom,
                etuSexe = unEtudiant.etuSexe,
                etuDateNaiss = unEtudiant.etuDateNaiss,
                etuEmail = unEtudiant.etuEmail,
                CategorieId = unEtudiant.CategorieId,
                CommuneId = unEtudiant.CommuneId,
            };

            ViewData["EtudiantId"] = unEtudiant.EtudiantId;
            ViewData["cheminImage"] = unEtudiant.cheminImage;
            return View(EtudiantDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, EtudiantDto unETudiantDto)
        {
            var unEtudiant = context.Etudiant.Find(id);
            if (unEtudiant == null)
            {
                return RedirectToAction("Index", "Etudiant");
            }

            if (!ModelState.IsValid)
            {
                return View(unETudiantDto);
            }

            //Mise-à-jour de l'image dans le dossier "Images" au cas où on l'image a été modifiée
            string vNewNomImage = unEtudiant.cheminImage;
            if(unETudiantDto.ImageFile !=null)
            {
                vNewNomImage = DateTime.Now.ToString("yyyyMMddssfff");
                vNewNomImage += Path.GetExtension(unETudiantDto.ImageFile!.FileName);

                string CheminComplet = environment.WebRootPath + "/Images/" + vNewNomImage;
                using (var stream = System.IO.File.Create(CheminComplet))
                {
                    unETudiantDto.ImageFile.CopyTo(stream);
                }

                //Supprime l'ancienne image 
                string OldImageFullPath=environment.WebRootPath + "/Images/" + unEtudiant.cheminImage;
                System.IO.File.Delete(OldImageFullPath);
            }

            unEtudiant.etuNom = unETudiantDto.etuNom;
            unEtudiant.etuPrenom = unETudiantDto.etuPrenom;
            unEtudiant.etuSexe = unETudiantDto.etuSexe;
            unEtudiant.etuDateNaiss = unETudiantDto.etuDateNaiss;
            unEtudiant.etuEmail = unETudiantDto.etuEmail;
            unEtudiant.etuCotisation = unETudiantDto.etuCotisation;
            unEtudiant.cheminImage = vNewNomImage;
            unEtudiant.CategorieId = unETudiantDto.CategorieId;
            unEtudiant.CommuneId = unETudiantDto.CommuneId;

            context.SaveChanges();
            return RedirectToAction("Index", "Etudiant");           
        }

        public IActionResult Delete(int id)
        {
            var unEtudiant = context.Etudiant.Find(id);

            if(unEtudiant!=null)
            {
                string CheminComplet = environment.WebRootPath + "/Images/" + unEtudiant.cheminImage;
                System.IO.File.Delete(CheminComplet);

                context.Etudiant.Remove(unEtudiant);
                context.SaveChanges(true);
            }
            return RedirectToAction("Index", "Etudiant");
        }


    }
}
