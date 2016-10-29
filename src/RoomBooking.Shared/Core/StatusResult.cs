using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBooking.Shared.Core
{
    public class StatusResult
    {
        private string _message;
        private readonly int _status;

        #region constructors
        public StatusResult(int status)
        {
            CheckUnauthorizedAccess(status);
            _status = status;
        }
        private void CheckUnauthorizedAccess(int status)
        {
            if (status == 401)
                _message = "Unauthorized access. Login required";
        }
        public StatusResult(int code, string message)
        {
            _status = code;
            _message = message;
        } 
        #endregion

        public int Status => _status;
        public string Message => _message;
    }
}
