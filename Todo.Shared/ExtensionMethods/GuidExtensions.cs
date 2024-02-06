namespace Todo.Shared.ExtensionMethods
{
    public static class GuidExtensions
    {

        public static Guid ToGuid(this string guid)
        {
            return new Guid(guid);
        }
    }
}
