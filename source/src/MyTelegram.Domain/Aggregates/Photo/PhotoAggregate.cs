namespace MyTelegram.Domain.Aggregates.Photo;

public class PhotoAggregate : AggregateRoot<PhotoAggregate, PhotoId>
{
    private readonly PhotoState _state = new();

    public PhotoAggregate(PhotoId id) : base(id)
    {
        Register(_state);
    }

    public void SetAsProfilePhoto()
    {
        //Specs.AggregateIsCreated.ThrowFirstDomainErrorIfNotSatisfied(this);
        Emit(new SetAsProfilePhotoCompletedEvent(_state.Photo.Id));
    }

    public void Create(long userId, PhotoItem photo)
    {
        Specs.AggregateIsNew.ThrowFirstDomainErrorIfNotSatisfied(this);
        Emit(new PhotoCreatedEvent(userId, photo));
    }

    public void Delete(long userId/*,long accessHash*/)
    {
        Specs.AggregateIsCreated.ThrowFirstDomainErrorIfNotSatisfied(this);
        if (userId != _state.UserId)
        {
            RpcErrors.RpcErrors400.PhotoIdInvalid.ThrowRpcError();
        }

        //if (accessHash != _state.Photo.AccessHash)
        //{
        //    RpcErrors.RpcErrors400.PhotoInvalid.ThrowRpcError();
        //}

        Emit(new PhotoDeletedEvent(_state.UserId, _state.Photo));
    }
}