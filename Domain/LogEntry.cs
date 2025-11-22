using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class LogEntry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Event { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}

