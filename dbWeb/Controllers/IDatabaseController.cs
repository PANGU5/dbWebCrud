using dbWeb.Data;
using dbWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dbWeb.Controllers
{
    interface IDatabaseController
    {
        public Task<IActionResult> Get();
        public Task<IActionResult> Get(int id);
        //public  Task<IActionResult> Insert(IEnumerable<dynamic> model);
        //public  Task<IActionResult> Update(int id, IEnumerable<dynamic> model);
        public  Task<IActionResult> Delete(int id);
    }
}
