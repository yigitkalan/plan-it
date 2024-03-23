using planit.Application.Bases;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class AuthRules: BaseRule
{
    public Task UserShouldNotExist(User? user){
        if(user is not null){
            throw new UserAlreadyExistException();
        }
        return Task.CompletedTask;
    }
}
