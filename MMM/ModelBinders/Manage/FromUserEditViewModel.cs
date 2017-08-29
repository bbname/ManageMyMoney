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

        //public User GetUserAfterEdit(UserEditViewModel viewModel, User userBeforeEdit)
        //{
        //    var userAfterEdit = userBeforeEdit;

        //    userAfterEdit.Id = viewModel.Id;
        //    userAfterEdit.FirstName = viewModel.FirstName;
        //    userAfterEdit.LastName = viewModel.LastName;
        //    userAfterEdit.Email = viewModel.Email;

        //    return userAfterEdit;
        //}
    }
}