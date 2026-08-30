
using PortoRico.Libraries.Login;
using PortoRico.Models;
using PortoRico.Repository.Contract;
using Microsoft.AspNetCore.Mvc;
using PortoRico.Models;
using System.Diagnostics;

namespace PortoRico.Controllers
{
    public class HomeController : Controller
    {

        // Injeção de dependência
        private IClienteRepository _clienteRepository;
        private LoginCliente _loginCliente;

        public HomeController(
            IClienteRepository clienteRepository,
            LoginCliente loginCliente)
        {
            _clienteRepository = clienteRepository;
            _loginCliente = loginCliente;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromForm] Cliente cliente)
        {
            Cliente clienteDB = _clienteRepository.Login(cliente.Email, cliente.Senha);

            if (clienteDB.Email != null && clienteDB.Senha != null)
            {
                _loginCliente.Login(clienteDB);

                return new RedirectResult(
                    Url.Action(nameof(PainelCliente))
                );
            }
            else
            {
                // Erro na sessão
                ViewData["MSG_E"] =
                    "Usuário não localizado, por favor verifique e-mail e senha digitado";

                return View();
            }
        }


        public IActionResult PainelCliente()
        {
            ViewBag.Nome = _loginCliente.GetCliente().Nome;
            ViewBag.CPF = _loginCliente.GetCliente().CPF;
            ViewBag.Email = _loginCliente.GetCliente().Email;
            return View();

        }
    
        public IActionResult LogoutCliente()
        {
            _loginCliente.Logout();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Atracoes()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

