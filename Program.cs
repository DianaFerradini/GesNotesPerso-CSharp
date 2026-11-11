class Program
{
    public static void Main(string[] args)
    {
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

class Etudiant
{
    private string? matricule;
    private string nom;
    private string prenom;
    private List<double>? notes = new();

    public Etudiant(string nom, string prenom)
    {
        this.nom = nom;
        this.prenom = prenom;
    }

    public string? GetMatricule()
    {
        return matricule;
    }

    public void SetMatricule(string matricule)
    {
        this.matricule = matricule;
    }

    public string? GetNom()
    {
        return nom;
    }

    public void SetNom(string nom)
    {
        this.nom = nom;
    }

    public string? GetPrenom()
    {
        return prenom;
    }

    public void SetPrenom(string prenom)
    {
        this.prenom = prenom;
    }

    public List<double>? GetNotes()
    {
        return notes;
    }

    public void AddNote(double note)
    {
        notes?.Add(note);
    }

    public override string ToString()
    {
        return $"Matricule : {matricule} - Nom : {nom} - Prénom : {prenom}";
    }
}

class Service
{
    private static List<Etudiant> etudiants = new();
    private static int compteur = 0;

    public static bool SaveEtudiant(Etudiant et)
    {
        string matricule = GenererMatricule();
        et.SetMatricule(matricule);
        etudiants.Add(et);
        return true;
    }

    private static string GenererMatricule()
    {
        compteur++;
        return $"ism{compteur}";
    }

    public static List<Etudiant> FindAllEtudiants()
    {
        return etudiants;
    }

    public static Etudiant? FindEtudiantByMatricule(string matricule)
    {
        return etudiants.FirstOrDefault(e => e.GetMatricule() == matricule);
    }
}

class View
{
    public static int Menu()
    {
        bool result = false;
        int choix = 0;
        do
        {
            Console.WriteLine("1. Ajouter un etudiant dans une liste");
            Console.WriteLine("2. Afficher la liste des étudiants");
            Console.WriteLine("3. Ajouter une note à un etudiant");
            Console.WriteLine("4. Lister les notes d'un etudiant");
            Console.WriteLine("0. Quitter");
            Console.WriteLine("Saisir votre choix : ");
            result = int.TryParse(Console.ReadLine(), out choix);
        } while (!result);
        return choix;
    }

    public static string LireChaine(string msg)
    {
        string? chaine;
        do
        {
            Console.WriteLine(msg);
            chaine = Console.ReadLine();
            if (chaine != null)
            {
                chaine = chaine.Trim();
            }
        } while (chaine == null);
        return chaine;
    }

    public static Etudiant SaisieEtudiant()
    {
        string nom = LireChaine("Saisir le nom :");
        string prenom = LireChaine("Saisir le prénom :");
        return new Etudiant(nom, prenom);
    }

    public static void AfficherEtudiants(List<Etudiant> etudiants)
    {
        etudiants.ForEach(e => Console.WriteLine(e.ToString()));
    }

    public static double LireDouble(string msg)
    {
        bool result = false;
        double choix = 0;
        do
        {
            Console.WriteLine(msg);
            result = double.TryParse(Console.ReadLine(), out choix);
        } while (!result);
        return choix;
    }

    public static void AfficherNotes(List<double>? notes)
    {
        Console.WriteLine("Notes :");
        notes?.ForEach(n => Console.WriteLine(n));
    }
}
