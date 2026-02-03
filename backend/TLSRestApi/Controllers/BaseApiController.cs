using Microsoft.AspNetCore.Mvc;
using Domain.Common;

namespace TLSRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseApiController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected BaseApiController(){}

        protected IActionResult Ok<T>(T data, string message = "Operacion Exitosa")
        {
            return base.Ok(Result<T>.Success(data, message));
        }

        protected IActionResult Created<T>(T data,string message = "Recurso Creado")
        {
            return StatusCode(201, Result<T>.Success(data, message));
        }

        protected IActionResult NoContent(string message = "Operacion Completada")
        {
            return StatusCode(204, Result<object>.Success(null, message));
        }

        protected IActionResult BadRequest(string error)
        {
            return base.BadRequest(Result<object>.Failure(error));
        }

        protected IActionResult BadRequest(List<string> errors)
        {
            return base.BadRequest(Result<object>.Failure(errors));
        }

        protected IActionResult NotFound(string message = "Recurso no encontrado")
        {
            return base.NotFound(Result<object>.Failure(message));
        }

        protected IActionResult FromResult<T>(Result<T> result)
        {
            return result.IsSuccess ? Ok(result.Data, result.Message) : BadRequest(result.Errors);
        }
    }
}
