public interface IEtudiantRepository
{
    List<Etudiant> FindAllEtudiants();
    Etudiant? FindEtudiantByMatricule(string matricule);
    bool InsertEtudiant(Etudiant etudiant);
}