namespace ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

public class EntityNamePlaceholderAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static EntityNamePlaceholderAdminDto FromEntityNamePlaceholder(EntityNamePlaceholder? question)
    {
        if (question == null)
        {
            return new EntityNamePlaceholderAdminDto();
        }

        return new EntityNamePlaceholderAdminDto
        {
            Id = question.Id,

            // EntityToDtoPlaceholder
            // Title = question.Title,
            // ToDoList = question.ToDoList,
        };
    }

    public static EntityNamePlaceholder ToEntityNamePlaceholder(ApplicationUser applicationUser, EntityNamePlaceholderAdminDto questionAdminDto)
    {
        return new EntityNamePlaceholder
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = questionAdminDto.Id,

            // DtoToEntityPropertyPlaceholder
            // Title = questionAdminDto.Title,
            // ToDoList = questionAdminDto.ToDoList,
        };
    }
}
