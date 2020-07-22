using Capinfo.His;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capinfo.Authoritys.Dto
{
    public class UserAuthorityTreeDto
    {
        public long RoleId { get; set; }
        public AuthorityTreeDto[] Authoritys { get; set; }
    }
}
