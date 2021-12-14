using System;
using System.Web.UI;

namespace lab11_web_application
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected BMIControl.BMIControl BMIControl;
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
            this.weightElement.WeightText = "";
            this.height.Text = "";
            this.BMI.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // calculate
                double weightVal = Convert.ToDouble(weightElement.WeightText);
                if (weightElement.WeightUnitText == "lb")
                {
                    weightVal *= 0.45;
                }

                double heightVal = Convert.ToDouble(height.Text);
                double bmi = weightVal / (heightVal * heightVal);
                this.BMI.Text = Convert.ToString(bmi);
                //BMIImage.BMI = bmi;
                /*
                <%@ Register TagPrefix="my" Namespace="BMIControl" Assembly="BMIControl" %>
                <my:BMIControl id="BMIImage" Runat="server" ></my:BMIControl>
                 */
            }
        }
    }
}