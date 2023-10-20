namespace Vacunacion.Controllers
{
    public class Tool
    {
        private int loggedInUserId;

        

        public void SetLoggedInUserId(int userId)
        {
            loggedInUserId = userId;
        }
        public int GetLoggedInUserId()
        {
            return loggedInUserId;
        }
    }

}
