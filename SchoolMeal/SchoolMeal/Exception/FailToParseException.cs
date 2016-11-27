using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMeal.Exception
{
    /// <summary>
    /// 파싱에 실패하였을 경우 발생합니다.
    /// </summary>
    [Serializable]
    public class FailToParseException : System.Exception
    {
        public FailToParseException() { }

        public FailToParseException(string message) : base(message) { }

        public FailToParseException(string message, System.Exception inner) : base(message, inner) { }

        protected FailToParseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
