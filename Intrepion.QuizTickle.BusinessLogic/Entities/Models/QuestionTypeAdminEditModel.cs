using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class QuestionTypeAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static QuestionTypeAdminEditModel FromQuestionTypeAdminDto(QuestionTypeAdminDto questionTypeAdminDto)
    {
        if (questionTypeAdminDto == null)
        {
            return new QuestionTypeAdminEditModel();
        }

        return new QuestionTypeAdminEditModel
        {
            Id = questionTypeAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = questionTypeAdminDto.Title,
            // ToDoList = questionTypeAdminDto.ToDoList,
        };
    }

    public static QuestionTypeAdminDto ToQuestionTypeAdminDto(QuestionTypeAdminEditModel questionTypeAdminEditModel)
    {
        if (questionTypeAdminEditModel == null)
        {
            return new QuestionTypeAdminDto();
        }

        return new QuestionTypeAdminDto
        {
            Id = questionTypeAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = questionTypeAdminEditModel.Title,
            // ToDoList = questionTypeAdminEditModel.ToDoList,
        };
    }
}
