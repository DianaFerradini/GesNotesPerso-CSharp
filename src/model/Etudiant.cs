class Etudiant
{
    private string? matricule;
    private string nom;
    private string prenom;
    private List<double>? notes = new();

    public Etudiant(string nom, string prenom)
    {
        this.nom = nom;
        this.prenom = prenom;
    }

    public string? GetMatricule()
    {
        return matricule;
    }

    public void SetMatricule(string matricule)
    {
        this.matricule = matricule;
    }

    public string? GetNom()
    {
        return nom;
    }

    public void SetNom(string nom)
    {
        this.nom = nom;
    }

    public string? GetPrenom()
    {
        return prenom;
    }

    public void SetPrenom(string prenom)
    {
        this.prenom = prenom;
    }

    public List<double>? GetNotes()
    {
        return notes;
    }

    public void AddNote(double note)
    {
        notes?.Add(note);
    }

    public override string ToString()
    {
        return $"Matricule : {matricule} - Nom : {nom} - Prénom : {prenom}";
    }
}
