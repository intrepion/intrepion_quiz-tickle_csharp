using Microsoft.AspNetCore.Identity;

namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class ApplicationUserLogin : IdentityUserLogin<Guid>
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
