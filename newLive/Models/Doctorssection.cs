namespace newLive.Models;

public partial class Doctorssection
{
    public int DoctorId { get; set; }

    public string? Doctorname { get; set; }

    public int? SectionsId { get; set; }

    public virtual Section? Sections { get; set; }
}
