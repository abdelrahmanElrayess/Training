namespace Training.Services
{
    public interface ITrelloTaskJobTestService
    {
        void FireAndForgetJob();

        void ReccuringJob();

        void DelayedJob();

        void ContinuationJob();

    }
}
