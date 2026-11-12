public class UserView : IUserView
{
    private IEtudiantService _service;

    public UserView(IEtudiantService service)
    {
        _service = service;
    }

    public void AfficherEtudiants()
    {
        throw new NotImplementedException();
    }

    public void AfficherNotes()
    {
        throw new NotImplementedException();
    }

    public string LireChaine()
    {
        throw new NotImplementedException();
    }

    public double LireDouble()
    {
        throw new NotImplementedException();
    }

    public int Menu()
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

    public void SaisieEtudiant()
    {
        throw new NotImplementedException();
    }

    public void SaisieNote()
    {
        throw new NotImplementedException();
    }
}