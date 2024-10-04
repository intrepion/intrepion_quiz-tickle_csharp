using Microsoft.AspNetCore.Identity;

namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class ApplicationUserClaim : IdentityUserClaim<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
