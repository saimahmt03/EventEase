using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EventEase.Models;
using EventEase.Services;

namespace EventEase.Services
{
    public class LoginSessionStateService
    {
        private bool _authenticated = false;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _loginMessage = string.Empty;

        private readonly UserStateService _userStateService; // Inject UserStateService
        private UserList userList = new();
        private User _currentUser = new();
        public event Action? StateChanged;
        
        public LoginSessionStateService(UserStateService userStateService)
        {
            _userStateService = userStateService;
        }

        // Sets user credentials asynchronously
        public Task SetUserAsync(User newUser)
        {
            _username = newUser.Username;
            _password = newUser.Password;
            NotifyStateChanged();
            return Task.CompletedTask;
        }

        // Authenticates a user asynchronously
        public async Task<string> LoginUserAsync(User newUser)
        {
             userList = await _userStateService.GetUserListAsync(); // Get users from UserStateService

            foreach (var user in userList.Users)
            {
                if (user.Username == newUser.Username && user.Password == newUser.Password)
                {
                    _authenticated = true;
                    _currentUser = user;
                    NotifyStateChanged();
                    _loginMessage = "Login successful";
                    return _loginMessage;
                }
            }

            _loginMessage = "Login failed";
            return _loginMessage;
        }

        // Logs out a user asynchronously
        public Task<string> LogoutUserAsync()
        {
            _authenticated = false;
            _username = string.Empty;
            _password = string.Empty;
            _currentUser = new();
            NotifyStateChanged();
            _loginMessage = "Logout successful";
            return Task.FromResult(_loginMessage);
        }

        // Returns authentication status
        public Task<bool> IsAuthenticatedAsync() => Task.FromResult(_authenticated);

        private void NotifyStateChanged() => StateChanged?.Invoke();
    }
}