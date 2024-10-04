using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class AnswerAdminEditModel
{
    public Guid Id { get; set; }

    public Question? CorrectQuestion { get; set; }
    public int Ordering { get; set; }
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
            // ModelToDtoPlaceholder
            // Title = answerAdminEditModel.Title,
            // ToDoList = answerAdminEditModel.ToDoList,
        };
    }
}
