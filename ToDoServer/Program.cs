using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace ToDoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpListener = new HttpListener();
            httpListener.Prefixes.Add("http://localhost:51369/");
            httpListener.Start();

            var issueList = new IssueList(1000);

            while (true)
            {
                var requestContext = httpListener.GetContext();
                var request = requestContext.Request;
                var responseValue = "";

                if (request.Url.PathAndQuery == "/Issue")
                {
                    switch (request.HttpMethod)
                    {
                        case "GET":
                            requestContext.Response.StatusCode = 200; //OK
                            var issues = issueList.GetIssues();
                            responseValue = JsonConvert.SerializeObject(issues, Formatting.Indented);
                            break;

                        case "POST":
                            requestContext.Response.StatusCode = 200; //OK
                            responseValue = "ADD_NEW_ISSUE";
                            break;

                        case "PUT":
                            Console.WriteLine("EDIT_ISSUE");
                            requestContext.Response.StatusCode = 200; //OK
                            responseValue = "EDIT_ISSUE";
                            break;

                        case "DELETE":
                            Console.WriteLine("REMOVE_ISSUE");
                            requestContext.Response.StatusCode = 200; //OK
                            responseValue = "REMOVE_ISSUE";
                            break;

                        case "PATCH":
                            Console.WriteLine("SET_ISSUE_AS_DONE");
                            requestContext.Response.StatusCode = 200; //OK
                            responseValue = "SET_ISSUE_AS_DONE";
                            break;

                        default:
                            requestContext.Response.StatusCode = 500; //OK
                            responseValue = "Что то пошло не так";
                            break;
                    }
                }

                var stream = requestContext.Response.OutputStream;
                var bytes = Encoding.UTF8.GetBytes(responseValue);
                stream.Write(bytes, 0, bytes.Length);
                requestContext.Response.Close();
            }

            httpListener.Stop();
            httpListener.Close();
        }
    }
}
