using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Binding.Models
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public Customer Author { get; set; }

        public Comment(Customer _author, string _content)
        {
            Id = Guid.NewGuid();
            Content = _content;
            Author = _author;
            CreatedAt = DateTime.Now;
        }
    }
}
