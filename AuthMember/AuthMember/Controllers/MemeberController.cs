using AuthMember.Models;
using AuthMember.Services;
using AuthMember.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthMember.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemeberController : ControllerBase
    {
        private readonly MemberContext _context;
        private readonly IJwtAuth jwtAuth;

        private readonly List<Member> lstMember = new List<Member>();
        
        public MemeberController(MemberContext memberContext, IJwtAuth jwtAuth)
        {
            memberContext = _context;
            this.jwtAuth = jwtAuth;
        }

        public List<Member> GetLstMember()
        {
            return lstMember;
        }

        // GET: api/<MemeberController>
        //[HttpGet]
        //public IEnumerable<Member> Get(List<Member> lstMember)
        //{
            
        //}

        // GET api/<MemeberController>/5
        

        // POST api/<MemeberController>
        [HttpPost]
        public IActionResult Post([FromBody] Member member)
        {
            var userName = member.UserCredential.UserName;
            var password = member.UserCredential.Password;

            member.Id = member.Id;
            member = new Member()
            {
                Name = member.Name,
                Email = member.Email,
                UserCredential = member.UserCredential,
            };
            lstMember.Add(member);
            return Ok(lstMember);
        }
        [HttpPost("authenticated")]
        public IActionResult Authenticated([FromBody] UserCredential user)
        {
            var token = jwtAuth.Authentication(user.Password, user.UserName);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
        // PUT api/<MemeberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemeberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
