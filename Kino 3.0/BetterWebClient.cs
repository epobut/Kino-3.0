using System;
using System.Net;

/// A (slightly) better version of .Net's default WebClient. The ...
public class BetterWebClient : WebClient
{
    private WebRequest _request = null;

    /// Initializes a new instance of the BetterWebClient class.  <pa...
    public BetterWebClient(CookieContainer cookies = null, bool autoRedirect = true)
    {
        CookieContainer = cookies ?? new CookieContainer();
        AutoRedirect = autoRedirect;
    }

    /// <summary>
    /// Gets or sets a value indicating whether to automatically redirect when a 301 or 302 is returned by the request.
    /// </summary>
    /// <value>
    ///   <c>true</c> if the client should handle the redirect automatically; otherwise, <c>false</c>.
    /// </value>
    public bool AutoRedirect { get; set; }

    /// <summary>
    /// Gets or sets the cookie container. This contains all the cookies for all the requests.
    /// </summary>
    /// <value>
    /// The cookie container.
    /// </value>
    public CookieContainer CookieContainer { get; set; }

    /// Gets the cookies header (Set-Cookie) of the last request.
    public string Cookies
    {
        get { return GetHeaderValue("Set-Cookie"); }
    }

    /// Gets the location header for the last request.
    public string Location
    {
        get { return GetHeaderValue("Location"); }
    }

    /// Gets the status code. When no request is present, <see cref="...
    public HttpStatusCode StatusCode
    {
        get
        {
            var result = HttpStatusCode.Gone;

            if (_request != null)
            {
                var response = base.GetWebResponse(_request) as HttpWebResponse;

                if (response != null)
                {
                    result = response.StatusCode;
                }
            }

            return result;
        }
    }

    /// Gets or sets the setup that is called before the request is d...
    public Action<HttpWebRequest> Setup { get; set; }

    /// Gets the header value.
    public string GetHeaderValue(string headerName)
    {
        if (_request != null)
        {
            return base.GetWebResponse(_request)?.Headers?[headerName];
        }

        return null;
    }

    /// Returns a <see cref="T:System.Net.WebRequest" /> object for t...
    protected override WebRequest GetWebRequest(Uri address)
    {
        _request = base.GetWebRequest(address);

        var httpRequest = _request as HttpWebRequest;

        if (_request != null)
        {
            httpRequest.AllowAutoRedirect = AutoRedirect;
            httpRequest.CookieContainer = CookieContainer;
            httpRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            Setup?.Invoke(httpRequest);
        }

        return _request;
    }
}