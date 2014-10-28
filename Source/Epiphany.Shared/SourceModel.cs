using System;

namespace Epiphany.Attributes
{
    [AttributeUsage(System.AttributeTargets.Class |
                            System.AttributeTargets.Struct)]
    public class SourceModel : Attribute
    {

        public SourceModel(Type type)
        {
            this.Type = type;
        }

        public Type Type
        {
            get;
            set;
        }
    }
}
