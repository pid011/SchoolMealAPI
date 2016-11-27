using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMeal.Exception
{
    /// <summary>
    /// 해당 교육기관이 존재하지 않을 경우 발생합니다.
    /// </summary>
    [Serializable]
    public class SchoolNotFoundException : System.Exception
    {
        public SchoolNotFoundException() { }

        public SchoolNotFoundException(string message) : base(message) { }

        public SchoolNotFoundException(string message, System.Exception inner) : base(message, inner) { }

        protected SchoolNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
