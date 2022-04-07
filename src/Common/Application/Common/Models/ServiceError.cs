using System;

namespace CleanApplication.Application.Common.Models
{
    /// <summary>
    /// All errors contained in ServiceResult objects must return an error of this type
    /// Error codes allow the caller to easily identify the received error and take action.
    /// Error messages allow the caller to easily show error messages to the end user.
    /// </summary>
    [Serializable]
    public class ServiceError
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ServiceError(string message, int code)
        {
            Message = message;
            Code = code;
        }

        public ServiceError() { }

        /// <summary>
        /// Human readable error message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Machine readable error code
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Default error for when we receive an exception
        /// </summary>
        public static ServiceError DefaultError => new ServiceError("Неизвестная ошибка", 999);

        /// <summary>
        /// Default validation error. Use this for invalid parameters in controller actions and service methods.
        /// </summary>
        public static ServiceError ModelStateError(string validationError)
        {
            return new ServiceError(validationError, 998);
        }
        public static ServiceError WalletIsNotEnough => new ServiceError("", 1017);
        public static ServiceError OrderHasAlreadyBeenApproved => new ServiceError("", 1017);
        public static ServiceError NotPossibleCancelOrder => new ServiceError("", 1017);
        public static ServiceError NotPossibleToCancelThisOrder => new ServiceError("", 1016);
        public static ServiceError MediaNotFound => new ServiceError("", 1015);
        public static ServiceError CourseNotFound => new ServiceError("", 1014);

        public static ServiceError FileNotSupported => new ServiceError("", 1013);
        public static ServiceError InvalidId => new ServiceError("", 1012);
        public static ServiceError InvalidRefreshToken => new ServiceError("", 1011);
        public static ServiceError InvalidUserGuestRole => new ServiceError("", 1010);
        public static ServiceError ExistUser => new ServiceError("", 1009);
        public static ServiceError GuestUserExistInGuests => new ServiceError("", 1008);
        public static ServiceError UserIsNotAdmin => new ServiceError("", 1007);
        public static ServiceError GuestUserExistInUsers => new ServiceError("", 1006);
        public static ServiceError GuestUserInvalidDate => new ServiceError("", 1005);

        public static ServiceError DuplicatePhoneNumberOrEmail => new ServiceError("", 1004);
        public static ServiceError InvalidVerifyCode => new ServiceError("", 1003);
        public static ServiceError EmptyVerifyCode => new ServiceError("", 1002);
        public static ServiceError CreateUserException => new ServiceError("", 1000);

        public static ServiceError UserIsLockedOut => new ServiceError("", 1001);
        /// <summary>
        /// Use this for unauthorized responses.
        /// </summary>
        public static ServiceError ForbiddenError => new ServiceError("", 998);

        /// <summary>
        /// Use this to send a custom error message
        /// </summary>
        public static ServiceError CustomMessage(string errorMessage)
        {
            return new ServiceError(errorMessage, 999);

        }
      
        public static ServiceError InccrrectUsernameOrPassword => new ServiceError("", 997);
        public static ServiceError UserNotFound => new ServiceError("", 996);

        public static ServiceError UserFailedToCreate => new ServiceError("", 995);

        public static ServiceError Canceled => new ServiceError("", 994);

        public static ServiceError NotFound => new ServiceError("", 990);

        public static ServiceError ErrorInSaveOrUpdate => new ServiceError("", 902);
        public static ServiceError ValidationFormat => new ServiceError("", 901);
        
        public static ServiceError Validation => new ServiceError("", 900);

        public static ServiceError SearchAtLeastOneCharacter => new ServiceError("", 898);

        /// <summary>
        /// Default error for when we receive an exception
        /// </summary>
        public static ServiceError ServiceProviderNotFound => new ServiceError("", 700);

        public static ServiceError ServiceProvider => new ServiceError("", 600);

        public static ServiceError DateTimeFormatError => new ServiceError("", 500);

        #region Override Equals Operator

        /// <summary>
        /// Use this to compare if two errors are equal
        /// Ref: https://msdn.microsoft.com/ru-ru/library/ms173147(v=vs.80).aspx
        /// </summary>
        public override bool Equals(object obj)
        {
            // If parameter cannot be cast to ServiceError or is null return false.
            var error = obj as ServiceError;

            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public bool Equals(ServiceError error)
        {
            // Return true if the error codes match. False if the object we're comparing to is nul
            // or if it has a different code.
            return Code == error?.Code;
        }

        public override int GetHashCode()
        {
            return Code;
        }

        public static bool operator ==(ServiceError a, ServiceError b)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if ((object)a == null || (object)b == null)
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(ServiceError a, ServiceError b)
        {
            return !(a == b);
        }

        #endregion
    }

}
