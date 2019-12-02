using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Sistema_Inventario_Computos.Models
{
    public partial class RegistroPiezasDBContext : DbContext
    {
        public RegistroPiezasDBContext()
        {
        }

        public RegistroPiezasDBContext(DbContextOptions<RegistroPiezasDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDepartamentos> TblDepartamentos { get; set; }
        public virtual DbSet<TblEstatus> TblEstatus { get; set; }
        public virtual DbSet<TblLocalidades> TblLocalidades { get; set; }
        public virtual DbSet<TblPedidos> TblPedidos { get; set; }
        public virtual DbSet<TblPiezas> TblPiezas { get; set; }
        public virtual DbSet<TblReemplazos> TblReemplazos { get; set; }
        public virtual DbSet<TblServicioTecnicos> TblServicioTecnicos { get; set; }
        public virtual DbSet<TblServicios> TblServicios { get; set; }
        public virtual DbSet<TblTecnicos> TblTecnicos { get; set; }
        public virtual DbSet<TblTipoPieza> TblTipoPieza { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost\\sqlserver;Initial Catalog=RegistroPiezasDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblDepartamentos>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PK__tblDepar__C225F98DE5006802");

                entity.ToTable("tblDepartamentos");

                entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");

                entity.HasOne(d => d.IdLocalidadNavigation)
                    .WithMany(p => p.TblDepartamentos)
                    .HasForeignKey(d => d.IdLocalidad)
                    .HasConstraintName("FK__tblDepart__idLoc__276EDEB3");
            });

            modelBuilder.Entity<TblEstatus>(entity =>
            {
                entity.HasKey(e => e.IdEstatus)
                    .HasName("PK__tblEstat__DCBE18B6B50EE5C3");

                entity.ToTable("tblEstatus");

                entity.HasIndex(e => e.Descripcion)
                    .HasName("UQ__tblEstat__92C53B6CD40FED61")
                    .IsUnique();

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblLocalidades>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad)
                    .HasName("PK__tblLocal__548E364E9478D030");

                entity.ToTable("tblLocalidades");

                entity.Property(e => e.IdLocalidad).HasColumnName("idLocalidad");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblPedidos>(entity =>
            {
                entity.HasKey(e => e.IdPedido)
                    .HasName("PK__tblPedid__A9F619B7AB6783CF");

                entity.ToTable("tblPedidos");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.FechaDevuelto).HasColumnType("datetime");

                entity.Property(e => e.FechaPedido).HasColumnType("datetime");

                entity.Property(e => e.FechaRecibido).HasColumnType("datetime");

                entity.Property(e => e.IdReemplazo).HasColumnName("idReemplazo");

                entity.HasOne(d => d.IdReemplazoNavigation)
                    .WithMany(p => p.TblPedidos)
                    .HasForeignKey(d => d.IdReemplazo)
                    .HasConstraintName("FK__tblPedido__idRee__3F466844");
            });

            modelBuilder.Entity<TblPiezas>(entity =>
            {
                entity.HasKey(e => e.IdPieza)
                    .HasName("PK__tblPieza__9A682C65110F69FB");

                entity.ToTable("tblPiezas");

                entity.Property(e => e.IdPieza).HasColumnName("idPieza");

                entity.Property(e => e.Ct)
                    .HasColumnName("CT")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.IdEstatus).HasColumnName("idEstatus");

                entity.Property(e => e.IdTipoPieza).HasColumnName("idTipoPieza");

                entity.Property(e => e.MacAddress)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.IdEstatusNavigation)
                    .WithMany(p => p.TblPiezas)
                    .HasForeignKey(d => d.IdEstatus)
                    .HasConstraintName("FK__tblPiezas__idEst__37A5467C");

                entity.HasOne(d => d.IdTipoPiezaNavigation)
                    .WithMany(p => p.TblPiezas)
                    .HasForeignKey(d => d.IdTipoPieza)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblPiezas__idTip__36B12243");
            });

            modelBuilder.Entity<TblReemplazos>(entity =>
            {
                entity.HasKey(e => e.IdReemplazo)
                    .HasName("PK__tblReemp__231CF19A9C7EC9FC");

                entity.ToTable("tblReemplazos");

                entity.Property(e => e.IdReemplazo).HasColumnName("idReemplazo");

                entity.Property(e => e.IdPiezaDañada).HasColumnName("idPiezaDañada");

                entity.Property(e => e.IdPiezaEmpleada).HasColumnName("idPiezaEmpleada");

                entity.Property(e => e.IdServicioTecnico).HasColumnName("idServicioTecnico");

                entity.HasOne(d => d.IdPiezaDañadaNavigation)
                    .WithMany(p => p.TblReemplazosIdPiezaDañadaNavigation)
                    .HasForeignKey(d => d.IdPiezaDañada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReempl__idPie__3C69FB99");

                entity.HasOne(d => d.IdPiezaEmpleadaNavigation)
                    .WithMany(p => p.TblReemplazosIdPiezaEmpleadaNavigation)
                    .HasForeignKey(d => d.IdPiezaEmpleada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReempl__idPie__3B75D760");

                entity.HasOne(d => d.IdServicioTecnicoNavigation)
                    .WithMany(p => p.TblReemplazos)
                    .HasForeignKey(d => d.IdServicioTecnico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tblReempl__idSer__3A81B327");
            });

            modelBuilder.Entity<TblServicioTecnicos>(entity =>
            {
                entity.HasKey(e => e.IdServicioTecnico)
                    .HasName("PK__tblServi__7ECF49D4197F4274");

                entity.ToTable("tblServicioTecnicos");

                entity.Property(e => e.IdServicioTecnico).HasColumnName("idServicioTecnico");

                entity.Property(e => e.IdServicio).HasColumnName("idServicio");

                entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.TblServicioTecnicos)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("FK__tblServic__idSer__2D27B809");

                entity.HasOne(d => d.IdTecnicoNavigation)
                    .WithMany(p => p.TblServicioTecnicos)
                    .HasForeignKey(d => d.IdTecnico)
                    .HasConstraintName("FK__tblServic__idTec__2E1BDC42");
            });

            modelBuilder.Entity<TblServicios>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PK__tblServi__CEB9811905318B42");

                entity.ToTable("tblServicios");

                entity.Property(e => e.IdServicio).HasColumnName("idServicio");

                entity.Property(e => e.Comentario).HasMaxLength(1000);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IdDepartamento).HasColumnName("idDepartamento");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.TblServicios)
                    .HasForeignKey(d => d.IdDepartamento)
                    .HasConstraintName("FK__tblServic__idDep__2A4B4B5E");
            });

            modelBuilder.Entity<TblTecnicos>(entity =>
            {
                entity.HasKey(e => e.IdTecnico)
                    .HasName("PK__tblTecni__295BEDE4669CD289");

                entity.ToTable("tblTecnicos");

                entity.Property(e => e.IdTecnico).HasColumnName("idTecnico");

                entity.Property(e => e.Codigo).HasMaxLength(8);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoPieza>(entity =>
            {
                entity.HasKey(e => e.IdTipoPieza)
                    .HasName("PK__tblTipoP__2CE3732C9225ADD1");

                entity.ToTable("tblTipoPieza");

                entity.HasIndex(e => e.Descripcion)
                    .HasName("UQ__tblTipoP__92C53B6C3A1C9FCB")
                    .IsUnique();

                entity.Property(e => e.IdTipoPieza).HasColumnName("idTipoPieza");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
