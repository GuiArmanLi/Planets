using Microsoft.AspNetCore.Mvc;
using Planets.Domain.DTO.Request;
using Planets.Domain.Entities;
using Planets.Infra.Data.Context;

//Mover depois para o service e adicionar e autorizacao
namespace Planets.Service.User
{
    public class UserService
    {
        private readonly MySqlDbContext _context;


        public UserService(MySqlDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> GetAll()
        {
            var users = await _context.Users.FirstOrDefaultAsync();
            if (users is null)
                return NotFound("Nenhum usuario presente na lista");

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpDTO request)
        {
            if (request is not null)
            {
                var userSearched = await _context.Users.
                AsNoTracking().
                FirstOrDefaultAsync(
                    x => x.Username == request.Username ||
                    x.Email == request.Email
                );

                if (userSearched is not null)
                    return BadRequest("Usuario existente");

                //request.Password = hash; //Adicionar hash na senha
                UserEntity user = new UserEntity()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Username = request.Username,
                    Password = request.Password,
                    ReceiveMessages = request.ReceiveMessages
                };

                await _context.Users.AddAsync(user);
                await _context.Users.SaveChangesAsync();
            }

            return Ok(request);
        }

        //Adicionar autenticacao
        [HttpGet]
        public async Task<IActionResult> SignIn(UserEntity userView)
        {

            UserEntity? userSearched = null;

            if (userView is not null)
            {
                userSearched = await _context.Users.FirstOrDefaultAsync(
                    x => x.Username == userView.Username &&
                    x.Password == userView.Password
                );

                if (userSearched is null)
                    return NotFound("Dados de acesso incorreto");
            }

            var userResponseDTO = (UserSignInDTO)userSearched;
            return Ok(userResponseDTO);
        }

        //consertar retorno 429
        //Nao pertence a esse controller
        //[HttpGet]
        //public IActionResult GetAPOD()
        //{
        //    APODResponseDTO response = null;
        //    using (var cliente = new HttpClient())
        //    {
        //        var dateTimeString = DateTime.Now.ToString();
        //        var dateTimeFormated = DateTime.ParseExact(dateTimeString, "dd/MM/yyyy HH:mm:ss", null);
        //        var dateFormated = dateTimeFormated.ToString("yyyy-MM-dd");

        //        Console.WriteLine(dateFormated);

        //        // var endpoint = new Uri($"https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY&date={date}");
        //        // var content = cliente.GetStreamAsync(endpoint).Result;
        //        // response = JsonSerializer.Deserialize<APODResponseDTO>(content) ?? throw new Exception();
        //    }
        //    Console.WriteLine(response.ToString());
        //    return Ok(response);
        //}
    }
}