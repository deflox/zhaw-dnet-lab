using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab11_web_application
{
    public partial class Weight : System.Web.UI.UserControl
    {
        public string WeightText
        {
            get { return weight.Text; }
            set { weight.Text = value; }
        }

        public string WeightUnitText
        {
            get { return weightUnit.Text; }
            set { weightUnit.Text = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Select(object sender, EventArgs arg)
        {
            WeightText = weight.Text;
            WeightUnitText = weightUnit.Text;
        }
    }
}