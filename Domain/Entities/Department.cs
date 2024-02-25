using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Сущность департамента
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Id департамента
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id связанной компании
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Навигационное поле для создания внешнего ключа в EF
        /// </summary>
        public List<Office>? Offices { get; set; }
    }
}
