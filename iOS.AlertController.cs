//source:https://developer.xamarin.com/guides/ios/user_interface/controls/part_6_-_other_controls/
//you can use this to creat Alert Controller
using System;
using UIKit;

private void Btn_selectCity_TouchUpInside(object sender, EventArgs e)
{

    // Create a new Alert Controller
    UIAlertController actionSheetAlert = UIAlertController.Create("Action Sheet", "Select an item from below", UIAlertControllerStyle.ActionSheet);

    // Add Actions           
    actionSheetAlert.AddAction(UIAlertAction.Create("one", UIAlertActionStyle.Default, (action) => Console.WriteLine("Item pressed.")));    
    actionSheetAlert.AddAction(UIAlertAction.Create("two", UIAlertActionStyle.Default, (action) => Console.WriteLine("Item pressed.")));
    actionSheetAlert.AddAction(UIAlertAction.Create("three", UIAlertActionStyle.Default, (action) => Console.WriteLine("Item pressed.")));
    actionSheetAlert.AddAction(UIAlertAction.Create("four", UIAlertActionStyle.Default, (action) => Console.WriteLine("Item pressed.")));
 
    actionSheetAlert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (action) => Console.WriteLine("Cancel button pressed.")));

    // Required for iPad - You must specify a source for the Action Sheet since it is
    // displayed as a popover
    UIPopoverPresentationController presentationPopover = actionSheetAlert.PopoverPresentationController;
    if (presentationPopover != null)
    {
        presentationPopover.SourceView = this.View;
        presentationPopover.PermittedArrowDirections = UIPopoverArrowDirection.Up;
    }

    // Display the alert
    this.PresentViewController(actionSheetAlert, true, null);
}
