using SOLID.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    public class XmlLayout : ILayout
    {
        public string Format { get; }

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine("<log>")
                    .AppendLine("\t<date>{0}</date>")
                    .AppendLine("\t<level>{1}</level>")
                    .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString();
        }
    }
}
