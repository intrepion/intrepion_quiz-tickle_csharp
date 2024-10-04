namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class AnswerAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public Question? CorrectQuestion { get; set; }
    public int Ordering { get; set; }
    public string Text { get; set; } = string.Empty;
    public Question? Question { get; set; }
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static AnswerAdminDto FromAnswer(Answer? answer)
    {
        if (answer == null)
        {
            return new AnswerAdminDto();
        }

        return new AnswerAdminDto
        {
            Id = answer.Id,

            CorrectQuestion = answer.CorrectQuestion,
            Ordering = answer.Ordering,
            Text = answer.Text,
            Question = answer.Question,
            // EntityToDtoPlaceholder
            // Title = answer.Title,
            // ToDoList = answer.ToDoList,
        };
    }

    public static Answer ToAnswer(ApplicationUser applicationUser, AnswerAdminDto answerAdminDto)
    {
        return new Answer
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = answerAdminDto.Id,

            CorrectQuestion = answerAdminDto.CorrectQuestion,
            Ordering = answerAdminDto.Ordering,
            Text = answerAdminDto.Text,
            Question = answerAdminDto.Question,
            // DtoToEntityPropertyPlaceholder
            // Title = answerAdminDto.Title,
            // ToDoList = answerAdminDto.ToDoList,
        };
    }
}
