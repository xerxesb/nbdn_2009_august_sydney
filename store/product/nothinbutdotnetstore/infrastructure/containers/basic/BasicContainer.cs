using System;
using System.Collections.Generic;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicContainer : Container
    {
        readonly TypeDependencyResovler type_dependency_resolver;

        public BasicContainer(TypeDependencyResovler type_dependency_resolver)
        {
            this.type_dependency_resolver = type_dependency_resolver;
        }

        public Dependency instance_of<Dependency>()
        {
            return (Dependency)instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            try
            {
                return type_dependency_resolver.resolve_concrete_type(dependency_type);
            }
            catch (Exception e)
            {
                throw new ContainerResolverException(e, dependency_type);
            }
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}