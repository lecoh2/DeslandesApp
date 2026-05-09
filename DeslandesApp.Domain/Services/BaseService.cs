using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Services
{
    public abstract class BaseService
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public Guid? ObterUsuarioId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            var userId =
                user?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value
                ?? user?.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            return string.IsNullOrEmpty(userId)
                ? null
                : Guid.Parse(userId);
        }
    }
}
