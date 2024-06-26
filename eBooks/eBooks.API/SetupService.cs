using eBooks.API.Data;
using Microsoft.EntityFrameworkCore;

namespace eBooks.API
{
    public class SetupService
    {
        public static void Init(DataContext context)
        {
            context.Database.Migrate();
        }
    }
}
