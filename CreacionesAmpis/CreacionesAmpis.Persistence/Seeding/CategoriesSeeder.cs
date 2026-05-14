using CreacionesAmpis.Domain.Entities.Sections;
namespace CreacionesAmpis.Persistence.Seeding
{
    internal class CategoriesSeeder : ISeedable
    {
        private readonly DataContext _context;
        public CategoriesSeeder(DataContext context) { _context = context; }
        public async Task SeedAsync()
        {
            string[] categories = ["Brasieres", "Panties", "Conjuntos", "Bodies", "Pijamas", "Fajas", "Medias", "Accesorios"];
            foreach (string category in categories)
                if (!_context.Categories.Any(c => c.Name == category))
                    await _context.Categories.AddAsync(new Category(category));
            await _context.SaveChangesAsync();
        }
    }
}
