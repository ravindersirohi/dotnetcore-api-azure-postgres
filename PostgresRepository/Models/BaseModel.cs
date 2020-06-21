using System;
namespace PostgresRepository.Models
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            CreatedDate = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
