using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planets.Application.DTO;
using Planets.Infra.Data;
using Planets.Infra.Data.Entities;

namespace Planets.Controllers;

//Mover depois para o service
[Controller]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllUSers()
    {
        var users = _context.Users.FirstOrDefault();
        if (users is null)
        {
            users = new UserEntitiy()
            {
                Name = "Caralho",
                Email = "Caralho@gmail.com",
                Password = "a",
                Username = "b",
                ReceiveMessages = true
            };
        }

        return Ok(users);
    }

    [HttpPost]
    public IActionResult SignUp(UserSignUpDTO request) // Adicionar Assynch
    {
        if (request is not null)
        {
            var userSearched = _context.Users.AsNoTracking().
            FirstOrDefault(x => x.Username == request.Username || x.Email == request.Email);

            if (userSearched is not null)
                return BadRequest();

            UserEntitiy user = new UserEntitiy // Adicionar conversao implicita
            {
                Name = request.Name,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password, //Adicionar hash na senha
                ReceiveMessages = true
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        return Created();
    }

    //Adicionar autenticacao
    [HttpGet]
    public IActionResult SignIn(UserEntitiy userView)
    {
        if (userView is not null)
        {
            var userSearched = _context.Users.
            FirstOrDefault(x => x.Username == userView.Username && x.Password == userView.Password);
            if (userSearched is null)
                return NotFound();
        }

        return Ok();
    }

    //consertar retorno 429
    //Nao pertence a ess e controller
    [HttpGet]
    public IActionResult GetAPOD()
    {
        APODResponseDTO response = null;
        using (var cliente = new HttpClient())
        {
            string dateTimeString = DateTime.Now.ToString();
            DateTime dateTime = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", null);
            string date = dateTime.ToString("yyyy-MM-dd");
            Console.WriteLine(date);
            var endpoint = new Uri($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={date}");
            var content = cliente.GetStreamAsync(endpoint).Result;
            response = JsonSerializer.Deserialize<APODResponseDTO>(content) ?? throw new Exception();
        }
        Console.WriteLine(response.ToString());
        return Ok(response);
    }

}
