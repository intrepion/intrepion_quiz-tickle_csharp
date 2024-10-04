namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class QuestionAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static QuestionAdminDto FromQuestion(Question? question)
    {
        if (question == null)
        {
            return new QuestionAdminDto();
        }

        return new QuestionAdminDto
        {
            Id = question.Id,

            // EntityToDtoPlaceholder
            // Title = question.Title,
            // ToDoList = question.ToDoList,
        };
    }

    public static Question ToQuestion(ApplicationUser applicationUser, QuestionAdminDto questionAdminDto)
    {
        return new Question
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = questionAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = questionAdminDto.Title,
            // ToDoList = questionAdminDto.ToDoList,
        };
    }
}
