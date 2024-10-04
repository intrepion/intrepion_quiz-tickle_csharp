using Microsoft.AspNetCore.Identity;

namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
