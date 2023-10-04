using PSIUWeb.Data.Interface;
using PSIUWeb.Models;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

namespace PSIUWeb.Data.EF
{
    public class EFPsicoRepository : IPsicoRepository
    {
        private AppDbContext context;

        public EFPsicoRepository(AppDbContext ctx)
        {
            context = ctx;
        }

        public Psico? Create(Psico p)
        {
            try
            {
                context.psicos?.Add(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }

        public Psico? Delete(int id)
        {
            Psico? p = GetPsicoById(id);

            if (p == null)
                return null;

            context.psicos?.Remove(p);
            context.SaveChanges();

            return p;


        }

        public Psico? GetPsicoById(int id)
        {
            Psico? p =
                context
                    .psicos?
                    .Where(p => p.Id == id)
                    .FirstOrDefault();

            return p;

        }

        public IQueryable<Psico>? GetPsico()
        {
            return context.psicos;
        }

        public Psico? Update(Psico p)
        {
            try
            {
                context.psicos?.Update(p);
                context.SaveChanges();
            }
            catch
            {
                return null;
            }

            return p;
        }

           
    }

}


