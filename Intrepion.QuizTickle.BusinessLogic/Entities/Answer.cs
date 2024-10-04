namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class Answer
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public Question? CorrectQuestion { get; set; }
    public int Ordering { get; set; }
    public string Text { get; set; } = string.Empty;
    public Question? Question { get; set; }
    // ActualPropertyPlaceholder
}
