using System.Text;

namespace HtmlRenderSample
{
    public abstract class Element
    {
        public string Id { get; set; }
        public abstract string Render();
    }

    public class Image : Element
    {
        public string Source { get; set; }
        public string Alternate { get; set; }
        public string Style { get; set; }

        public override string Render()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<img");

            if (!string.IsNullOrEmpty(Id))
            {
                builder.Append(" id=\"").Append(Id).Append("\"");
            }
            if (!string.IsNullOrEmpty(Source))
            {
                builder.Append(" src=\"").Append(Source).Append("\"");
            }
            if (!string.IsNullOrEmpty(Alternate))
            {
                builder.Append(" alt=\"").Append(Alternate).Append("\"");
            }
            if (!string.IsNullOrEmpty(Style))
            {
                builder.Append(" style=\"").Append(Style).Append("\"");
            }
            builder.Append(">");

            string html = builder.ToString();
            
            return html;

            // Similar one line
            // return $"<img src=\"{Source}\" alt=\"{Alternate}\" style=\"{Style}\">";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Image image = new Image()
            {
                Source = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/97/The_Earth_seen_from_Apollo_17.jpg/330px-The_Earth_seen_from_Apollo_17.jpg",
                Style = "margin:0px",
                Alternate = "No image supported"
            };
            string html = image.Render();
        }
    }
}
