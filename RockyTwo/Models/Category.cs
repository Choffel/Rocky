using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RockyTwo.Models
{
    public class Category
    {
        [Key] // явно указываем ключ
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string categoryName { get; set; }


        [DisplayName("Display Order")] //компанент для имени
        [Range(1,int.MaxValue,ErrorMessage = "Display order for must be greater than 0")]
        public int DisplayOrder { get; set; }
    }
}
