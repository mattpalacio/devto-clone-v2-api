using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Entities
{
    public class Blog : BaseEntity
    {
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [MaxLength(250, ErrorMessage = "Length must be less than 250 characters.")]
        public string Title { get; set; } = null!;

        public string Content { get; set; } = null!;

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
