using System.Text;

namespace RestWithAspNet.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel { get; set; }
        public string Type { get; set; }
        public string Action { get; set; }
        public string Href {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder sb = new StringBuilder(_href);
                    return sb.Replace("%2F", "/").ToString();
                }
            }
            set { _href = value; }
        }

        private string _href;
    }
}
