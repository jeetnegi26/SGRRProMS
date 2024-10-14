using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RoleDetails : Base
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int FormId { get; set; }
    }
}
