using Microsoft.EntityFrameworkCore;

namespace dbWeb.Models
{
    public class BaseModel : DbContext
    {
        public virtual int Id { get; set; }
    }
}
