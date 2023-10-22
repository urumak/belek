namespace Belek.Domain.Quizes;

using CSharpFunctionalExtensions;

public class Quiz : Entity<string>
{
    public Quiz(string name, string description, IReadOnlyCollection<Question> questions)
    {
        Name = name;
        Description = description;
        Questions = questions;
    }
    public string Name { get; }
    public string Description { get; }
    public IReadOnlyCollection<Question> Questions { get; }
}

public class Question : Entity<string>
{
    public Question(string text, IReadOnlyCollection<Answer> answers)
    {
        Text = text;
        Answers = answers;
    }
    public string Text { get; }
    public IReadOnlyCollection<Answer> Answers { get; }

    public string QuizId { get; } = default!;
}

public class Answer : Entity<string>
{
    public Answer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }

    public string Text { get; }
    public bool IsCorrect { get; }

    public string QuestionId { get; } = default!;
}

