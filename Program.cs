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
                case 0:
                    break;

                case 1:
                    break;

                case 2:
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

}

class Service
{
    private static List<Etudiant> etudiants = new();
    private int compteur = 0;
}

class View
{
    public static int Menu() {
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
}
