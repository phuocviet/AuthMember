using AuthMember.Data;
using AuthMember.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthMember.Services
{
    public class MemberService
    {
        private readonly MemberContext _context;
        private List<Member> members;
        public async Task HandleCreate(Member member)
        {
            if (IsExisted(member))
            {
                return ;
            }
            member = new Member()
            {
                Name = member.Name,
                Email = member.Email,
                UserCredential = member.UserCredential,
            };
            _context.Add(member);

            await _context.SaveChangesAsync();
        }
        public bool IsExisted(Member member)
        {
            var existingMember = _context.members.FirstOrDefault(m => m.Email == member.Email);
            if (existingMember != null)
            {
                return true;
            }
            return false;
        }
    }
}
