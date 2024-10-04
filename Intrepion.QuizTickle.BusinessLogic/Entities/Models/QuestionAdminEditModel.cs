using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class QuestionAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static QuestionAdminEditModel FromQuestionAdminDto(QuestionAdminDto questionAdminDto)
    {
        if (questionAdminDto == null)
        {
            return new QuestionAdminEditModel();
        }

        return new QuestionAdminEditModel
        {
            Id = questionAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = questionAdminDto.Title,
            // ToDoList = questionAdminDto.ToDoList,
        };
    }

    public static QuestionAdminDto ToQuestionAdminDto(QuestionAdminEditModel questionAdminEditModel)
    {
        if (questionAdminEditModel == null)
        {
            return new QuestionAdminDto();
        }

        return new QuestionAdminDto
        {
            Id = questionAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = questionAdminEditModel.Title,
            // ToDoList = questionAdminEditModel.ToDoList,
        };
    }
}
