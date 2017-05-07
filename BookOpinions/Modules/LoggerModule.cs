using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BookOpinions.Modules
{
    public class LoggerModule : IHttpModule
    {
        private const string fileName = "requestLogs.txt";
        private HttpApplication _context;
        private DateTime _incomingTime;
        private DateTime _outgoingTime;
        private Uri _url;

        public void Init(HttpApplication context)
        {
            this._context = context;
            context.BeginRequest += SetIncomeTime;
            context.BeginRequest += SetUrlOfRequest;
            context.EndRequest += SetOutgoingTime;
            context.EndRequest += LogRequest;
        }

        private void LogRequest(object sender, EventArgs e)
        {
            var timeSpanOfRequest = this._outgoingTime - this._incomingTime;
            var pathToFolder = this._context.Server.MapPath("~/Content/Logs");
            var fullPath = Path.Combine(pathToFolder, fileName);

            StringBuilder requestLog = new StringBuilder();
            requestLog.AppendLine("Request log: ");
            requestLog.AppendLine($"Request income time: {this._incomingTime}");
            requestLog.AppendLine($"Request outgoing time: {this._outgoingTime}");
            requestLog.AppendLine($"Request handle timespan: {timeSpanOfRequest}");
            requestLog.AppendLine($"Request URL: {this._url}");
            requestLog.AppendLine(new string('-', 40));

            File.AppendAllText(fullPath, requestLog.ToString());
        }

        private void SetUrlOfRequest(object sender, EventArgs e)
        {
            this._url = this._context.Request.Url;
        }

        private void SetOutgoingTime(object sender, EventArgs e)
        {
            this._outgoingTime = DateTime.Now;
        }

        private void SetIncomeTime(object sender, EventArgs e)
        {
            this._incomingTime = DateTime.Now;
        }

        public void Dispose()
        {
        }
    }
}