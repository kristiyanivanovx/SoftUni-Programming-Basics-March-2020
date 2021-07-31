using System;
using System.Linq;
using System.Reflection;
using SOLID.Models.Interfaces;

namespace SOLID.Factories
{
    public class LayoutFactory
    {
        public LayoutFactory()
        {
        }

        public ILayout CreateLayout(string layoutTypeString)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(layoutTypeString, StringComparison.InvariantCultureIgnoreCase));

            if (layoutType == null)
            {
                throw new InvalidOperationException("Invalid layout type provided.");
            }

            object[] ctorArgs = new object[] { };
            ILayout layout = (ILayout) Activator.CreateInstance(layoutType, ctorArgs);
            return layout;
        }
    }
}
