using FluentScheduler;

namespace SimpleMessages.Jobs
{
    public class JobRegistry : Registry
    {
        public JobRegistry()
        {
            //TODO проверить по ТЗ время
            Schedule<MessageGeneratorJob>().NonReentrant().ToRunEvery(10).Seconds();
        }
    }
}