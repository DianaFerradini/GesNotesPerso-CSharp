public class EtudiantService : IEtudiantService
{
    private IEtudiantRepository _repo;

    private int _compteur = 0;

    public EtudiantService(IEtudiantRepository repo)
    {
        _repo = repo;
    }

    public string GenererMatricule()
    {
        _compteur++;
        return $"ism{_compteur}";
    }

    public bool SaveEtudiant(Etudiant et)
    {
        et.SetMatricule(GenererMatricule());
        return _repo.InsertEtudiant(et);
    }
}