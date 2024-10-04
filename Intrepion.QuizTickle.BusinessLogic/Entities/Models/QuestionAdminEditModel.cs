using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Entities.Models;

public class QuestionAdminEditModel
{
    public Guid Id { get; set; }

    public QuestionType? QuestionType { get; set; }
    public string Text { get; set; } = string.Empty;
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

            QuestionType = questionAdminDto.QuestionType,
            Text = questionAdminDto.Text,
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

            QuestionType = questionAdminEditModel.QuestionType,
            Text = questionAdminEditModel.Text,
            // ModelToDtoPlaceholder
            // Title = questionAdminEditModel.Title,
            // ToDoList = questionAdminEditModel.ToDoList,
        };
    }
}
