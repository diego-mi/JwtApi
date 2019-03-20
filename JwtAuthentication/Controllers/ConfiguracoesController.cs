using System.Collections.Generic;
using JwtAuthentication.Services.Configuracoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.Controllers
{
    [Route("api/v1/configuracoes")]
    [Authorize]
    [ApiController]
    public class ConfiguracoesController : ControllerBase
    {
        public readonly ConfiguracoesService _configuracoesService;

        public ConfiguracoesController(ConfiguracoesService configuracoesService)
        {
            _configuracoesService = configuracoesService;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IDictionary<string, string>), 200)]
        [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
        public object GetConfiguracoes()
        {
            return _configuracoesService.GetConfiguracoes();
        }

    }
}