namespace Intrepion.QuizTickle.BusinessLogic.Entities.Dtos;

public class QuizAdminDto
{
    public string ApplicationUserName { get; set; } = string.Empty;
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    // DtoPropertyPlaceholder
    // public string Title { get; set; } = string.Empty;
    // public ToDoList? ToDoList { get; set; }

    public static QuizAdminDto FromQuiz(Quiz? quiz)
    {
        if (quiz == null)
        {
            return new QuizAdminDto();
        }

        return new QuizAdminDto
        {
            Id = quiz.Id,

            Name = quiz.Name,
            // EntityToDtoPlaceholder
            // Title = quiz.Title,
            // ToDoList = quiz.ToDoList,
        };
    }

    public static Quiz ToQuiz(ApplicationUser applicationUser, QuizAdminDto quizAdminDto)
    {
        return new Quiz
        {
            ApplicationUserUpdatedBy = applicationUser,
            Id = quizAdminDto.Id,

            Name = quizAdminDto.Name,
            // DtoToEntityPropertyPlaceholder
            // Title = quizAdminDto.Title,
            // ToDoList = quizAdminDto.ToDoList,
        };
    }
}
