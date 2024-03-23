using planit.Application.Bases;
using planit.Application.Exceptions;
using planit.Domain.Entities;

namespace planit.Application.Features;
public class AuthenticationRules: BaseRule
{
    public Task UserShouldNotExist(User? user){
        if(user is not null){
            throw new UserAlreadyExistException();
        }
        return Task.CompletedTask;
    }

    public Task EmailAndPasswordShouldBeValid(User? user, bool isPasswordValid){
        if(!isPasswordValid){
            throw new EmailOrPasswordInvalidException();
        }
        return Task.CompletedTask;
    }
    public Task UserShouldExist(User? user){
        if(user is null){
            throw new UserNotFoundException();
        }
        return Task.CompletedTask;
    }
}
