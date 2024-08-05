using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Auth.Jwt.Extension;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RequireScopeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _requiredScoped;


    public RequireScopeAttribute(params string[] requiredScoped)
    {
        _requiredScoped = requiredScoped;
    }


    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // check use claims
        bool hasScope =
            context.HttpContext.User.Claims.Any(x => x.Type == "scope" && _requiredScoped.Contains(x.Value));
        if (!hasScope)
        {
            context.Result = new ForbidResult();
        }
    }
}