using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class ContainerResolverException : Exception
    {
        public Type type_that_could_not_be_resolved { get; private set; }
    }
}