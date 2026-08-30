using Microsoft.AspNetCore.Mvc;
using PortoRico.Libraries.Login;

namespace PortoRico.Controllers
{
    public class AluguelController : Controller
    {
        // Mesmo padrão de injeção de dependência que o HomeController já usa
        private LoginCliente _loginCliente;

        public AluguelController(LoginCliente loginCliente)
        {
            _loginCliente = loginCliente;
        }

        // GET: /Aluguel/Index
        // Área protegida: usa o mesmo LoginCliente/Sessao que o resto do site.
        // Se não houver cliente na sessão, manda para a tela de login existente.
        public IActionResult Index(string? cidade)
        {
            var cliente = _loginCliente.GetCliente();

            if (cliente == null)
            {
                return RedirectToAction("Login", "Home");
            }

            ViewBag.Nome = cliente.Nome;
            ViewBag.Cidade = cidade;
            return View();
        }
    }
}
