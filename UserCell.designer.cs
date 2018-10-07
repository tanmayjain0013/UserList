// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace UserList
{
    [Register ("UserCell")]
    partial class UserCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PasswordLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel UserNameLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (PasswordLabel != null) {
                PasswordLabel.Dispose ();
                PasswordLabel = null;
            }

            if (UserNameLabel != null) {
                UserNameLabel.Dispose ();
                UserNameLabel = null;
            }
        }
    }
}