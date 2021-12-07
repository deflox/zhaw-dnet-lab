using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab10_web_application
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery",
            new ScriptResourceDefinition
            {
                Path = "~/scripts/jquery-1.7.2.min.js",
                DebugPath = "~/scripts/jquery-1.7.2.min.js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.4.1.js"
            });
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            // reset
            this.RequiredFieldValidator1.Enabled = false;
            this.RequiredFieldValidator2.Enabled = false;
            this.weight.Text = "";
            this.height.Text = "";
            this.BMI.Text = "";
            this.RequiredFieldValidator1.Enabled = true;
            this.RequiredFieldValidator2.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // calculate
                double weightVal = Convert.ToDouble(weight.Text);
                double heightVal = Convert.ToDouble(height.Text);
                this.BMI.Text = Convert.ToString(weightVal / (heightVal * heightVal));
            }
        }
    }
}