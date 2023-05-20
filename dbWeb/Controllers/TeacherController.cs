using Microsoft.AspNetCore.Mvc;

namespace dbWeb.Controllers
{
    public class TeacherController : IDatabaseController
    {
        public Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Get()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Insert(TeacherController model)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> Update(int id, TeacherController model)
        {
            throw new NotImplementedException();
        }
    }
}
