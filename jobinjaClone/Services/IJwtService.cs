using jobinjaClone.Entities;

namespace jobinjaClone.Services
{
  public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
