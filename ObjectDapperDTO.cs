using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4
{
    [Table("ObjectDapper")]
    public class ObjectDapperDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
