﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class IndexAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSeguridad_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewUser.aspx");
    }

    protected void btnAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Index.aspx");
    }
}