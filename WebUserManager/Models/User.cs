using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUserManager.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Описание модели данных пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Получает или задает идентификатор пользователя
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Получает или задает имя пользователя
        /// </summary>
        [StringLength(50), Required]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Получает или задает фамилию пользователя
        /// </summary>
        [StringLength(50), Required]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        /// <summary>
        /// Получает или задает адрес пользователя
        /// </summary>
        [StringLength(255)]
        [Display(Name = "Адрес")]
        public string Address { get; set; }

        /// <summary>
        /// Получает или задает телефон пользователя
        /// </summary>
        [StringLength(50)]
        [Display(Name = "Тел.")]
        public string Phone { get; set; }

        /// <summary>
        /// Получает или задает возраст пользователя
        /// </summary>
        [Display(Name = "Возраст")]
        public int Age { get; set; }

    }
}
