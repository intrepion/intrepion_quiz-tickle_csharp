using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Models;

public class EntityNamePlaceholderAdminEditModel
{
    public Guid Id { get; set; }

    // JustModelPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminEditModel FromEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminDto answerAdminDto)
    {
        if (answerAdminDto == null)
        {
            return new EntityNamePlaceholderAdminEditModel();
        }

        return new EntityNamePlaceholderAdminEditModel
        {
            Id = answerAdminDto.Id,

            // DtoToModelPlaceholder
            // Title = answerAdminDto.Title,
            // ToDoList = answerAdminDto.ToDoList,
        };
    }

    public static EntityNamePlaceholderAdminDto ToEntityNamePlaceholderAdminDto(EntityNamePlaceholderAdminEditModel answerAdminEditModel)
    {
        if (answerAdminEditModel == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = answerAdminEditModel.Id,

            // ModelToDtoPlaceholder
            // Title = answerAdminEditModel.Title,
            // ToDoList = answerAdminEditModel.ToDoList,
        };
    }
}
