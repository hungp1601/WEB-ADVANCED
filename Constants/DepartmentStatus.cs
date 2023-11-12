using btl_web.Constants.Statuses;
using btl_web.Exceptions;

namespace btl_web.Constants
{
    public enum DepartmentStatus
    {
        PENDING = 0,
        CANCEL = 1,
        ACCEPTED = 2,
    }

    public class DepartmentStatusHelper
    {
        public static DepartmentStatus Get(int value)
        {
            switch (value)
            {
                case 0:
                    return DepartmentStatus.PENDING;
                case 1:
                    return DepartmentStatus.CANCEL;
                case 2:
                    return DepartmentStatus.ACCEPTED;
                default:
                    throw new DataRuntimeException(StatusNotExist.DEPARTMENT_STATUS);
            }
        }
    }
}