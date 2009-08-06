using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class ContainerResolverException : Exception
    {
        public ContainerResolverException(Exception inner_exception, Type type_that_could_not_be_resolved) : base(inner_exception.Message, inner_exception)
        {
            this.type_that_could_not_be_resolved = type_that_could_not_be_resolved;
        }

        public Type type_that_could_not_be_resolved { get; private set; }
    }
}