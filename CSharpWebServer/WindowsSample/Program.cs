// See https://aka.ms/new-console-template for more information

using CSharpWebServer;


CSWebServer server = new CSWebServer();

server.DocumentRoot = Directory.GetCurrentDirectory() + "/www";
server.Address = "http://127.0.0.1:8888";

server.Start();
