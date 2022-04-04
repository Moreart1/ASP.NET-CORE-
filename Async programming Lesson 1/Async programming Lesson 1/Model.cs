using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async_programming_Lesson_1
{
    public class Model
    {
        public override string ToString() => $"{UserId}\n{Id}\n{Title}\n{Body}";      
        public uint UserId { get; set; }
        public uint Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
    }
}
