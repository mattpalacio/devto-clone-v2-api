using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevtoCloneV2.Core.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(100, ErrorMessage = "Length must be less than 100 characters.")]
        public string Username { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Must be a valid email format.")]
        public string Email { get; set; } = null!;

        public DateTime JoinedDate { get; set; } = DateTime.UtcNow;

        public virtual ICollection<Blog>? BlogPosts { get; set; }
    }
}
