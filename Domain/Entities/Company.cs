using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Сущность компании
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Id компании
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Название компании
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Навигационное поле для создания внешнего ключа в EF
        /// </summary>
        public List<Department>? Departments { get; set; }
    }
}
