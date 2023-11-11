using ErrorOr;

namespace PropertyAPI.Domain.Common.Errors;

public static class Errors{
    public static class User{
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "a conflict error has occured");
    }
}