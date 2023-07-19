namespace newLive.Models;

public partial class Section
{
    public int SectionsId { get; set; }

    public string? Sectionsname { get; set; }

    public virtual ICollection<Doctorssection> Doctorssections { get; set; } = new List<Doctorssection>();
}
