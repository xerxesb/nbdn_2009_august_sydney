using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class ContainerItemResolverImplementation : ContainerItemResolver
    {
        Func<object> factory;
        Func<Type,bool> specification;

        public ContainerItemResolverImplementation(Func<object> factory,Func<Type,bool> specification) 
        {
            this.factory = factory;
            this.specification = specification;
        }

        public object resolve()
        {
            return factory();
        }

        public bool is_resolver_for(Type type)
        {
            return specification(type);
        }
    }
}