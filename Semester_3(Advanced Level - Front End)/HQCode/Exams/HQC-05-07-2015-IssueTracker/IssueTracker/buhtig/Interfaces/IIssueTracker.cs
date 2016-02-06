﻿namespace BuhtigIssueTracker.Interfaces
{
    public interface IIssueTracker
    {
        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="username">The username of the user to register</param>
        /// <param name="password">The password of the user to register</param>
        /// <param name="confirmPassword">The confirmation of the password of the user to register. To complete the registration,
        /// the two passwords must match</param>
        /// <returns>In case of success, returns a success message.
        /// If the passwords do not match, there is another user with the same username in the database,
        /// or there is already a logged in user, returns an error message.</returns>
        string RegisterUser(IEndpoint endpoint);

        /// <summary>
        /// Logs in an existing user in the application.
        /// </summary>
        /// <param name="username">The username of the user to login</param>
        /// <param name="password">The password of the user to login</param>
        /// <returns>In case of success, returns a success message.
        /// If there is no user with the given username in the database, the password is invalid,
        /// or there is already a logged in user, returns an error message.</returns>
        string LoginUser(IEndpoint endpoint);

        /// <summary>
        /// Logs out the logged in user from the application.
        /// </summary>
        /// <returns>In case of success, returns a success message.
        /// If there is no currently logged in user, returns an error message.</returns>
        string LogoutUser();

        /// <summary>
        /// Creates a new issue by the currently logged in user.
        /// </summary>
        /// <param name="title">The title of the issue to create. The title must be at least 3 symbols long</param>
        /// <param name="description">The description of the issue to create. The description must be at least 5 symbols long</param>
        /// <param name="priority">The priority of the issue to create</param>
        /// <param name="tags">The tags of the issue to create</param>
        /// <returns>In case of success, returns a success message.
        /// If there is no currently logged in user, returns an error message.</returns>
        string CreateIssue(IEndpoint endpoint);

        /// <summary>
        /// Removes the issue given by the specified ID from the current user's issues.
        /// </summary>
        /// <param name="issueId">The unique ID of the issue to remove</param>
        /// <returns>In case of success, returns a success message.
        /// If there is no issue with the specified ID, the issue owner is not the currently logged in user,
        /// or there is no currently logged in user, returns an error message.</returns>
        string RemoveIssue(IEndpoint endpoint);

        /// <summary>
        /// Adds a comment to the issue given by the specified ID by the current user.
        /// </summary>
        /// <param name="issueId">The unique ID of the issue to add a comment to</param>
        /// <param name="text">The text of the comment</param>
        /// <returns>In case of success, returns a success message.
        /// If there is no issue with the specified ID, the issue text is less than 2 symbols long,
        /// or there is no currently logged in user, returns an error message.</returns>
        string AddComment(IEndpoint endpoint);

        /// <summary>
        /// Returns the issues by the current user ordered by priority in descending order first
        /// and then by title in ascending order.
        /// </summary>
        /// <returns>In case of success, returns the issues. If there is no currently logged in user, 
        /// or if there are no issues to show, returns an error message.</returns>
        string GetMyIssues();

        /// <summary>
        /// Returns the comments by the current user ordered by creation time
        /// </summary>
        /// <returns>In case of success, returns the comments. If there is no currently logged in user, 
        /// or if there are no comments to show, returns an error message.</returns>
        string GetMyComments();

        /// <summary>
        /// Searches for issues which have one or more of the provided tags.
        /// </summary>
        /// <param name="tags">The tags to search for</param>
        /// <returns>In case of success, returns the issues ordered by priority in descending order first
        /// and then by title in ascending order. If there are no tags or no matching issues, 
        /// returns an error message.</returns>
        string SearchForIssues(IEndpoint endpoint);
    }
}