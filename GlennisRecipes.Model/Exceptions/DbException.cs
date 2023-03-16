using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Exceptions
{
    public class DbException : Exception
    {
        public int? ErrorCode { get; set; }

        public DbException(string message, int? errorCode = null) : base(message)
        {
            this.ErrorCode = errorCode;
        }
        public DbException(List<string> message, int? errorCode = null) : base(string.Join(Environment.NewLine, message))
        {
            ErrorCode = errorCode;
        }
    }
}
