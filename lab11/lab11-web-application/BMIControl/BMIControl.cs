using System;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BMIControl
{
    public class BMIControl : WebControl
    {
        public double BMI { get; set; }

        protected override void Render(HtmlTextWriter w)
        {
			var a = System.Reflection.Assembly.GetExecutingAssembly();
			System.Drawing.Image img = new Bitmap(Properties.Resource.bmi18);
			if (BMI >= 20)
			{
				img = new Bitmap(Properties.Resource.bmi20);
			}
			else if (BMI >= 25)
			{
				img = new Bitmap(Properties.Resource.bmi25);
			}
			else if (BMI >= 30)
			{
				img = new Bitmap(Properties.Resource.bmi30);
			}
			else if (BMI >= 40)
			{
				img = new Bitmap(Properties.Resource.bmi40);
			}

			w.Write("<img src='data:image/png;base64,");
			w.Write(GetStringFromImage(img));
			w.Write("'/>");
		}

		/// <summary>
		/// Konvertiert ein Bild in einen Base64-String
		/// </summary>
		/// <param name="image">
		/// Zu konvertierendes Bild
		/// </param>
		/// <returns>
		/// Base64 Repräsentation des Bildes
		/// </returns>
		public static string GetStringFromImage(System.Drawing.Image image)
		{
			if (image != null)
			{
				ImageConverter ic = new ImageConverter();
				byte[] buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
				return Convert.ToBase64String(
					buffer,
					Base64FormattingOptions.InsertLineBreaks);
			}
			else
				return null;
		}

		//---------------------------------------------------------------------
		/// <summary>
		/// Konvertiert einen Base64-String zu einem Bild
		/// </summary>
		/// <param name="base64String">
		/// Zu konvertierender String
		/// </param>
		/// <returns>
		/// Bild das aus dem String erzeugt wird
		/// </returns>
		public static System.Drawing.Image GetImageFromString(string base64String)
		{
			byte[] buffer = Convert.FromBase64String(base64String);

			if (buffer != null)
			{
				ImageConverter ic = new ImageConverter();
				return ic.ConvertFrom(buffer) as System.Drawing.Image;
			}
			else
				return null;
		}
	}
}