using MediatR;

namespace ProductAPI.Commands
{
    public class AddCategoryCommand : IRequest
    {
        public string Name { get; set; }
    }
}
