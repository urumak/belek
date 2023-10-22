using CSharpFunctionalExtensions;

namespace Belek.Domain.User
{
    public class User : Entity<string>
    {
        protected User()
        {
        }

        protected User(string id)
            : base(id)
        {
        }
    }
}
