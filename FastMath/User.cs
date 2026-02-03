using FastMath.Core.Interfaces;

namespace FastMath
{
    public class User : ICurrentUser
    {
        public string TheUser { get; set; } = string.Empty;
    }
}
