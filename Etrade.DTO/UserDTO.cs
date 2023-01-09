using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Role { get; set; }
        public bool Error { get; set; }
        public string imgUrl { get; set; }
    }
}
