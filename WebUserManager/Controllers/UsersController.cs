using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebUserManager.EF;
using WebUserManager.Models;

namespace WebUserManager.Controllers
{
    /// <summary>
    /// Контроллер пользовательских данных.
    /// </summary>
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Возвращает данные всех пользователей.
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllUsers()
        {
            return View(await _context.Users.ToListAsync());
        }

        /// <summary>
        /// Возвращает результат показа подробных данных пользователя. 
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Результат показа подробных данных пользователя</returns>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Возвращает результат добавления пользователя.
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Возвращает результат добавления пользователя.
        /// </summary>
        /// <param name="user">Модель данных пользователя</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Phone,Age")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(this.AllUsers));
            }
            return View(user);
        }

        /// <summary>
        /// Возвращает результат редактирования данных пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Результат редактирования данных пользователя</returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return this.NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Возвращает результат редактирования данных пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="user">Модель данных пользователя</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Address,Phone,Age")] User user)
        {
            if (id != user.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this._context.Update(user);
                    await this._context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(this.AllUsers));
            }
            return View(user);
        }

        /// <summary>
        /// Возвращает результат удаления пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Результат удаления пользователя</returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Возвращает результат удаления пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Результат удаления пользователя</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(this.AllUsers));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
