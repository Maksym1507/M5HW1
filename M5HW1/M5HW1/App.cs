using M5HW1.Services.Abstractions;

namespace M5HW1
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAuthService _authService;

        public App(
            IUserService userService,
            IResourceService resourceService,
            IAuthService authService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _authService = authService;
        }

        public async Task Start()
        {
            var userById = await _userService.GetUserById(2);
            var notFoundUserById = await _userService.GetUserById(343);
            var listOfUsersByPage = await _userService.GetUsersByPage(2);
            var listOfUsersWithDelay = await _userService.GetUsersWithDelay(3);
            var createdUser = await _userService.CreateUser("morpheus", "leader");
            var updatedUserWithPut = await _userService.PutUser(2, "morpheus", "zion resident");
            var updatedUserWithPatch = await _userService.PatchUser(2, "morpheus", "zion resident");
            await _userService.DeleteUser(2);
            var registerUser = await _authService.Register("eve.holt@reqres.in", "pistol");
            var unsuccessfulRegisterUser = await _authService.Register("sydney@fife", string.Empty);
            var loginUser = await _authService.Login("eve.holt@reqres.in", "cityslicka");
            var unsuccessfulLoginUser = await _authService.Login("eve.holt@reqres.in", string.Empty);
            var resourceById = await _resourceService.GetResourceById(2);
            var notFoundResourceById = await _resourceService.GetResourceById(30);
            var listOfResources = await _resourceService.GetResources();
        }
    }
}
