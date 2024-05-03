using Microsoft.AspNetCore.Mvc;
using PasswordValidator.Domain.Entities;
using PasswordValidator.Services.Interfaces;

namespace PasswordValidator.API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CredentialsController : ControllerBase
    {
        private readonly IPasswordValidator _validator;

        public CredentialsController(IPasswordValidator validator)
        {
            _validator = validator;
        }

        [HttpPost]
        [Route("/validate-password")]
        public async Task<IActionResult> ValidateCredentials(CredentialsDTO credentialsDto)
        {
            bool result = await _validator.Validate(credentialsDto.Password);

            if (result)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
