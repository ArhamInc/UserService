using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UsersApp.Models;
using UsersApp.DTOs;
using UsersApp.Services;
using UsersApp.Exceptions;

namespace UsersApp.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IUserService userService;
        
        public UserController(IUserService userService) {
            this.userService = userService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers() {
            var users = await userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id) {
            try {
                var user = await userService.GetUserById(id);
                return Ok(user);
            }
            catch (UserNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] UserDTO userRequest) {
            try {
                var createdUser = await userService.AddUser(userRequest);
                return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
            }
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserDTO userRequest) {
            try {
                await userService.UpdateUser(id, userRequest);
                return NoContent();
            }
            catch (UserNotFoundException ex) {
                return NotFound(ex.Message);    
            }
            catch (InvalidOperationException ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id) {
            try {
                await userService.DeleteUser(id);
                return NoContent();
            }
            catch (UserNotFoundException ex) {
                return NotFound(ex.Message);
            }
            
        }

    }
}
