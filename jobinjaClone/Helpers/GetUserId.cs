using jobinjaClone.Entities;
using System.Security.Claims;
using jobinjaClone.Entities;
namespace jobinjaClone.Helpers
{
    public static class JwtHellper
    {
        public static int GetId(ClaimsPrincipal User)
        {
            return int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        }
    }
}