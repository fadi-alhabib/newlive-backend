using Microsoft.EntityFrameworkCore;

namespace newLive.Models;

public partial class PatientinfoContext : DbContext
{
    public PatientinfoContext()
    {
    }

    public PatientinfoContext(DbContextOptions<PatientinfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booktbl> Booktbls { get; set; }

    public virtual DbSet<Dignose> Dignoses { get; set; }

    public virtual DbSet<Doctorsinfo> Doctorsinfos { get; set; }

    public virtual DbSet<Doctorssection> Doctorssections { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Patientinfo> Patientinfos { get; set; }

    public virtual DbSet<Section> Section { get; set; }


    public virtual DbSet<Surgerytblinfo> Surgerytblinfos { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlServer("Server=DESKTOP-G34860D\\SQLEXPRESS;Database=patientinfo;user id=hp;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booktbl>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("booktbl");

            entity.Property(e => e.Bookdate)
                .HasColumnType("date")
                .HasColumnName("bookdate");
            entity.Property(e => e.Bookdoctor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookdoctor");
            entity.Property(e => e.Bookname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("bookname");
            entity.Property(e => e.Booksection)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("booksection");
        });

        modelBuilder.Entity<Dignose>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("dignoses");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient id");
            entity.Property(e => e.Digognses)
                .IsUnicode(false)
                .HasColumnName("digognses");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("doctor name");
            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patient name");
        });

        //modelBuilder.Entity<Doctorsection>(entity =>
        //{
        //    entity.HasKey(e => e.DoctorId).HasName("PK__doctorse__722485966DD144CD");

        //    entity.ToTable("doctorsection");

        //    entity.Property(e => e.DoctorId)
        //        .ValueGeneratedNever()
        //        .HasColumnName("doctorID");
        //    entity.Property(e => e.Doctorname)
        //        .HasMaxLength(1)
        //        .IsUnicode(false)
        //        .HasColumnName("doctorname");
        //    entity.Property(e => e.SectionId).HasColumnName("sectionID");

        //    entity.HasOne(d => d.Section).WithMany(p => p.Doctorsections)
        //        .HasForeignKey(d => d.SectionId)
        //        .HasConstraintName("FK__doctorsec__secti__74AE54BC");
        //});

        modelBuilder.Entity<Doctorsinfo>(entity =>
        {
            entity.HasKey(e => e.DoctorId);

            entity.ToTable("doctorsinfos");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedNever()
                .HasColumnName("Doctor_id");
            entity.Property(e => e.DAddress)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D-address");
            entity.Property(e => e.DEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_email");
            entity.Property(e => e.DGender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_gender");
            entity.Property(e => e.DPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_phone");
            entity.Property(e => e.DSpcelization)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_spcelization");
            entity.Property(e => e.DoctorAge).HasColumnName("Doctor_age");
            entity.Property(e => e.DoctorName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Doctor_name");
            entity.Property(e => e.HireDate)
                .HasColumnType("date")
                .HasColumnName("hire_date");
        });

        modelBuilder.Entity<Doctorssection>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctorss__722485961B1324B0");

            entity.ToTable("Doctorssection");

            entity.Property(e => e.DoctorId).HasColumnName("doctorID");
            entity.Property(e => e.Doctorname)
                .HasMaxLength(150)
                .HasColumnName("doctorname");
            entity.Property(e => e.SectionsId).HasColumnName("sectionsID");

            entity.HasOne(d => d.Sections).WithMany(p => p.Doctorssections)
                .HasForeignKey(d => d.SectionsId)
                .HasConstraintName("FK__Doctorsse__secti__0C85DE4D");
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("login");

            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
            entity.Property(e => e.Usertype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("usertype");
        });

        modelBuilder.Entity<Patientinfo>(entity =>
        {
            entity.HasKey(e => e.Patientid);

            entity.ToTable("patientinfos");

            entity.Property(e => e.Patientid)
                .ValueGeneratedNever()
                .HasColumnName("patientid");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("age");
            entity.Property(e => e.EMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E-mail");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.PatientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("patient-name");
            entity.Property(e => e.Phonenumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("phonenumber");
        });


        modelBuilder.Entity<Section>(entity =>
        {
            entity.HasKey(e => e.SectionsId).HasName("PK__sections__F7701F409D7F3BC6");

            entity.ToTable("sections");

            entity.Property(e => e.SectionsId).HasColumnName("sectionsID");
            entity.Property(e => e.Sectionsname)
            .HasMaxLength(150)
            .HasColumnName("sectionsname");
        });

        modelBuilder.Entity<Surgerytblinfo>(entity =>
        {
            entity.HasKey(e => e.PatientId);

            entity.ToTable("surgerytblinfos");

            entity.Property(e => e.PatientId)
                .ValueGeneratedNever()
                .HasColumnName("patient ID");
            entity.Property(e => e.DoctorIdName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("doctor ID&Name");
            entity.Property(e => e.SurgeryDate)
                .HasColumnType("date")
                .HasColumnName("surgery_date");
            entity.Property(e => e.SurgeryRoom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surgery_room");
            entity.Property(e => e.SurgeryTime).HasColumnName("surgery_time");
            entity.Property(e => e.SurgeryType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("surgery_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
