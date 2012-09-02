﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using houser.Business;
using houser.utilities;

namespace houser
{
    public partial class _Default : System.Web.UI.Page
    {
        #region Private Variables.
        public int userID = 0;
        private string userName;
        private string password;
        private bool logedIn;
        private User user;
        #endregion

        #region UI events
        public void Page_Load(object sender, EventArgs e)
        {
           //If this is not a post back (first page load)
            if (!IsPostBack)
            {
                // See if we have checked to only get cached data...........This will probably go away.
                bool nonLiveData = chkNonLive.Checked;
                // Request the sherifsale page so we can get the available sale dates.
                string sheriffSaleDatePage = PageRequester.GetWebRequest("http://oklahomacounty.org/sheriff/SheriffSales/");
                // Create a list of dates
                List<string> dates = PageScraper.GetSheriffSaleDates(sheriffSaleDatePage);
                foreach (var date in dates)
                {
                    // Add dates to our drop down list.
                    ddlSaleDate.Items.Add(date);
                }

                // will need to be database call when list are dynamic.
                ListItem listItem = new ListItem();
                listItem.Text = "All";
                listItem.Value = "2";
                listItem.Selected = true;
                ddlList.Items.Add(listItem);
                ListItem listItem2 = new ListItem();
                listItem2.Text = "Review";
                listItem2.Value = "1";
                ddlList.Items.Add(listItem2);
                chkNonLive.Checked = true;
            }
            CheckLoginCookie();
        }

        // populate properties.
        protected void btnPopulateData_Click(object sender, EventArgs e)
        {
            PopulateData();
        }
        
        // If login cookie does not exist and the user and password are verified then create the login cookie.
        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {
            user = new User(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (user.UserID != null)
            {
                userID = user.UserID;
                logedIn = true;
                if (Request.Cookies["HouserLogin"] == null)
                {
                    CreateLoginCookie();
                }
            }
        }
        
        // needs to be replaced with jquery sort.
        protected void btnSortAddress_Click(object sender, EventArgs e)
        {
            BuildSheriffSalePropertyList("Address");
        }
        // needs to be replaced with jquery sort.
        protected void btnSortMinBid_Click(object sender, EventArgs e)
        {
            BuildSheriffSalePropertyList("SalePrice");
        }
        // needs to be replaced with jquery sort.
        protected void btnSortSQFT_Click(object sender, EventArgs e)
        {
            BuildSheriffSalePropertyList("Sqft");
        }
        // needs to be replaced with jquery sort.
        protected void btnSortBeds_Click(object sender, EventArgs e)
        {
            BuildSheriffSalePropertyList("Beds");
        }
        // needs to be replaced with jquery sort.
        protected void btnSortBaths_Click(object sender, EventArgs e)
        {
            BuildSheriffSalePropertyList("Baths");
        }

        // gets properties by list when selected list cahnges.
        protected void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateData();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Creates the actual markup for the properties.
        /// </summary>
        private void BuildListingPanels(DateTime date, string orderBy)
        {
            //BindingFlags b = BindingFlags.Instance | BindingFlags.Public;
            DataTable subjectProperties = SaleRecord.GetSaleProperitesByDate(date, orderBy, ddlList.SelectedValue);
            string listingPnlClass;
            string hasNoteClass = "";
            string inReviewList;
            string addRemoveList;
            StringBuilder html = new StringBuilder();
            foreach (DataRow property in subjectProperties.Rows)
            {

                bool isInReviewList = false;
                bool.TryParse(property["InReviewList"].ToString(), out isInReviewList);
                // if the property is in the review list then add the class.
                if (isInReviewList)
                {
                    inReviewList = "inReviewList";
                    addRemoveList = "Remove from list";
                }
                else
                {
                    inReviewList = "";
                    addRemoveList = "Add to review list";
                }
                if (!string.IsNullOrEmpty(property["Note"].ToString()))
                    hasNoteClass = "hasNote";
                else
                    hasNoteClass = "";

                html.Clear();
                
                listingPnlClass = "listingPanel";
                
                html.Append("<div class=\"listingWrapper\">");
                html.Append("<div class=\"indicator\"></div>");
                html.Append("<div id=\"" + property["AccountNumber"].ToString() + "\" class=\"" + listingPnlClass + "\">");
                html.Append("<span class=\"propertyData\">");
                html.Append("<span class=\"notes " + hasNoteClass + " \" id=\"" + property["AccountNumber"].ToString() + "\" >Notes</span>");
                html.Append("<span class=\"address\">" + property["Address"].ToString() + "</span>");
                html.Append("<span class=\"minBidWrapper\">$" + Convert.ToString(Convert.ToInt32(property["SalePrice"]) * .66) + "</span>");
                html.Append("<span class=\"sqft\">" + property["Sqft"].ToString() + "</span>");
                html.Append("<span class=\"beds\">" + property["Beds"].ToString() + "</span>");
                html.Append("<span class=\"baths\">" + property["baths"].ToString() + "</span>");
                html.Append("<span class=\"addToReview " + inReviewList + "\">" + addRemoveList + "</span>");
                html.Append("</span>");
                html.Append("</div>");
                html.Append("</div>");

                pnlListingPanel.Controls.Add(new LiteralControl(html.ToString()));
                // go here to see how to use scroll up down events http://api.jquery.com/scroll/  we will use it to make sure key down and wheel down move down one listing exactly.
            }
        }
        
        /// <summary>
        /// Builds the view of properties.
        /// </summary>
        private void BuildSheriffSalePropertyList(string orderBy)
        {
            if (logedIn)
            {
                if (!chkNonLive.Checked)
                {
                    string saleDate = ddlSaleDate.SelectedItem.Value.Replace("/", "%2f");
                    string finishedLoading = GetCompletePropertyList(saleDate, chkNonLive.Checked);
                }

                BuildListingPanels(Convert.ToDateTime(ddlSaleDate.SelectedItem.Value), orderBy);
            }
        }

        /// <summary>
        /// Check to see if there is a login cookie and if it is valid.
        /// </summary>
        private void CheckLoginCookie()
        {
            if (Request.Cookies["HouserLogin"] != null)
            {
                userName = Request.Cookies["HouserLogin"]["UserName"];
                password = Request.Cookies["HouserLogin"]["Password"];
                user = new User(userName, password);
                if (user.UserID != 0)
                {
                    userID = user.UserID;
                    logedIn = true;
                }
            }
        }

        /// <summary>
        /// Create the session cookie.
        /// </summary>
        private void CreateLoginCookie()
        {
            HttpCookie loginCookie = new HttpCookie("HouserLogin");
            loginCookie.Values.Add("UserName", txtUserName.Text.Trim());
            loginCookie.Values.Add("Password", txtPassword.Text.Trim());
            loginCookie.Expires = DateTime.Now.AddYears(2);
            Response.Cookies.Add(loginCookie);
        }
        
        /// <summary>
        /// Build the entire data structure for all properties.  Includes comparable data, property specs, ect.  03%2f15%2f2012
        /// </summary>
        private static string GetCompletePropertyList(string saleDate, bool nonLiveDataOnly)
        {
            string sherifSaleUrl = "http://oklahomacounty.org/sheriff/SheriffSales/saledetail.asp?SaleDates=" + saleDate;
            string sherifSaleWebRequestData = PageRequester.GetWebRequest(sherifSaleUrl);
            if (!string.IsNullOrWhiteSpace(sherifSaleWebRequestData))
                PageScraper.ScrapePropertyDatePiecesIntoDatabase(sherifSaleWebRequestData, saleDate);
            return "Finished Loading";
        }
        
        //----The use of multiple strings to fill in for the order by on the query needs to go.
        //  Switch this to jquery sorts... there is no reason to get the data more than once.
        // which will make this method pointless.  it may already be pointless.
        private void PopulateData()
        {
            BuildSheriffSalePropertyList("[Address]");
        }
        #endregion





    }
}