using Core.Entities.Concrete;

namespace Business.Constants
{
    //Static olmasının sebebi bir kere oluşturalım bellekte, dursun,
    //herkes onu kullansın diye
    public static class Messages
    {
        public static string ProductAdded = "Product added successfully";
        public static string ProductDeleted = "Product deleted successfully";
        public static string ProductUpdated = "Product updated successfully";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Wrong password";
        public static string SuccessfulLogin = "Successful login";
        public static string UserAlreadyExists = "User already exists";
        public static string UserRegistered = "User added successfully";
        public static string AccessTokenCreated = "Access token created";
    }
}