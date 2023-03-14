using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using VariacaoAtivo.Models;


namespace VariacaoAtivo.Controllers
{

    [ApiController]
    [Route("ativos")]
    public class AtivosController : ControllerBase
    {
        private readonly MySqlConnection _connection;

        public AtivosController(MySqlConnection connection)
        {
            _connection = connection;
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<IEnumerable<Ativos>>> Get(string nome)
        {
            var ativos = await _connection.QueryAsync<Ativos>(
                "SELECT * FROM ativos WHERE nome = @Nome ORDER BY data DESC LIMIT 30",
                new { Nome = nome });

            var ativosList = ativos.ToList();
        // Calcular Variação do Ativo
            for (int i = 0; i < ativosList.Count - 1; i++)
            {
                ativosList[i].Variacao = ativosList[i].Valor - ativosList[i + 1].Valor;
            }

            return ativosList;
        }
    }

}
