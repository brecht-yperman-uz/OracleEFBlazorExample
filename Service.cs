using Microsoft.EntityFrameworkCore;

namespace BlazorApp
{
    public class Service
    {
        private readonly IDbContextFactory<MyContext> _dbContextFactory;

        public Service(IDbContextFactory<MyContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<VirtualNumber>> GetResults(int count, int startIndex, CancellationToken cancellationToken)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await dbContext.VirtualNumbers
                .OrderBy(vn => vn.RowNumber)
                .Skip(startIndex)
                .Take(count)
                .ToListAsync(cancellationToken);
        }
    }
}
