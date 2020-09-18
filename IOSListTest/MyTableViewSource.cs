using System;
using System.Collections.Generic;
using Foundation;
using IOSListTest.Models;
using UIKit;

namespace IOSListTest
{

   
    public class MyTableViewSource : UITableViewSource
    {
        List<string> tableItems;
        //List<PokemonModel> pklist;
        public MyTableViewSource(List<string> tItems)
        {
            tableItems = tItems;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell("CellT");
            cell.TextLabel.Text = tableItems[indexPath.Row];

            //using (var url = new NSUrl("https://img.pokemondb.net/artwork/pikachu.jpg"))
            //using (var data = NSData.FromUrl(url))
            //cell.ImageView.Image = UIImage.LoadFromData(data);
        
            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return tableItems.Count;
        }
    }
}
