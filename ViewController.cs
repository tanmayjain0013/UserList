using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using Newtonsoft.Json;
using UIKit;

namespace UserList
{
    public partial class ViewController : UIViewController
    {
        ObservableCollection<User> users = new ObservableCollection<User>();

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigarionBarSetup();
            UsersTableView.RowHeight = UITableView.AutomaticDimension;
            UsersTableView.EstimatedRowHeight = 40f;
            UsersTableView.ReloadData();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            LoadLocalUserList();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        private void NavigarionBarSetup() {
            var addButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            addButton.Clicked += (object sender, EventArgs e) =>
            {
                UIStoryboard storyboard = this.Storyboard;
                AddDetailsViewController addDetails = (AddDetailsViewController)storyboard.InstantiateViewController("AddDetailsViewController");
                var addNaV = new UINavigationController(addDetails);
                PresentViewController(addNaV, true, null);
            };

                NavigationItem.RightBarButtonItem = addButton;
        }

        private void LoadLocalUserList() 
        {
            var storedList = NSUserDefaults.StandardUserDefaults.StringForKey("Users");
            if (storedList != null) {
                users = new ObservableCollection<User>(JsonConvert.DeserializeObject<List<User>>(storedList));
                UsersTableView.Source = new UserTVS(users);
            }
        }
    }
}
