using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Models
{
    public class AppUser : BaseModel
    {
        public string UserName { get; set; }
        public int Password { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<Company> Companies { get; set; } = new List<Company>();


    }
}
