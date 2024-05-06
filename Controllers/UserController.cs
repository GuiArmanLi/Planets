using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Planets.Data;
using Planets.Data.Entities;
using Planets.Models;

namespace Planets.Controllers;

public class UserController : Controller
{
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult SignUp(UserModelView userView)
    {
        if (userView is not null)
        {
            var userSearched = _context.Users.AsNoTracking().FirstOrDefault(x => x.Username == userView.Username || x.Email == userView.Email);

            if (userSearched is not null)
                return RedirectToAction("Index", "Home");

            UserModel user = new UserModel
            {
                Name = userView.Name,
                Username = userView.Username,
                Email = userView.Email,
                Password = userView.Password,
                IsMessageAvaliable = true
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Index", "User");
        }

        return RedirectToAction("Index", "Home");
    }

    //Adicionar autenticacao
    public IActionResult SignIn(UserModelView userView)
    {
        if (userView is not null)
        {
            var userSearched = _context.Users.FirstOrDefault(x => x.Username == userView.Username && x.Password == userView.Password);
            if (userSearched is not null)
                return RedirectToAction("Index", "User");
        }

        return RedirectToAction("Index", "Home");
    }

    //consertar retorno 429
    public IActionResult GetAPOD()
    {
        APODModelView response = null;
        using (var cliente = new HttpClient())
        {
            string dateTimeString = DateTime.Now.ToString();
            DateTime dateTime = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", null);
            string date = dateTime.ToString("yyyy-MM-dd");

            Console.WriteLine(date);

            var endpoint = new Uri($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={date}");
            var content = cliente.GetStreamAsync(endpoint).Result;

            response = JsonSerializer.Deserialize<APODModelView>(content) ?? throw new Exception();
        }

        System.Console.WriteLine(response.ToString());

        return View(response);
    }

}
