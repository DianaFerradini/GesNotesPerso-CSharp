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
                    Console.WriteLine("Au revoir");
                    break;

                case 1: //ajouter etudiant
                    Etudiant et = View.SaisieEtudiant();
                    bool success = Service.SaveEtudiant(et);
                    if (success)
                    {
                        Console.WriteLine("Etudiant ajouté avec succès");
                    }
                    else
                    {
                        Console.WriteLine("Erreur");
                    }
                    break;

                case 2: //lister etudiants
                    break;

                case 3:
                    break;

                case 4:
                    break;

                default:
                    Console.WriteLine("Faire un choix entre 0 et 4");
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
    private List<double>? notes;

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
            Console.WriteLine("3. Ajouter une note a un etudiant");
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
        } while (chaine == null);
        return chaine;
    }

    public static Etudiant SaisieEtudiant()
    {
        string nom = LireChaine("Saisir le nom :");
        string prenom = LireChaine("Saisir le prénom :");
        return new Etudiant(nom, prenom);
    }
}
