package com.bstu.lab6;

import org.apache.commons.httpclient.HostConfiguration;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.methods.GetMethod;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Task2", value = "/Task2")
public class Task2 extends HttpServlet
{
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html");

        HttpClient client = new HttpClient();
        PrintWriter printWriter = response.getWriter();

        HostConfiguration hconf = new HostConfiguration();
        hconf.setHost("localhost",80,"http");
        client.setHostConfiguration(hconf);

        String urlnParam = request.getParameter("urln");
        ServletContext sc = getServletContext();
        String uri = sc.getInitParameter("URL" + urlnParam);
        String completedUri = "http://localhost:" +request.getServerPort()+request.getContextPath() + uri;
        if (uri != null)
        {
            GetMethod get = new GetMethod( completedUri);
            client.executeMethod(get);
            printWriter.println(get.getResponseBodyAsString());
        }
        else
        {
            printWriter.println("Parameter URLn not found");
        }
    }
}
