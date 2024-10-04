using Microsoft.AspNetCore.Identity;

namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class ApplicationUserToken : IdentityUserToken<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
