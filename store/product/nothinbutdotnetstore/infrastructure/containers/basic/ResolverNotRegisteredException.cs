using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class ResolverNotRegisteredException : Exception
    {
        public Type type_that_could_not_be_resolved { get; private set; }

        public ResolverNotRegisteredException(Type type_that_had_no_resolver)
        {
            this.type_that_could_not_be_resolved = type_that_had_no_resolver;
        }
    }
}