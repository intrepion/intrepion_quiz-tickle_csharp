namespace ApplicationNamePlaceholder.BusinessLogic.Entities;

public class Answer
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public Question? CorrectQuestion { get; set; }
    // ActualPropertyPlaceholder
}
