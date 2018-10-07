using Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UIKit;

namespace UserList
{
    public partial class AddDetailsViewController : UIViewController
    {
        public AddDetailsViewController (IntPtr handle) : base (handle)
        {

        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.SetupNavigation();
        }

        //Validates and Save User
        partial void UIButton7238_TouchUpInside(UIButton sender)
        {
            var userName = UserNameTextField.Text;
            var password = PasswordTextField.Text;

            if (userName.Length == 0) {
                this.ShowAlert("User Name Missing");
            }
            if (password.Length == 0) {
                this.ShowAlert("Password Missing");
            } else {
                if (!ValidatePassword(password))
                {
                    this.ShowAlert("Passwords must consist of a mixture of lowercase letters and numerical digits only."
                    + " Passwords must be between 5 and 12 characters in length."
                                              + "Passwords must not contain any sequence of characters immediately followed by the same sequence.");
                }
                else
                {
                    this.SaveUser(new User { UserName = userName, Password = password });
                }
            }
        }

        //Navigation Bar setup
        private void SetupNavigation()
        {
            this.NavigationItem.Title = "Add New User";
            var cancelButton = new UIBarButtonItem(UIBarButtonSystemItem.Cancel);
            cancelButton.Clicked += (object sender, EventArgs e) =>
            {
                this.DismissViewController(true, null);
            };
            this.NavigationItem.LeftBarButtonItem = cancelButton;
        }

        //Password Validation for the three requirements.
        private bool ValidatePassword(string pwd)
        {
            return Regex.IsMatch(pwd,
                     @"^(?!.*(?<g>[a-zA-Z\d]+)\k<g>.*)[a-zA-Z\d]{5,12}(?<=.*[a-zA-Z].*)(?<=.*\d.*)$");
        }

        private void SaveUser(User user)
        {
            var storedList = NSUserDefaults.StandardUserDefaults.StringForKey("Users");
            if (storedList == null) {
                var users = new List<User>();
                users.Add(user);
                this.SaveToLocal(users);
            } else {
                var local = JsonConvert.DeserializeObject<List<User>>(storedList);
                if (storedList.Contains(user.UserName)) {
                    ShowAlert("User name already exists! Please add a unique user name");
                    return;
                }
                local.Add(user);
                this.SaveToLocal(local);
            }
            this.DismissViewController(true, null);
        }

        private void SaveToLocal(List<User> users) {
            var jsonString = JsonConvert.SerializeObject(users);
            NSUserDefaults.StandardUserDefaults.SetString(jsonString, "Users");
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        private void ShowAlert(String message)
        {
            var alert = UIAlertController.Create("Please check", message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, animated: true, completionHandler: null);
        }

    }
}

