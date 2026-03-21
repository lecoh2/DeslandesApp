using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Domain.Models.Dtos.Messages
{
    public record ApiResponse<T>(bool Success, string Message, T Data);
}
