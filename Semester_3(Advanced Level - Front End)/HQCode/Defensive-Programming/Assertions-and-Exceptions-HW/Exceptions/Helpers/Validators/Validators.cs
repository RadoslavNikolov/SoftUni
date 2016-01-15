namespace Exceptions_Homework.Helpers.Validators
{
    using Exceptions;

    public static class Validators
    {
        public static void ValidateForValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new InvalidNameException("Name cannot be null or empty");
            }
        }

        public static void ValidateArray<T>(T[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                throw new EmptyCollectionException("Collection is null or empty");
            }
        }
    }
}