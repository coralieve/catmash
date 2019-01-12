using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                btnLeftCat.AlternateText = catArray[0].id;
                btnRightCat.ImageUrl = catArray[1].url;
                btnRightCat.AlternateText = catArray[1].id;
            }

        }

        protected void leftCat_Click(object sender, ImageClickEventArgs e)
        {
            endGame(1);
            ShowRandomCats();
        }

        protected void rightCat_Click(object sender, ImageClickEventArgs e)
        {
            endGame(-1);
            ShowRandomCats();
        }

        protected void nextCats_Click(object sender, EventArgs e)
        {
            endGame(0);
            ShowRandomCats();
        }

        /// <summary>
        /// Send game result to backend
        /// </summary>
        /// <param name="outcome">1 win, -1  los, 0 draw</param>
        private void endGame(int outcome)
        {
            ResultParameters param = new ResultParameters();
            param.opponentCatId = btnRightCat.AlternateText;
            param.outcome = outcome;
            using (HttpClient cli = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8,"application/json");
                HttpResponseMessage mes = cli.PutAsync(new Uri(Properties.Settings.Default.backendURL + "/api/result/" + btnLeftCat.AlternateText), content).Result;
            }
        }
    }
}