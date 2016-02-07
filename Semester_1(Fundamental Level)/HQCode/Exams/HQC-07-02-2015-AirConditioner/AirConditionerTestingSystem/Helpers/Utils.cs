namespace AirConditionerTestingSystem.Helpers
{
    public static class Utils
    {
        public static string GenerateUniqueKey(string manifacturer, string model)
        {
            string result = string.Format("{0};;{1}", manifacturer, model);

            return result;
        }
    }
}