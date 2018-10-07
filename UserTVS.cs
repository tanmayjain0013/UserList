using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Foundation;
using UIKit;

namespace UserList
{
    internal class UserTVS : UITableViewSource
    {
        private ObservableCollection<User> users;

        public UserTVS(ObservableCollection<User> users)
        {
            this.users = users;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (UserCell) tableView.DequeueReusableCell("cell_id", indexPath);

            var user = users[indexPath.Row];

            cell.UpdateCell(user);

            return cell;

        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return users.Count;
        }
    }
}