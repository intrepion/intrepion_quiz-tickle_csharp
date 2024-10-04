namespace Intrepion.QuizTickle.BusinessLogic.Entities;

public class Question
{
    public ApplicationUser? ApplicationUserUpdatedBy { get; set; }
    public Guid Id { get; set; }

    public QuestionType? QuestionType { get; set; }
    public string Text { get; set; } = string.Empty;
    // ActualPropertyPlaceholder
}
