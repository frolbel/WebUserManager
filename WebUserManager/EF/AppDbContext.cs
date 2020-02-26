// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppDbContext.cs" company="">
//   
// </copyright>
// <summary>
//   Описание контекста базы данных.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace WebUserManager.EF
{
    using Microsoft.EntityFrameworkCore;

    using WebUserManager.Models;

    /// <summary>
    /// Описание контекста базы данных.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AppDbContext"/>.
        /// </summary>
        /// <param name="options">
        /// Параметры контекста базы данных.
        /// </param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        /// <summary>
        /// Получает или задает данные пользвателя.
        /// </summary>
        public DbSet<User> Users { get; set; }
    }

}
