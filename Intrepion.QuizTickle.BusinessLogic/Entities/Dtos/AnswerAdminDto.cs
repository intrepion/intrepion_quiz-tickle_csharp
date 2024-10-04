namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class AnswerAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public Question? CorrectQuestion { get; set; }
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

            // DtoToEntityPropertyPlaceholder
            // Title = answerAdminDto.Title,
            // ToDoList = answerAdminDto.ToDoList,
        };
    }
}
