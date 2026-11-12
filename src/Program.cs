class Program
{
    public static void Main(string[] args)
    {
        //factory
        IDatabase database = DatabaseMemory.Instance;
        IEtudiantRepository repository = new EtudiantRepository(database);
        IEtudiantService service = new EtudiantService(repository);
        IUserView view = new UserView(service);

        int choix;
        do
        {
            choix = View.Menu();
            switch (choix)
            {
                case 0: //sortir
                    Console.WriteLine("Au revoir.");
                    break;

                case 1: //ajouter etudiant
                    Etudiant et = View.SaisieEtudiant();
                    bool success = Service.SaveEtudiant(et);
                    if (success)
                    {
                        Console.WriteLine("Etudiant ajouté avec succès.");
                    }
                    else
                    {
                        Console.WriteLine("Erreur.");
                    }
                    break;

                case 2: //lister etudiants
                    List<Etudiant> etudiants = Service.FindAllEtudiants();
                    View.AfficherEtudiants(etudiants);
                    break;

                case 3: //ajouter une note à un etudiant
                    Etudiant? etudiantRecherche;
                    do
                    { 
                        string matricule = View.LireChaine("Saisir le matricule de l'étudiant : ");
                        etudiantRecherche = Service.FindEtudiantByMatricule(matricule);
                        if (etudiantRecherche is null)
                        {
                            Console.WriteLine("Ce matricule ne correspond à aucun étudiant.");
                        }
                        else
                        {
                            double note = View.LireDouble("Saisir la note : ");
                            etudiantRecherche.AddNote(note);
                        }
                    } while (etudiantRecherche is null);
                    break;

                case 4: //lister les notes d'un etudiant
                    do
                    { 
                        string matricule = View.LireChaine("Saisir le matricule de l'étudiant : ");
                        etudiantRecherche = Service.FindEtudiantByMatricule(matricule);
                        if (etudiantRecherche is null)
                        {
                            Console.WriteLine("Ce matricule ne correspond à aucun étudiant.");
                        }
                        else
                        {
                            Console.WriteLine(etudiantRecherche.ToString());
                            List<double>? notes = etudiantRecherche.GetNotes();
                            if (notes?.Count() == 0)
                            {
                                Console.WriteLine("Pas de notes enregistrée pour cet étudiant.");
                            }
                            else
                            {
                                View.AfficherNotes(notes);
                            }
                        }
                    } while (etudiantRecherche is null);
                    break;

                default:
                    Console.WriteLine("Faire un choix entre 0 et 4.");
                    break;
            }
        } while (choix != 0);
    }
}
