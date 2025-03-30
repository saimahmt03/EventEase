using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventEase.Models;

namespace EventEase.Services
{
    public class UserStateService
    {
        private readonly UserList _usersList = new();
        private User _currentUser = new();
        public event Action? StateChanged;

        // Gets the current user asynchronously
        public Task<User> GetCurrentUserAsync() => Task.FromResult(_currentUser);

        // Sets the current user asynchronously
        public Task SetUserAsync(User newUser)
        {
            _currentUser = newUser;
            NotifyStateChanged();
            return Task.CompletedTask;
        }

        // Adds a user to the list asynchronously
        public Task AddUserAsync(User newUser)
        {
            _usersList.Users.Add(newUser);
            NotifyStateChanged();
            return Task.CompletedTask;
        }

        // Removes a user from the list asynchronously
        public Task RemoveUserAsync(User userToRemove)
        {
            _usersList.Users.Remove(userToRemove);
            NotifyStateChanged();
            return Task.CompletedTask;
        }

        // Gets the user list asynchronously
        public Task<UserList> GetUserListAsync() => Task.FromResult(_usersList);

        // Notifies state change
        private void NotifyStateChanged() => StateChanged?.Invoke();
    }
}