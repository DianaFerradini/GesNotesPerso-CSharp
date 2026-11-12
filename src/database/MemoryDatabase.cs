public class DatabaseMemory : IDatabase 
{
    //pattern singleton
    private static DatabaseMemory? _instance = null;

    private DatabaseMemory() { }

    public static DatabaseMemory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new DatabaseMemory();
            }
            return _instance;
        }
    }

    //database
    private List<Etudiant>? _etudiants;

    public void CreateConnexion()
    {
        _etudiants = new();
    }

    public bool Insert(Etudiant etudiant)
    {
        _etudiants?.Add(etudiant);
        return true;
    }

    public List<Etudiant>? GetEtudiants()
    {
        return _etudiants;
    }
}