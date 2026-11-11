public interface Database {
    void CreateConnexion();
    Etudiant Insert(Etudiant etudiant);
    List<Etudiant> GetEtudiants();
}