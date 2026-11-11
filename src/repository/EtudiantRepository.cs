class EtudiantRepository : IEtudiantRepository
{
    public List<Etudiant> etudiants = new();

    public List<Etudiant> FindAllEtudiants()
    {
        return etudiants;
    }

    public Etudiant? FindEtudiantByMatricule(string matricule)
    {
        return etudiants.FirstOrDefault(e => e.GetMatricule() == matricule);
    }

    public bool InsertEtudiant(Etudiant etudiant)
    {
        etudiants.Add(etudiant);
        return true;
    }
}