using Foundation;
using IOSListTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Net;
using System.Threading.Tasks;
using UIKit;

namespace IOSListTest
{
    public partial class ViewController : UIViewController
    {
        string urlPokemonApi = "https://pokeapi.co/api/v2/pokemon/";
        List<string> tItems;
        List<PokemonModel> pklist;
        UIAlertController AlertMsn;

        public  ViewController(IntPtr handle) : base(handle)
        {
            tItems = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                tItems.Add("Number : " + i.ToString());
            }

          // _ = GetPokemonsApi();

        }

        public async Task<JsonValue> GetPokemonsApi()
        {

            var reqhttp = (HttpWebRequest)WebRequest.Create(new Uri(urlPokemonApi));
            reqhttp.ContentType = "application/json";
            reqhttp.Method = "GET";

            using (WebResponse resp = await reqhttp.GetResponseAsync())
            {
                using (System.IO.Stream stream = resp.GetResponseStream())
                {
                    var jsonResp = await Task.Run(() => JsonValue.Load(stream));//JsonValue.Load(stream));
                    return jsonResp;
                }
            }
        }

        public void Trasnform(JsonValue jx)
        {
            try
            {
                var dt = JsonConvert.DeserializeObject<PokemonCallApiModel>(jx.ToString());
                foreach (var pk in dt.results)
                {
                    pklist.Add(new PokemonModel
                    {
                        Name = pk.name,
                        Url = pk.url,
                        Link = "https://img.pokemondb.net/artwork/"+pk.name+".jpg"
                    });
                    
                }
            }
            catch (Exception ex)
            {
                Alert("error",ex.ToString());
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            MyTableView.Source = new MyTableViewSource(tItems);
        }
        public void Alert(string title, string msn)
        {
            AlertMsn = UIAlertController.Create(title,msn,UIAlertControllerStyle.Alert);
            AlertMsn.AddAction(UIAlertAction.Create("ok", UIAlertActionStyle.Default,null));
            PresentViewController(AlertMsn, true, null);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}