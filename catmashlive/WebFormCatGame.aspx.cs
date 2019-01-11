using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace catmashlive
{
    public partial class WebFormCatGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ShowRandomCats();
        }

        private void ShowRandomCats()
        {
            using (HttpClient cli = new HttpClient())
            {
                HttpResponseMessage jsonGame =  cli.GetAsync(new Uri(Properties.Settings.Default.backendURL + "/api/game")).Result;
                string content = jsonGame.Content.ReadAsStringAsync().Result;
                List <Cat> catArray = JsonConvert.DeserializeObject<List<Cat>>(content);
               
                btnLeftCat.ImageUrl = catArray[0].url;
                btnLeftCat.ID = catArray[0].id;
                btnRightCat.ImageUrl = catArray[1].url;
                btnRightCat.ID = catArray[1].id;
            }

        }

        protected void leftCat_Click(object sender, ImageClickEventArgs e)
        {

            ShowRandomCats();

        }

        protected void rightCat_Click(object sender, ImageClickEventArgs e)
        {

            ShowRandomCats();


        }




        protected void nextCats_Click(object sender, EventArgs e)
        {
            ShowRandomCats();

        }
    }
}