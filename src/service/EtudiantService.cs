public class EtudiantService : IEtudiantService
{
    private IEtudiantRepository repo;

    private int compteur = 0;

    public EtudiantService(IEtudiantRepository repo)
    {
        this.repo = repo;
    }

    public bool SaveEtudiant(Etudiant et)
    {
        string matricule = GenererMatricule();
        et.SetMatricule(matricule);
        return repo.InsertEtudiant(et);
    }

    private string GenererMatricule()
    {
        compteur++;
        return $"ism{compteur}";
    }
}