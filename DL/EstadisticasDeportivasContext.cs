using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class EstadisticasDeportivasContext : DbContext
    {
        public EstadisticasDeportivasContext()
        {
        }

        public EstadisticasDeportivasContext(DbContextOptions<EstadisticasDeportivasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<Estadio> Estadios { get; set; } = null!;
        public virtual DbSet<EstadisticaEquipo> EstadisticaEquipos { get; set; } = null!;
        public virtual DbSet<Jugador> Jugadors { get; set; } = null!;
        public virtual DbSet<Liga> Ligas { get; set; } = null!;
        public virtual DbSet<Marcador> Marcadors { get; set; } = null!;
        public virtual DbSet<Pai> Pais { get; set; } = null!;
        public virtual DbSet<Partido> Partidos { get; set; } = null!;
        public virtual DbSet<Posicion> Posicions { get; set; } = null!;
        public virtual DbSet<Resultado> Resultados { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=192.168.0.122,1433; Database= EstadisticasDeportivas; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo)
                    .HasName("PK__Equipo__D80524081645B9E9");

                entity.ToTable("Equipo");

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEstadioNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.IdEstadio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipo__IdEstadi__1CF15040");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Equipos)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Equipo__IdPais__1BFD2C07");
            });

            modelBuilder.Entity<Estadio>(entity =>
            {
                entity.HasKey(e => e.IdEstadio)
                    .HasName("PK__Estadio__C7C8C967C65F3CEE");

                entity.ToTable("Estadio");

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Estadios)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estadio__IdPais__1920BF5C");
            });

            modelBuilder.Entity<EstadisticaEquipo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EstadisticaEquipo");

                entity.HasIndex(e => e.IdEquipo, "UQ__Estadist__D80524090B51848E")
                    .IsUnique();

                entity.Property(e => e.GolesAnotados).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartidosGanados).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartidosJugados).HasDefaultValueSql("((0))");

                entity.Property(e => e.PartidosPerdidos).HasDefaultValueSql("((0))");

                entity.Property(e => e.Puntos).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithOne()
                    .HasForeignKey<EstadisticaEquipo>(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estadisti__IdEqu__300424B4");
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador)
                    .HasName("PK__Jugador__99E320164BF6821D");

                entity.ToTable("Jugador");

                entity.Property(e => e.ApellidoMaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoPaterno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Foto).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPosicionNavigation)
                    .WithMany(p => p.Jugadors)
                    .HasForeignKey(d => d.IdPosicion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jugador__IdPosic__29572725");

                entity.HasOne(d => d.NacionalidadNavigation)
                    .WithMany(p => p.Jugadors)
                    .HasForeignKey(d => d.Nacionalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Jugador__Naciona__286302EC");

                entity.HasMany(d => d.IdEquipos)
                    .WithMany(p => p.IdJugadors)
                    .UsingEntity<Dictionary<string, object>>(
                        "JugadorEquipo",
                        l => l.HasOne<Equipo>().WithMany().HasForeignKey("IdEquipo").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__JugadorEq__IdEqu__2D27B809"),
                        r => r.HasOne<Jugador>().WithMany().HasForeignKey("IdJugador").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__JugadorEq__IdJug__2C3393D0"),
                        j =>
                        {
                            j.HasKey("IdJugador", "IdEquipo").HasName("PK__JugadorE__04637256F34B7E35");

                            j.ToTable("JugadorEquipo");
                        });
            });

            modelBuilder.Entity<Liga>(entity =>
            {
                entity.HasKey(e => e.IdLiga)
                    .HasName("PK__Liga__31D8EE109F25C3FF");

                entity.ToTable("Liga");

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Ligas)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Liga__IdPais__164452B1");

                entity.HasMany(d => d.IdEquipos)
                    .WithMany(p => p.IdLigas)
                    .UsingEntity<Dictionary<string, object>>(
                        "LigaEquipo",
                        l => l.HasOne<Equipo>().WithMany().HasForeignKey("IdEquipo").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LigaEquip__IdEqu__20C1E124"),
                        r => r.HasOne<Liga>().WithMany().HasForeignKey("IdLiga").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__LigaEquip__IdLig__1FCDBCEB"),
                        j =>
                        {
                            j.HasKey("IdLiga", "IdEquipo").HasName("PK__LigaEqui__AC58BC50819E9B8F");

                            j.ToTable("LigaEquipo");
                        });
            });

            modelBuilder.Entity<Marcador>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Marcador__B450643A9CECAC28");

                entity.ToTable("Marcador");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__Pais__FC850A7B050F0EAC");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partido>(entity =>
            {
                entity.HasKey(e => e.IdPartido)
                    .HasName("PK__Partido__6ED660F9C86E2B21");

                entity.ToTable("Partido");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.HasOne(d => d.IdEquipoLocalNavigation)
                    .WithMany(p => p.PartidoIdEquipoLocalNavigations)
                    .HasForeignKey(d => d.IdEquipoLocal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__IdEquip__239E4DCF");

                entity.HasOne(d => d.IdEquipoVisitanteNavigation)
                    .WithMany(p => p.PartidoIdEquipoVisitanteNavigations)
                    .HasForeignKey(d => d.IdEquipoVisitante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__IdEquip__24927208");

                entity.HasOne(d => d.IdEstadioNavigation)
                    .WithMany(p => p.Partidos)
                    .HasForeignKey(d => d.IdEstadio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Partido__IdEstad__25869641");
            });

            modelBuilder.Entity<Posicion>(entity =>
            {
                entity.HasKey(e => e.IdPosicion)
                    .HasName("PK__Posicion__638A2F4C06598DFE");

                entity.ToTable("Posicion");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Resultado>(entity =>
            {
                entity.HasKey(e => e.IdResultado)
                    .HasName("PK__Resultad__DAF71D0BA29FDD92");

                entity.ToTable("Resultado");

                entity.Property(e => e.DuracionPartido)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdMarcadorNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdMarcador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resultado__IdMar__38996AB5");

                entity.HasOne(d => d.IdPartidoNavigation)
                    .WithMany(p => p.Resultados)
                    .HasForeignKey(d => d.IdPartido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Resultado__IdPar__37A5467C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
