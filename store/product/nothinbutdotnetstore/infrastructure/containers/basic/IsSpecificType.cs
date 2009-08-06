using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class IsSpecificType : Specification<Type>
    {
        Type type;

        public IsSpecificType(Type type)
        {
            this.type = type;
        }


        public bool is_satisfied_by(Type item)
        {
            return item.Equals(type);
        }
    }
}