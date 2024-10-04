﻿using Microsoft.AspNetCore.Identity;

namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class ApplicationRole : IdentityRole<Guid>
{
    public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; } = [];
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
}
