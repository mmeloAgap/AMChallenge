using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AM.API.Models
{
    public class QuestionRequest
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Word { get; set; }

        public Guid RequestId { get; set; }
    }
}
