namespace StudentEnrollementSystem_Backend.DB
{
    public class BaseService
    {
        protected readonly StudentContext Context;

        public BaseService(StudentContext context)
        {
            Context = context;
        }
    }
}
