namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class QuestionTypeAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static QuestionTypeAdminDto FromQuestionType(QuestionType? questionType)
    {
        if (questionType == null)
        {
            return new QuestionTypeAdminDto();
        }

        return new QuestionTypeAdminDto
        {
            Id = questionType.Id,

            // EntityToDtoPlaceholder
            // Title = questionType.Title,
            // ToDoList = questionType.ToDoList,
        };
    }

    public static QuestionType ToQuestionType(ApplicationUser applicationUser, QuestionTypeAdminDto questionTypeAdminDto)
    {
        return new QuestionType
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = questionTypeAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = questionTypeAdminDto.Title,
            // ToDoList = questionTypeAdminDto.ToDoList,
        };
    }
}
