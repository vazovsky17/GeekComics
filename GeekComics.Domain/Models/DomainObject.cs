using System.ComponentModel.DataAnnotations;

namespace GeekComics.Domain.Models
{
    /// <summary> Общий объект, имеющий Id </summary>
    public class DomainObject
    {
        public int Id { get; set; }
    }
}
