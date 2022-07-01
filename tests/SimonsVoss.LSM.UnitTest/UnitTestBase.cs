using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimonsVoss.LSM.Core.AutoMapper;
using SimonsVoss.LSM.DB;

namespace SimonsVoss.LSM.UnitTest
{
    public class UnitTestBase : IDisposable
    {
        protected IMapper Mapper { get; private set; }

        public UnitTestBase()
        {
            Mapper = new Mapper(new MapperConfiguration(options => options
                .AddProfile(new MappingProfile())));
        }
        
        protected EfContext CreateInMemoryContext(Action<EfContext> dbSeeder = null)
        {
            var options = new DbContextOptionsBuilder<EfContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var context = new EfContext(options))
            {
                dbSeeder?.Invoke(context);
                context.SaveChangesAsync().GetAwaiter().GetResult();
            }

            return new EfContext(options);
        }
        
        public void Dispose() => GC.SuppressFinalize(this);
    }
}