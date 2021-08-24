namespace DocInfo.Common
{
    public static class GlobalConstants
    {
        // Role
        public const string AdministratorRoleName = "Admin";
        public const string EmployeeRoleName = "Employee";
        public const string UserRoleName = "User";

        // Password for seeded data
        public const string Password = "123456";

        // Document
        public const int DocTitleMaxLength = 50;
        public const int DocDescriptionMaxLength = 1000;

        // Profile
        public const int ProfilFirstNameMaxLength = 30;
        public const int ProfilLastNameMaxLength = 30;

        // Publication
        public const int PublicationTitleMaxLength = 50;
        public const int PublicationContentMaxLength = 3000;
    }
}
