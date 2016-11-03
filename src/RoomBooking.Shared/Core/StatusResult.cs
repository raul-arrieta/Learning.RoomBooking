namespace RoomBooking.Shared.Core
{
    public class StatusResult
    {
        public int Status { get; }

        public string Message { get; private set; }

        #region constructors

        public StatusResult(int status)
        {
            CheckUnauthorizedAccess(status);
            Status = status;
        }

        private void CheckUnauthorizedAccess(int status)
        {
            if (status == 401)
                Message = "Unauthorized access. Login required";
        }

        public StatusResult(int code, string message)
        {
            Status = code;
            Message = message;
        }

        #endregion
    }
}