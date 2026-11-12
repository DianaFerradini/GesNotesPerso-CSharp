public class EtudiantRepository : IEtudiantRepository
{
    private IDatabase _database;

    public EtudiantRepository(IDatabase database)
    {
        _database = database;
    }

    public List<Etudiant>? FindAllEtudiants()
    {
        return _database.GetEtudiants();
    }

    public Etudiant? FindEtudiantByMatricule(string matricule)
    {
        var etudiants = FindAllEtudiants();
        return etudiants?.FirstOrDefault(e => e.GetMatricule() == matricule);
    }

    public bool InsertEtudiant(Etudiant etudiant)
    {
        return _database.Insert(etudiant);
    }
}