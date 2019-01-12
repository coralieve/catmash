using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catmashlive
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (HttpClient cli = new HttpClient())
            {
                HttpResponseMessage jsonGame = cli.GetAsync(new Uri(Properties.Settings.Default.backendURL + "/api/rank")).Result;
                string content = jsonGame.Content.ReadAsStringAsync().Result;
                List<Cat> catArray = JsonConvert.DeserializeObject<List<Cat>>(content);

                allCats.DataSource = catArray;
                allCats.DataBind();
            }
        }

        protected void allCats_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var cat = e.Item.DataItem as Cat;
            if (cat != null)
            {
                var imgCat = e.Item.FindControl("imgCat") as Image;
                imgCat.ImageUrl = cat.url;
            }
        }
    }
}