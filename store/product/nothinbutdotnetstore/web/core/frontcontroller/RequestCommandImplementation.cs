using nothinbutdotnetstore.infrastructure;

namespace nothinbutdotnetstore.web.core.frontcontroller
{
    public class RequestCommandImplementation : RequestCommand
    {
        Specification<IncomingRequest> request_specification;
        RawRequestCommand raw_command;

        public RequestCommandImplementation(Specification<IncomingRequest> request_specification, RawRequestCommand raw_command)
        {
            this.request_specification = request_specification;
            this.raw_command = raw_command;
        }

        public void process(IncomingRequest request)
        {
            raw_command.process(request);
        }

        public bool can_handle(IncomingRequest request)
        {
            return request_specification.is_satisfied_by(request);
        }
    }
}