using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Domain.Interface;

namespace User.Application.GetAll
{

    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<UserDTO>>
    {
        private readonly IUserRepository _repository;

        public GetAllQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDTO>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetUsersAsync(cancellationToken);
            if (users == null || !users.Any())
                throw new InvalidOperationException("Không tìm thấy bất kỳ người dùng nào.");

            var userDtos = users.Select(user => new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            }).ToList();

            return userDtos;
        }
    }
}
