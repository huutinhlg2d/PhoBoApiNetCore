using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

namespace PhoBoAPI.Attribute.Auth
{
    public class CustomerAuthorize : AuthorizeAttribute
    {
        public CustomerAuthorize() : base()
        {
            Debug.WriteLine("Roles " + Roles);
        }

        public CustomerAuthorize(string policy) : base(policy)
        {
        }

    }
}
