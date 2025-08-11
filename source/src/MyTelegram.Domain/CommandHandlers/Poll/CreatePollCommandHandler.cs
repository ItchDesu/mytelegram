namespace MyTelegram.Domain.CommandHandlers.Poll;

public class CreatePollCommandHandler : CommandHandler<PollAggregate, PollId, CreatePollCommand>
{
    public override Task ExecuteAsync(PollAggregate aggregate,
        CreatePollCommand command,
        CancellationToken cancellationToken)
    {
        aggregate.Create(
            command.ToPeer,
            command.PollId,
            command.MultipleChoice,
            command.Quiz,
            command.PublicVoters,
            command.Question,
            command.Answers,
            command.CorrectAnswers,
            command.Solution,
            command.SolutionEntities,
            command.QuestionEntities
            );
        return Task.CompletedTask;
    }
}