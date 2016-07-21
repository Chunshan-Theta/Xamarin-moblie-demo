	using System;
	using Foundation;
	using UIKit;
	
	//set your UITableView
	//the program could :
	//1. set UITableView1.Source with string[]
	//2. set UITableViewRowAction's action,title,backgroundcolor
	public partial class ViewController : UIViewController
    {
		public override void ViewDidLoad()
        {
            base.ViewDidLoad();



            this.UITableView1.Delegate = new TableDelegate();
            
			string[] tableItems = new string[]
            {
                "1",
				"apple",
				"blue",
				"end"
            };
            this.UITableView1.Source = new TableSource(tableItems);
            this.UITableView1.ReloadData();
            this.UITableView1.Delegate = new TableDelegate();


        }
		
	}
	public class TableSource : UITableViewSource
    {

        string[] TableItems;
        string CellIdentifier = "TableCell";

        public TableSource(string[] items)
        {
            TableItems = items;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return TableItems.Length;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
            string item = TableItems[indexPath.Row];

            //---- if there are no cells to reuse, create a new one
            if (cell == null)
            { cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier); }

            cell.TextLabel.Text = item;

            return cell;
        }

    }


    public class TableDelegate : UITableViewDelegate
    {

        #region Constructors
        public TableDelegate()
        {
            
        }

        public TableDelegate(IntPtr handle) : base(handle)
        {
        }

        public TableDelegate(NSObjectFlag t) : base(t)
        {
        }

        #endregion
        #region Override Methods
        public override UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewRowAction hiButton = UITableViewRowAction.Create(
                UITableViewRowActionStyle.Default,
                "Hi",
                delegate {
                    Console.WriteLine("Hello World!");
                });
            RowSelected(tableView, indexPath);
            hiButton.BackgroundColor = UIColor.Blue;
            return new UITableViewRowAction[] { hiButton };
        }
        #endregion
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            Console.WriteLine("RowSelected");
        }
    }