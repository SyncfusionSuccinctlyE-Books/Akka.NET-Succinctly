using Akka.Actor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akka.Net.Succinctly.Core.Common;

namespace Akka.Net.Succinctly.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CalculatorController : Controller
    {
        private readonly ICalculatorActorInstance CalculatorActor;

        public CalculatorController(ICalculatorActorInstance calculatorActor)
        {
            CalculatorActor = calculatorActor;
        }

        [HttpGet("sum")]
        public async Task<double> Sum(double x, double y)
        {
            AnswerMessage answer = null;
            for (int i = 0; i < 10000; i++)
            {
               answer  = await CalculatorActor.Sum(new AddMessage(x, y));
            }
            return answer.Value;
        }
    }
}