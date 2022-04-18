using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DT3
{
    public class UrlTesterModel : INotifyPropertyChanged /* TO BE DONE */
    {
        public event PropertyChangedEventHandler PropertyChanged;

        int size;
        int time;
        string url;
        DT2.UrlTester urlTester;

        public UrlTesterModel()
        {
            urlTester = new DT2.UrlTester();
            IDictionary<string, Stopwatch> sw = new Dictionary<string, Stopwatch>();
            urlTester.PageStart += url => { sw.Add(url, Stopwatch.StartNew()); };
            urlTester.PageLoaded += (url, size) => {
                sw[url].Stop();
                int time = (int)sw[url].Elapsed.TotalMilliseconds;
                Size = size;
                Time = time;
                sw.Remove(url);
            };
        }

        public int Size
        {
            get { return size; }
            set
            {
                size = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Size"));

            } /* TO BE DONE */
        }

        public int Time
        {
            get { return time; }
            set
            {
                time = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Time"));

            }/* TO BE DONE */
        }

        public string Url
        {
            get { return url; }
            set
            {
                url = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Url"));
                Task.Run(() => urlTester.GetUrlAsync(value));

            }/* TO BE DONE */
        }
    }
}
