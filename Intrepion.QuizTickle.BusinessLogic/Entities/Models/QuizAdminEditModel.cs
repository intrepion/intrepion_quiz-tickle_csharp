using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class QuizAdminEditModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static QuizAdminEditModel FromQuizAdminDto(QuizAdminDto quizAdminDto)
    {
        if (quizAdminDto == null)
        {
            return new QuizAdminEditModel();
        }

        return new QuizAdminEditModel
        {
            Id = quizAdminDto.Id,

            Name = quizAdminDto.Name,
            // DtoToModelPlaceholder
            // Title = quizAdminDto.Title,
            // ToDoList = quizAdminDto.ToDoList,
        };
    }

    public static QuizAdminDto ToQuizAdminDto(QuizAdminEditModel quizAdminEditModel)
    {
        if (quizAdminEditModel == null)
        {
            return new QuizAdminDto();
        }

        return new QuizAdminDto
        {
            Id = quizAdminEditModel.Id,

            Name = quizAdminEditModel.Name,
            // ModelToDtoPlaceholder
            // Title = quizAdminEditModel.Title,
            // ToDoList = quizAdminEditModel.ToDoList,
        };
    }
}
