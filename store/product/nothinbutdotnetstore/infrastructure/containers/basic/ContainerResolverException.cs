using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class ContainerResolverException : Exception
    {
        public ContainerResolverException(Exception innerException, Type type_that_could_not_be_resolved) : base(innerException.Message, innerException)
        {
            this.type_that_could_not_be_resolved = type_that_could_not_be_resolved;
        }

        public Type type_that_could_not_be_resolved { get; private set; }
    }
}