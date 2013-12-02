﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_Content : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int articleID = 0;
        int.TryParse(Request.QueryString["ID"], out articleID);
        if (!IsPostBack)
        {
            var article = DB.GetArticle(articleID);
            if (article != null)
            {
                ctTitle.Text = _.EncodeHtml(article.Title);
                ctPostDate.Text = article.PostDate.ToString("yyyy/MM/dd HH:mm:ss");
                ctContent.Text = _.EncodeHtml(article.Content);
            }
            else
            {
                _.Redirect("Index.aspx");
            }
        }
    }
}