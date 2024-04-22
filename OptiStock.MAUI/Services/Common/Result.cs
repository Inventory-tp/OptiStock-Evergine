namespace OptiStock.MAUI.Services.Common
{
    //Result Pattern class
    //This class is a type result and exception handler for the service actions
    public class Result<T>
    {
        //Constructor class with only isSuccess and Exception parameters
        private Result(bool isSuccess, Exception error)
        {
            if (isSuccess && error != null ||
                !isSuccess && error == null)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        //Constructor class override the first constructor with value paremeter in addition
        private Result(bool isSuccess, T value, Exception error)
        {
            if (isSuccess && error != null ||
                !isSuccess && error == null)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }

            IsSuccess = isSuccess;
            Error = error;
            Value = value;
        }

        public bool IsSuccess { get; }

        public bool IsFailure => !IsSuccess;

        public T Value { get; }
        public Exception Error { get; }

        public string ErrorMessage { get { return Error.Message; } }

        public static Result<T> Success() => new(true, null);

        public static Result<T> Success(T value) => new(true, value, null);

        public static Result<T> Failure(Exception error) => new(false, error);

        public static T Match(
        Result<T> result,
        Func<T> onSuccess,
        Func<Exception, T> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Error);
        }

        public static T Match(
        Result<T> result,
        Func<T, T> onSuccess,
        Func<Exception, T> onFailure)
        {
            return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
        }
    } 
}
