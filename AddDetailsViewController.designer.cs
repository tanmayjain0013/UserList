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
    [Register ("AddDetailsViewController")]
    partial class AddDetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField PasswordTextField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField UserNameTextField { get; set; }

        [Action ("UIButton7238_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void UIButton7238_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (PasswordTextField != null) {
                PasswordTextField.Dispose ();
                PasswordTextField = null;
            }

            if (UserNameTextField != null) {
                UserNameTextField.Dispose ();
                UserNameTextField = null;
            }
        }
    }
}