package com.bstu.lab2;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.*;
import javax.servlet.http.*;

public class Sss extends HttpServlet
{
    public Sss()
    {
        super();
        System.out.println("Sss - servlet. Constructor");
    }
    public void init(ServletConfig sc) throws ServletException
    {
        super.init();
        System.out.println("Sss - servlet. Init");
    }
    public void destroy()
    {
        super.destroy();
        System.out.println("Sss - servlet. Destroy");
    }

    protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        System.out.println("Sss - servlet. Service: " + request.getMethod());

        PrintWriter pw = response.getWriter();
        pw.println("<html><body>"
                + "<h2>Sss - servlet. Service method: " + request.getMethod() + "</h2>"
                + "<h3>ServerName: " + request.getServerName() + "</h3>"
                + "<h3>LocalAddr: " + request.getLocalAddr() + "</h3>"
                + "<br>Sss - servlet. Service. Firstname: " + request.getParameter("firstname")
                + "<br>Sss - servlet. Service. Lastname: " + request.getParameter("lastname")
                + "</body></html>");

        switch(request.getMethod())
        {
            case "GET":
            {
                doGet(request,response);
            }
            case "POST":
            {
                doPost(request,response);
            }
            default:
            {
                response.setStatus(HttpServletResponse.SC_METHOD_NOT_ALLOWED);
            }
        }
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html");
        PrintWriter pw = response.getWriter();
        pw.println("<html><body>"
                + "<br>Sss - doPost. Firstname: " + request.getParameter("firstname")
                + "<br>Sss - doPost. Lastname: " + request.getParameter("lastname")
                + "</body></html>");
        pw.close();
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
    {
        response.setContentType("text/html");
        PrintWriter pw = response.getWriter();
        pw.println("<html><body>"
                +"<br>Sss - doGet.  URL = " + request.getRequestURL()
                +"<br>Sss - doGet.  QueryString = " + request.getQueryString()
                +"<br>Sss - doGet.  FirstName = " + request.getParameter("firstname")
                +"<br>Sss - doGet. LastName = " + request.getParameter("lastname")
                +"<br>Sss - doGet. getRemoteHost: " + request.getRemoteHost()
                +"</body></html>");
        pw.close();
    }
}