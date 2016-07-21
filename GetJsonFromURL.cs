using System;
using System.Collections.Generic;
using System.Json;
using System.Net;
using System.IO;
 
 public string FetchWeatherAsync(string url)
        {
            // Create an HTTP web request using the URL:
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(new Uri(url));

            request.Method = "GET";

            // Send the request to the server and wait for the response:
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Get a stream representation of the HTTP web response:
                using (Stream stream = response.GetResponseStream())
                {
                    // Use this stream to build a JSON document object:
                    StreamReader streamreader = new StreamReader(stream);
                    string content = streamreader.ReadToEnd();
                    //Console.Out.WriteLine("Response: {0}", content.ToString());
                    streamreader.Close();
                    stream.Close();
                    // Return the JSON document:
                    return content;
                }
            }
        }