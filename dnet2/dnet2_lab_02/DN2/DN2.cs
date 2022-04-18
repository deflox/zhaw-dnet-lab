using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Net;
using System.Net.Security;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace DT2
{
    public enum CallMode { Sync, Async, AsyncTimeout };

    public class UrlTester
    {
        public event Action<string> PageStart;
        public event Action<string, int> PageLoaded;
        public event Action<string, int, int> LoadSummary;
        public event Action<string> Timeout;

        public void SetupEvents()
        {
            IDictionary<string, Stopwatch> sw = new Dictionary<string, Stopwatch>();
            PageStart = url => { Console.WriteLine(url + " ..."); sw.Add(url, Stopwatch.StartNew()); };
            PageLoaded += (url, size) => {
                sw[url].Stop();
                Console.WriteLine(url + " " + size + " bytes " + (int)sw[url].Elapsed.TotalMilliseconds + " ms");
                sw.Remove(url);
            };
            Timeout = (url) => {
                sw[url].Stop(); Console.WriteLine(url + " Timeout"); sw.Remove(url);
            };
            LoadSummary += (s, size, time) => { Console.WriteLine(s + ": " + size + " bytes " + time + " ms"); };
        }

        public List<string> UrlList = new List<string> {
            "https://www.zhaw.ch",
            "https://radar.zhaw.ch/~rege",
            "https://www.zhaw.ch/de/linguistik/",
            "https://www.zhaw.ch/de/psychologie/",
            "https://www.zhaw.ch/de/archbau/",
            "https://www.zhaw.ch/de/gesundheit/",
            "https://www.zhaw.ch/de/lsfm/",      
            // very slow sites 
            /*
            "http://www.airkoryo.com.kp/",
            "http://www.manmulsang.com.kp/",
            "http://tourismdprk.gov.kp/",
            "http://www.kut.edu.kp/"
            */
        };

        public void IgnoreCertificateValidation()
        {
            System.Net.ServicePointManager.Expect100Continue = true;
            System.Net.ServicePointManager.ServerCertificateValidationCallback
                += new RemoteCertificateValidationCallback((sender, certificate, chain, policyErrors) => true);
        }

        public virtual int GetPageSize(string url)
        {
            // The downloaded resource ends up in the variable named content.
            byte[] byteContent;
            // Initialize an HttpWebRequest for the current URL.
            var webReq = (HttpWebRequest)WebRequest.Create(url);
            //if (PageStart != null) PageStart (url);
            Stopwatch sw = Stopwatch.StartNew();
            // Send the request to the Internet resource and wait for
            // the response.
            using (WebResponse response = webReq.GetResponse())
            {
                // Get the stream that is associated with the response.
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(responseStream))
                    {
                        String content = sr.ReadToEnd();
                        byteContent = Encoding.UTF8.GetBytes(content);
                    }
                }
            }

            return byteContent.Length;
        }

        public int GetUrlSync(string url)
        {
            PageStart(url);
            int size = GetPageSize(url);
            PageLoaded(url, size);
            return size;
        }

        /* TO BE DONE */
        public async Task<int> GetUrlAsync(string url)
        {
            PageStart(url);
            /* TO BE DONE */
            Task<int> size = Task.Run(() => {
                return GetPageSize(url);
            });
            await size;
            PageLoaded(url, size.Result);
            return size.Result;
        }

        /* TO BE DONE */
        public async Task<int> GetUrlAsyncTimeout(string url, int millis)
        {
            PageStart(url);
            /* TO BE DONE */
            Task<int> task = Task.Run(() => {
                return GetPageSize(url);
            });
            var result = await Task.WhenAny(task, Task.Delay(millis));
            if (result == task)
            {
                PageLoaded(url, task.Result);
                return task.Result;
            }
            else
            {
                Timeout(url);
                return 0;
            }
        }


        public void GetAllUrls(List<string> urlList, CallMode callMode)
        {
            // get a list of web addresses.
            int totalSize = 0;
            Stopwatch sw = Stopwatch.StartNew();
            if (callMode == CallMode.Sync)
            {
                Console.WriteLine("\nCalling Sync");
                foreach (var url in urlList)
                {
                    totalSize += GetUrlSync(url);
                }
            }
            else if (callMode == CallMode.Async)
            {
                Console.WriteLine("\nCalling Async");
                /* TO BE DONE */
                Parallel.ForEach(urlList, url => totalSize += GetUrlAsync(url).Result);
            }
            else if (callMode == CallMode.AsyncTimeout)
            {
                Console.WriteLine("\nCalling Async Timeout");
                /* TO BE DONE */
                Parallel.ForEach(urlList, url => totalSize += GetUrlAsyncTimeout(url, 100).Result);
            }
            LoadSummary("Total", totalSize, (int)sw.Elapsed.TotalMilliseconds);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Starting ...");
            UrlTester urlTester = new UrlTester();
            urlTester.IgnoreCertificateValidation();
            ThreadPool.SetMinThreads(urlTester.UrlList.Count * 2, urlTester.UrlList.Count * 2);
            urlTester.SetupEvents();
            urlTester.GetAllUrls(urlTester.UrlList, CallMode.Sync);
            urlTester.GetAllUrls(urlTester.UrlList, CallMode.Async);
            urlTester.GetAllUrls(urlTester.UrlList, CallMode.AsyncTimeout);
            Console.Write("Press any key to continue ...\n");
            Console.ReadKey(true);
        }
    }
}