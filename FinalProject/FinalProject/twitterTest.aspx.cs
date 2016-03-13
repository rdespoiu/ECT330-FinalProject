using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class twitterTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }
        protected TwitterContext GetTwitterContext()
        {


            var xAuthAuthorizer = new SingleUserAuthorizer();
            var inMemoryCredentials = new XAuthCredentials();

            inMemoryCredentials.ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            inMemoryCredentials.ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            inMemoryCredentials.OAuthToken = ConfigurationManager.AppSettings["AccessToken"];
            inMemoryCredentials.OAuthTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

            xAuthAuthorizer.CredentialStore = inMemoryCredentials;
            var twitterContext = new TwitterContext(xAuthAuthorizer);
            return twitterContext;

            


            /*  var userAuthorizer = new SingleUserAuthorizer
              {

                  Credentials = new InMemoryCredentials
                  {
                      ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"],
                      ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"],
                      OAuthToken = ConfigurationManager.AppSettings["AccessToken"],
                      AccessToken = ConfigurationManager.AppSettings["AccessTokenSecret"]
                  }
              };

              //Initialize Context
              var twitterContext = new TwitterContext(userAuthorizer);
              return twitterContext;
              */
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var twitterContext = GetTwitterContext();

            //Create LINQ Expression
            var tweets = (from tweet in twitterContext.Status

                              //Type is required
                          where tweet.Type == StatusType.User
                          && tweet.ScreenName == txtSearchTerm.Text
                          && tweet.Count == 5
                          select tweet).ToList();

            //Iterate over results
            pnTwitterResults.Visible = true;
            rptTweets.Visible = true;
            rptTweets.DataSource = tweets;
            rptTweets.DataBind();

            var trends = (from trend in twitterContext.Trends
                          where trend.Type == TrendType.Place
                          // http://developer.yahoo.com/geo/geoplanet/guide/index.html
                          // WoeID for Cook County IL	
                          && trend.WoeID == 2379574
                          select new ListItem { Text = trend.Name, Value = trend.SearchUrl }).ToList();

            drpTrends.DataSource = trends;
            drpTrends.DataBind();
            drpTrends.Items.Insert(0, new ListItem { Text = "", Value = "-1" });
        }

        protected void drpTrends_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (drpTrends.SelectedValue != "-1")
            {
                //Initialize Context
                var twitterContext = GetTwitterContext();

                //Create LINQ Expression
                var searchQueryResults = (from search in twitterContext.Search
                                          where search.Type == SearchType.Search
                                          && search.Query == drpTrends.SelectedValue
                                          && search.Count == 5
                                          select search).SingleOrDefault();


                rptTwitterTrendResults.Visible = true;

                rptTwitterTrendResults.DataSource = searchQueryResults.Statuses;
                rptTwitterTrendResults.DataBind();
            }
        }
    }
}