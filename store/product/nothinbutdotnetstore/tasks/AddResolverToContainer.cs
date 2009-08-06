using System;
using System.Collections;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.tasks
{
    public interface ContainerResolverRegistry : IEnumerable<ContainerItemResolver>
    {
        void register_resolver_for<Item>(Func<object> factory);
        void register_resolver_for<Interface,Implementation>();
    }

    public class ContainerResolverRegistryImplementation : ContainerResolverRegistry
    {
        IList<ContainerItemResolver> resolvers;

        public ContainerResolverRegistryImplementation(IList<ContainerItemResolver> resolvers)
        {
            this.resolvers = resolvers;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void register_resolver_for<Interface, Implementation>()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ContainerItemResolver> GetEnumerator()
        {
            return resolvers.GetEnumerator();
        }

        public void register_resolver_for<Item>(Func<object> factory)
        {
            resolvers.Add(new ContainerItemResolverImplementation(factory, new IsSpecificType(typeof (Item)).is_satisfied_by));
        }
    }
}