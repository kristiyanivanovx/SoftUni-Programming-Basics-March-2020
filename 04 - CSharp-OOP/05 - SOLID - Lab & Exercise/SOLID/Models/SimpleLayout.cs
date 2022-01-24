using SOLID.Models.Interfaces;

namespace SOLID.Models
{
    class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
