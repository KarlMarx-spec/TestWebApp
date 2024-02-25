using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// Сущность отдела
    /// </summary>
    public class Office
    {
        /// <summary>
        /// Id отдела
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Id связанного департамента
        /// </summary>
        public int DepartmentId { get; set; }
    }
}
