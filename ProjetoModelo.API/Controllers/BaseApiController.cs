using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjetoModelo.Domain.Enumerators;
using ProjetoModelo.Domain.Exceptions;

namespace ProjetoModelo.API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected void ValidateModelState()
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                throw new InformationException(StatusException.Erro, messages);
            }
        }
    }
}
