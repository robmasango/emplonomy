using Emplonomy.Model;
using System.Security.Principal;

namespace Emplonomy.Logic
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public EmplonomyUser EmplonomyUser { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
