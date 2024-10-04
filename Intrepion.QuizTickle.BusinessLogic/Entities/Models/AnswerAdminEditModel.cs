using Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

namespace Intrepion.QuizTickle.BusinessLogic.Entities.Models;

public class AnswerAdminEditModel
{
    public Guid Id { get; set; }

    public Question? CorrectQuestion { get; set; }
    public int Ordering { get; set; }
    public string Text { get; set; } = string.Empty;
    public Question? Question { get; set; }
    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static AnswerAdminEditModel FromAnswerAdminDto(AnswerAdminDto answerAdminDto)
    {
        if (answerAdminDto == null)
        {
            return new AnswerAdminEditModel();
        }

        return new AnswerAdminEditModel
        {
            Id = answerAdminDto.Id,

            CorrectQuestion = answerAdminDto.CorrectQuestion,
            Ordering = answerAdminDto.Ordering,
            Text = answerAdminDto.Text,
            Question = answerAdminDto.Question,
            // DtoToModelPlaceholder
            // Title = answerAdminDto.Title,
            // ToDoList = answerAdminDto.ToDoList,
        };
    }

    public static AnswerAdminDto ToAnswerAdminDto(AnswerAdminEditModel answerAdminEditModel)
    {
        if (answerAdminEditModel == null)
        {
            return new AnswerAdminDto();
        }

        return new AnswerAdminDto
        {
            Id = answerAdminEditModel.Id,

            CorrectQuestion = answerAdminEditModel.CorrectQuestion,
            Ordering = answerAdminEditModel.Ordering,
            Text = answerAdminEditModel.Text,
            Question = answerAdminEditModel.Question,
            // ModelToDtoPlaceholder
            // Title = answerAdminEditModel.Title,
            // ToDoList = answerAdminEditModel.ToDoList,
        };
    }
}
