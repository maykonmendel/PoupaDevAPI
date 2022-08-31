using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDevAPI.Repositories;

namespace PoupaDevAPI.Controllers
{
    [Route("operacaofinanceira")]
    public class OperacaoFinanceiraController : Controller
    {
        private readonly OperacaoFinanceiraRepository _repository;

        public OperacaoFinanceiraController(OperacaoFinanceiraRepository repository)
        {
            _repository = repository;
        }
    }
}