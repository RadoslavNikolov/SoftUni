namespace BuhtigIssueTracker.Interfaces
{
    public interface IIssueTracker
    {
        string RegisterUser(IEndpoint endpoint);// TODO: Dokumentieren Sie diese Methode

        string LoginUser(IEndpoint endpoint);// TODO: Dokumentieren Sie diese Methode

        string LogoutUser();// TODO: Dokumentieren Sie diese Methode

        string CreateIssue(IEndpoint endpoint);// TODO: Dokumentieren Sie diese Methode

        string RemoveIssue(IEndpoint endpoint);// TODO: Dokumentieren Sie diese Methode

        string AddComment(IEndpoint endpoint);// TODO: Dokumentieren Sie diese Methode

        string GetMyIssues();// TODO: Dokumentieren Sie diese Methode

        string GetMyComments();// TODO: Dokumentieren Sie diese Methode

        string SearchForIssues(string[] tags);// TODO: Dokumentieren Sie diese Methode
    }
}