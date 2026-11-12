public interface IDatabase {
    void CreateConnexion();
    bool Insert(Etudiant etudiant);
    List<Etudiant>? GetEtudiants();
}