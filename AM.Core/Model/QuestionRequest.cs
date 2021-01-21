using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AM.Core.Model.PublicAPI
{
    public class QuestionRequest
    {
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Word { get; set; }
    }
}
