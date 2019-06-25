using System;


namespace DCCMSNameSpace
{
    public enum ExecuteCommandStatus
    {
        DuplicateUserName = -4,
        DuplicateEmail = -3,
        CanNotDeleteHaveChilds = -2,
        AllreadyExists = -1,
        UnknownError = 0,
        Done = 1
    }
}



