using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.Model.Exceptions
{
    public class AuthException : Exception
    {
        public int? ErrorCode { get; set; }

        public AuthException(string message, int? errorCode = null) : base(message)
        {
            ErrorCode = errorCode;
        }

        public AuthException(List<string> message, int? errorCode = null) : base(string.Join(Environment.NewLine, message))
        {
            ErrorCode = errorCode;
        }
    }
}
