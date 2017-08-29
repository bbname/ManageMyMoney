using MMM.Model;
using MMM.Models;

namespace MMM.ModelBinders.Manage
{
    public class ToUserEditViewModel
    {
        public UserEditViewModel GetViewModel(User user)
        {
            var viewModel = new UserEditViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return viewModel;
        }
    }
}