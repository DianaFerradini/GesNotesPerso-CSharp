public class EtudiantService
{
    private IEtudiantRepository repo;

    public EtudiantService(IEtudiantRepository repo)
    {
        this.repo = repo;
    }
    private int compteur = 0;

    public bool SaveEtudiant(Etudiant et)
    {
        string matricule = GenererMatricule();
        et.SetMatricule(matricule);
        repo.InsertEtudiant(et);
        return true;
    }

    private string GenererMatricule()
    {
        compteur++;
        return $"ism{compteur}";
    }

    
}