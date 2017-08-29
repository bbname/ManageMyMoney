using MMM.Model;
using MMM.Models;

namespace MMM.ModelBinders.Manage
{
    public class FromUserEditViewModel
    {
        public User GetUserAfterEdit(UserEditViewModel viewModel, User userBeforeEdit)
        {
            userBeforeEdit.FirstName = viewModel.FirstName;
            userBeforeEdit.LastName = viewModel.LastName;
            userBeforeEdit.Email = viewModel.Email;

            return userBeforeEdit;
        }

    }
}