using System;
using System.Collections.Generic;
using System.Linq;
using developwithpassion.commons.core.infrastructure.containers;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class BasicContainer : Container
    {
        IEnumerable<ContainerItemResolver> resolvers;

        public BasicContainer(IEnumerable<ContainerItemResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        public Dependency instance_of<Dependency>()
        {
            return (Dependency) instance_of(typeof (Dependency));
        }

        public object instance_of(Type dependency_type)
        {
            ensure_resolver_exists_for(dependency_type);
            try
            {
                return get_resolver_for(dependency_type).resolve();
            }
            catch (Exception e)
            {
                throw new ContainerResolverException(e, dependency_type);
            }
        }

        ContainerItemResolver get_resolver_for(Type type)
        {
            return resolvers.First(item => item.is_resolver_for(type));
        }

        void ensure_resolver_exists_for(Type type)
        {
            if (! resolvers.Any(x => x.is_resolver_for(type))) throw new ResolverNotRegisteredException(type);
        }

        public IEnumerable<DependencyType> all_instances_of<DependencyType>()
        {
            throw new NotImplementedException();
        }
    }
}