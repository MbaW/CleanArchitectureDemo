using CleanMovie.Domain;

namespace CleanMovie.Application
{
    public interface ITokenRepository
    {
        Token Authenticate(User user);
    }
}
