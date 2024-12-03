using MediatR;
using ProductAPI.Commands;
using ProductAPI.Repositories;

namespace ProductAPI.CommandHandlers
{
    public class CategoryCommandHandlers : IRequestHandler<AddCategoryCommand>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;

        public CategoryCommandHandlers(ICategoryWriteRepository categoryWriteRepository)
        {
            _categoryWriteRepository = categoryWriteRepository;
        }

        public async Task Handle(AddCategoryCommand command, CancellationToken cancellationToken)
        {

            await _categoryWriteRepository.Add(command.Name);
        }
    }
}