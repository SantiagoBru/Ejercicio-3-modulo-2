using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
	public DbSet<Actor> Actores { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		// Configura la cadena de conexión a tu base de datos
		optionsBuilder.UseSqlServer("YourConnectionStringHere");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		// Configuración adicional si es necesario
		modelBuilder.Entity<Actor>(entity =>
		{
			entity.ToTable("Actor");
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Nombre).IsRequired().HasMaxLength(50);
			entity.Property(e => e.Apellido).IsRequired().HasMaxLength(50);
			entity.Property(e => e.NombreArtistico).HasMaxLength(100);
			entity.Property(e => e.Edad).HasRange(0, 100);
			entity.Property(e => e.Nacionalidad).HasMaxLength(50);
			entity.Property(e => e.Genero).HasMaxLength(1);
		});
	}
}
