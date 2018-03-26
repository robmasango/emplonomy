using Emplonomy.Logic.Abstract;
using Emplonomy.Model;
using System;

namespace Emplonomy.Logic.Repositories
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        IRoleRepository _roleReposistory;
        IEmplonomyUserRepository _userReposistory;

        public UserRoleRepository(EmplonomyContext context, IRoleRepository roleReposistory, IEmplonomyUserRepository userReposistory)
        : base(context)
        {
            _roleReposistory = roleReposistory;
            _userReposistory = userReposistory;
        }

        private void addUserToRole(EmplonomyUser user, int roleId)
        {
            var role = _roleReposistory.GetRole(roleId);
            if (role == null)
                throw new Exception("Role doesn't exist.");

            var userRole = new UserRole()
            {
                RoleID = role.ID,
                UserID = user.ID
            };
            this.Add(userRole);

            this.Commit();
        }
    }
}
