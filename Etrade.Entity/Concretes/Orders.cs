using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etrade.Entity.Concretes
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }

        public string Mail { get; set; }
        public string Street { get; set; }
        public string Avenue { get; set; }
        public int No { get; set; }
        [ForeignKey("CountyId")]
        public int CountyId { get; set; }
        [ForeignKey("UsersId")]
        public int UsersId { get; set; }
    }
}
