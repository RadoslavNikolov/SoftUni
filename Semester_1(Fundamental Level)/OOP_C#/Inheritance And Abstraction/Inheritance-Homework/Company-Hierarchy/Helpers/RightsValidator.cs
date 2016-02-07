namespace Company_Hierarchy.Helpers
{
    using System.Diagnostics;
    using System.Linq;

    public static class RightsValidator
    {
        public static bool ValidateSaleDeletionUserRights()
        {
            bool canDelete = false;
            StackTrace stackTrace = new StackTrace();
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name.ToLower();

            if (className.Equals("manager"))
            {
                canDelete = true;
            }

             return canDelete;
        }

        public static bool ValidateProductDeletionUserRights()
        {
            StackTrace stackTrace = new StackTrace();
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name.ToLower();

            if (className.Equals("manager"))
            {
                return true;
            }

            return false;
        }

        public static bool ValidateProjectClosingUserRights(int projectId, int userId)
        {
            StackTrace stackTrace = new StackTrace();
            var className = stackTrace.GetFrame(1).GetMethod().DeclaringType.Name.ToLower();

            if (className.Equals("manager"))
            {
                return true;
            }

            if (CompanyDB.projects.First(p => p.Id == projectId).Developers.Any(d => d.Id == userId))
            {
                return true;
            }

            return false;

        }
    }
}