using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Domain
{
    public partial class CanchitaDbContext : DbContext
    {
        public CanchitaDbContext()
        {
        }

        public CanchitaDbContext(DbContextOptions<CanchitaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TAlquiler> TAlquiler { get; set; }
        public virtual DbSet<TCancha> TCancha { get; set; }
        public virtual DbSet<TCliente> TCliente { get; set; }
        public virtual DbSet<TDepartamento> TDepartamento { get; set; }
        public virtual DbSet<TDistrito> TDistrito { get; set; }
        public virtual DbSet<TImagen> TImagen { get; set; }
        public virtual DbSet<TLocal> TLocal { get; set; }
        public virtual DbSet<TLocalServicio> TLocalServicio { get; set; }
        public virtual DbSet<TPrecio> TPrecio { get; set; }
        public virtual DbSet<TProvincia> TProvincia { get; set; }
        public virtual DbSet<TServicio> TServicio { get; set; }
        public virtual DbSet<TTurno> TTurno { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source = WILSON_PC\\SQLEXPRESS; Initial Catalog = Canchita; Integrated Security = True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TAlquiler>(entity =>
            {
                entity.HasKey(e => e.AlquiId);

                entity.ToTable("T_alquiler");

                entity.Property(e => e.AlquiId)
                    .HasColumnName("alqui_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AlquiAdelanto)
                    .HasColumnName("alqui_adelanto")
                    .HasColumnType("money");

                entity.Property(e => e.AlquiCancelado)
                    .HasColumnName("alqui_cancelado")
                    .HasColumnType("money");

                entity.Property(e => e.AlquiEstado)
                    .IsRequired()
                    .HasColumnName("alqui_estado")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AlquiFechaReserva)
                    .HasColumnName("alqui_fecha_reserva")
                    .HasColumnType("datetime");

                entity.Property(e => e.AlquiHoraFin).HasColumnName("alqui_hora_fin");

                entity.Property(e => e.AlquiHoraInicio).HasColumnName("alqui_hora_inicio");

                entity.Property(e => e.AlquiPagoReal)
                    .HasColumnName("alqui_pago_real")
                    .HasColumnType("money");

                entity.Property(e => e.CanchaId).HasColumnName("cancha_id");

                entity.Property(e => e.CliId).HasColumnName("cli_id");

                entity.HasOne(d => d.Cancha)
                    .WithMany(p => p.TAlquiler)
                    .HasForeignKey(d => d.CanchaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_alquiler_T_cancha");

                entity.HasOne(d => d.Cli)
                    .WithMany(p => p.TAlquiler)
                    .HasForeignKey(d => d.CliId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_alquiler_T_cliente");
            });

            modelBuilder.Entity<TCancha>(entity =>
            {
                entity.HasKey(e => e.CanchaId);

                entity.ToTable("T_cancha");

                entity.Property(e => e.CanchaId)
                    .HasColumnName("cancha_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CanchaDescripcion)
                    .IsRequired()
                    .HasColumnName("cancha_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CanchaTipo)
                    .IsRequired()
                    .HasColumnName("cancha_tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalId).HasColumnName("local_id");

                entity.HasOne(d => d.Local)
                    .WithMany(p => p.TCancha)
                    .HasForeignKey(d => d.LocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_cancha_T_local");
            });

            modelBuilder.Entity<TCliente>(entity =>
            {
                entity.HasKey(e => e.CliId);

                entity.ToTable("T_cliente");

                entity.Property(e => e.CliId)
                    .HasColumnName("cli_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CliApellidos)
                    .IsRequired()
                    .HasColumnName("cli_apellidos")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CliEmail)
                    .HasColumnName("cli_email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CliNombres)
                    .IsRequired()
                    .HasColumnName("cli_nombres")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CliTelefono)
                    .IsRequired()
                    .HasColumnName("cli_telefono")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TDepartamento>(entity =>
            {
                entity.HasKey(e => e.DptoId);

                entity.ToTable("T_departamento");

                entity.Property(e => e.DptoId)
                    .HasColumnName("dpto_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DtoNombre)
                    .IsRequired()
                    .HasColumnName("dto_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TDistrito>(entity =>
            {
                entity.HasKey(e => e.DistId);

                entity.ToTable("T_distrito");

                entity.Property(e => e.DistId)
                    .HasColumnName("dist_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DistDescripcion)
                    .IsRequired()
                    .HasColumnName("dist_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProvId).HasColumnName("prov_id");

                entity.HasOne(d => d.Prov)
                    .WithMany(p => p.TDistrito)
                    .HasForeignKey(d => d.ProvId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_distrito_T_provincia");
            });

            modelBuilder.Entity<TImagen>(entity =>
            {
                entity.HasKey(e => e.ImaId);

                entity.ToTable("T_imagen");

                entity.Property(e => e.ImaId)
                    .HasColumnName("ima_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CanchaId).HasColumnName("cancha_id");

                entity.Property(e => e.ImaUrl)
                    .IsRequired()
                    .HasColumnName("ima_url")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocServId).HasColumnName("loc_serv_id");

                entity.Property(e => e.LocalId).HasColumnName("local_id");

                entity.HasOne(d => d.Cancha)
                    .WithMany(p => p.TImagen)
                    .HasForeignKey(d => d.CanchaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_imagen_T_cancha");

                entity.HasOne(d => d.LocServ)
                    .WithMany(p => p.TImagen)
                    .HasForeignKey(d => d.LocServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_imagen_T_local_servicio");

                entity.HasOne(d => d.Local)
                    .WithMany(p => p.TImagen)
                    .HasForeignKey(d => d.LocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_imagen_T_local");
            });

            modelBuilder.Entity<TLocal>(entity =>
            {
                entity.HasKey(e => e.LocalId);

                entity.ToTable("T_local");

                entity.Property(e => e.LocalId)
                    .HasColumnName("local_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocalDescripcion)
                    .IsRequired()
                    .HasColumnName("local_descripcion")
                    .IsUnicode(false);

                entity.Property(e => e.LocalDireccion)
                    .IsRequired()
                    .HasColumnName("local_direccion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalDist).HasColumnName("local_dist");

                entity.Property(e => e.LocalHoraApertura).HasColumnName("local_hora_apertura");

                entity.Property(e => e.LocalHoraCierre).HasColumnName("local_hora_cierre");

                entity.Property(e => e.LocalLatitud)
                    .IsRequired()
                    .HasColumnName("local_latitud")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LocalLongitud)
                    .IsRequired()
                    .HasColumnName("local_longitud")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LocalNombre)
                    .IsRequired()
                    .HasColumnName("local_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LocalTelefono)
                    .IsRequired()
                    .HasColumnName("local_telefono")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.LocalDistNavigation)
                    .WithMany(p => p.TLocal)
                    .HasForeignKey(d => d.LocalDist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_local_T_distrito");
            });

            modelBuilder.Entity<TLocalServicio>(entity =>
            {
                entity.HasKey(e => e.LocServId);

                entity.ToTable("T_local_servicio");

                entity.Property(e => e.LocServId)
                    .HasColumnName("loc_serv_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocalId).HasColumnName("local_id");

                entity.Property(e => e.ServId).HasColumnName("serv_id");

                entity.HasOne(d => d.Local)
                    .WithMany(p => p.TLocalServicio)
                    .HasForeignKey(d => d.LocalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_local_servicio_T_local");

                entity.HasOne(d => d.Serv)
                    .WithMany(p => p.TLocalServicio)
                    .HasForeignKey(d => d.ServId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_local_servicio_T_servicio");
            });

            modelBuilder.Entity<TPrecio>(entity =>
            {
                entity.HasKey(e => e.PrecId);

                entity.ToTable("T_precio");

                entity.Property(e => e.PrecId)
                    .HasColumnName("prec_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CanchaId).HasColumnName("cancha_id");

                entity.Property(e => e.PrecMonto)
                    .HasColumnName("prec_monto")
                    .HasColumnType("money");

                entity.Property(e => e.TurnoId).HasColumnName("turno_id");

                entity.HasOne(d => d.Cancha)
                    .WithMany(p => p.TPrecio)
                    .HasForeignKey(d => d.CanchaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_precio_T_cancha");

                entity.HasOne(d => d.Turno)
                    .WithMany(p => p.TPrecio)
                    .HasForeignKey(d => d.TurnoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_precio_T_turno");
            });

            modelBuilder.Entity<TProvincia>(entity =>
            {
                entity.HasKey(e => e.ProvId);

                entity.ToTable("T_provincia");

                entity.Property(e => e.ProvId)
                    .HasColumnName("prov_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DtoId).HasColumnName("dto_id");

                entity.Property(e => e.ProvNombre)
                    .IsRequired()
                    .HasColumnName("prov_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Dto)
                    .WithMany(p => p.TProvincia)
                    .HasForeignKey(d => d.DtoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_provincia_T_departamento");
            });

            modelBuilder.Entity<TServicio>(entity =>
            {
                entity.HasKey(e => e.ServId);

                entity.ToTable("T_servicio");

                entity.Property(e => e.ServId)
                    .HasColumnName("serv_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServNombre)
                    .IsRequired()
                    .HasColumnName("serv_nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TTurno>(entity =>
            {
                entity.HasKey(e => e.TurnoId);

                entity.ToTable("T_turno");

                entity.Property(e => e.TurnoId)
                    .HasColumnName("turno_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.TurnoDescripcion)
                    .IsRequired()
                    .HasColumnName("turno_descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TurnoHorarioFin).HasColumnName("turno_horario_fin");

                entity.Property(e => e.TurnoHorarioInicio).HasColumnName("turno_horario_inicio");
            });
        }
    }
}
