using Foundation;
using System;
using UIKit;

namespace UserList
{
    public partial class UserCell : UITableViewCell
    {
        public UserCell (IntPtr handle) : base (handle)
        {
        }

        internal void UpdateCell(User user)
        {
            UserNameLabel.Text = user.UserName;
            PasswordLabel.Text = user.Password;
        }
    }
}