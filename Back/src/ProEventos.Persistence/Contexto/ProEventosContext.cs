using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contexto
{
    public class ProEventosContext : DbContext
    {

        public ProEventosContext(DbContextOptions<ProEventosContext> options) : base(options)
        {
        }
            public DbSet<Evento> Eventos { get; set; }
            public DbSet<Lote> Lotes { get; set; }
            public DbSet<Palestrante> Palestrantes { get; set; }
            public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }
            public DbSet<RedeSocial> RedesSociais { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});


                // FAZ O BANCO APAGAR AS REFERENCIAS DE REDE SOCIAL QUANDO DELETO UM EVENTO OU UM PALESTRANTE:
                
                modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

                
                modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);
            }
    }
}