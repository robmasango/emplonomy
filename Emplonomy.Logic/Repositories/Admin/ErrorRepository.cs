using Emplonomy.Logic.Abstract;
using Emplonomy.Model;

namespace Emplonomy.Logic.Repositories
{
    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    { 
        public LoggingRepository(EmplonomyContext context)
            : base(context)
    { }

    public override void Commit()
    {
        try
        {
            base.Commit();
        }
        catch { }
    }
}
}