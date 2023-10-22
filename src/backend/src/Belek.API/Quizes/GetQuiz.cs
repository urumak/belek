using MediatR;

namespace Belek.API.Quizes
{
    public static class GetQuiz
    {
        public record GetQuizQuery(string Id) : IRequest<QuizDto>;
        public record QuizDto
        {
            public string Id { get; init; } = default!;
            public string Name { get; init; } = default!;
            public string Description { get; init; } = default!;
            public IReadOnlyCollection<QuestionDto> Questions { get; init; } = default!;
        }

        public record QuestionDto
        {
            public string Id { get; init; } = default!;
            public string Text { get; init; } = default!;
            public IReadOnlyCollection<AnswerDto> Answers { get; init; } = default!;
        }

        public record AnswerDto
        {
            public string Id { get; init; } = default!;
            public string Text { get; init; } = default!;
            public bool IsCorrect { get; init; }
        }

        public class GetQuizHandler : IRequestHandler<GetQuizQuery, QuizDto>
        {
            public async Task<QuizDto> Handle(GetQuizQuery request, CancellationToken cancellationToken)
            {
                var quiz = new QuizDto
                {
                    Id = request.Id,
                    Name = "Sample Quiz",
                    Description = "This is a sample quiz",
                    Questions = new List<QuestionDto>
                {
                    new QuestionDto
                    {
                        Id = "1",
                        Text = "Sample Question 1",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto
                            {
                                Id = "1",
                                Text = "Sample Answer 1",
                                IsCorrect = true
                            },
                            new AnswerDto
                            {
                                Id = "2",
                                Text = "Sample Answer 2",
                                IsCorrect = false
                            }
                        }
                    },
                    new QuestionDto
                    {
                        Id = "2",
                        Text = "Sample Question 2",
                        Answers = new List<AnswerDto>
                        {
                            new AnswerDto
                            {
                                Id = "1",
                                Text = "Sample Answer 1",
                                IsCorrect = false
                            },
                            new AnswerDto
                            {
                                Id = "2",
                                Text = "Sample Answer 2",
                                IsCorrect = true
                            }
                        }
                    }
                }
                };

                return await Task.FromResult(quiz);
            }
        }
    }
}
