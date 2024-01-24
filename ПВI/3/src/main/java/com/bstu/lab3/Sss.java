package com.bstu.lab3;

import java.io.IOException;
import java.io.PrintWriter;
import java.lang.reflect.Method;
import javax.servlet.*;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;

import org.apache.commons.httpclient.HostConfiguration;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.methods.GetMethod;
import org.apache.commons.httpclient.methods.PostMethod;
import org.apache.commons.httpclient.params.HttpClientParams;

@WebServlet(name = "Sss", value = "/Sss")
public class Sss extends HttpServlet {
    private ServletConfig configServ;
    public Sss()
    {
        super();
        System.out.println("Sss - сonstructor");
    }

    @Override
    public void init(ServletConfig config) throws ServletException
    {
        super.init(config);
        this.configServ=config;
        configServ.getServletContext().log("Sss - init");
    }

    @Override
    public void destroy()
    {
        super.destroy();
        configServ.getServletContext().log("Sss - destroy");
    }

    @Override
    protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        //super.service(request, response);

        configServ.getServletContext().log("Sss - service");
        System.out.println("Sss - service");

        RequestDispatcher requestDispatcher = null;

        HostConfiguration hconf = new HostConfiguration();
        hconf.setHost("localhost",80,"http");

        String _click = request.getParameter("click");
        PrintWriter printWriter = response.getWriter();
        printWriter.println("Sss - service<br/>");


        if (_click != null)
        {
            if (_click.equalsIgnoreCase("PostForwardSssGggForm"))
            {
                requestDispatcher = request.getRequestDispatcher("./Ggg?param1="+request.getParameter("formParam"));
                printWriter.println("Sss parameters:<br/>" + request.getParameter("formParam") + "<br/>");

                requestDispatcher.forward(request, response);

            }


            if (_click.equalsIgnoreCase("GetRedirectSssGgg"))
            {
                configServ.getServletContext().log("Sss - GetRedirectSssGgg");
                response.sendRedirect("./Ggg?param1=Task1");
            }

            if (_click.equalsIgnoreCase("PostRedirectSssGgg"))
            {
                configServ.getServletContext().log("Sss - PostRedirectSssGgg");
                response.sendRedirect("./Ggg");
            }

            if (_click.equalsIgnoreCase("PostRedirectSssGggForBody"))
            {
                configServ.getServletContext().log("Sss - PostRedirectSssGgg");
                printWriter.println("Sss parameters:<br/>" + request.getParameter("formParam") + "<br/>");
                response.setStatus(HttpServletResponse.SC_TEMPORARY_REDIRECT);
                response.setHeader("Location","./Ggg");
            }

            if (_click.equalsIgnoreCase("GetRedirectSssHTML"))
            {
                response.sendRedirect("html/redirect.html");
            }

            if (_click.equalsIgnoreCase("GetRedirectSssGggHTML"))
            {
                response.sendRedirect("./Ggg?param1=redirectToHTML");
            }

            if(_click.equalsIgnoreCase("GetForwardSssHTML"))
            {
                requestDispatcher = request.getRequestDispatcher("html/redirect.html");
                requestDispatcher.forward(request, response);
            }
            if(_click.equalsIgnoreCase("PostRedirectSssGggForm"))
            {
                configServ.getServletContext().log("Sss - GetRedirectSssGgg");
                printWriter.println("Sss parameters:<br/>" + request.getParameter("formParam") + "<br/>");
                response.sendRedirect("./Ggg?param1=Task1");
            }

            if(_click.equalsIgnoreCase("PostForwardSssGgg") ||
                    _click.equalsIgnoreCase("GetForwardSssGggHTML") ||
                    _click.equalsIgnoreCase("GetForwardSssGgg"))
            {
                requestDispatcher = request.getRequestDispatcher("./Ggg?param1=123123");
                requestDispatcher.forward(request, response);
            }

            if(_click.equalsIgnoreCase("GetSssGggCLIENT"))
            {
                HttpClient hc = new HttpClient();
                GetMethod gm = new GetMethod("http://localhost:8082" + request.getContextPath() + "/Ggg?click=GetSssGggCLIENT&p1=Dima&p2=Zvorykin");

                hc.setHostConfiguration(hconf);
                hc.executeMethod(gm);
                response.setContentType("text/html");
                PrintWriter pw = response.getWriter();
                pw.println(gm.getResponseBodyAsString());
                pw.flush();
            }

            if(_click.equalsIgnoreCase("PostSssGggCLIENT"))
            {
                HttpClient hc2 = new HttpClient();
                PostMethod pm = new PostMethod("http://localhost:8082" + request.getContextPath() + "/Ggg");
                pm.addParameter("click","PostSssGggCLIENT");
                pm.addParameter("p1","Dima");
                pm.addParameter("p2","Zvorykin");
                hc2.executeMethod(pm);
                response.setContentType("text/html");
                PrintWriter pw = response.getWriter();
                pw.println(pm.getResponseBodyAsString());
                pw.flush();
            }
        }

        if(request.getMethod().equalsIgnoreCase("get"))
        {
            doGet(request,response);
        }
        else
        {
            doPost(request,response);
        }
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html;charset=utf-8");

        System.out.println("Sss - doGet");
        PrintWriter printWriter = response.getWriter();
        printWriter.write("Sss - doGet<br/>");
        configServ.getServletContext().log("Sss - doGet");
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html;charset=utf-8");
        System.out.println("Sss - doPost");

        PrintWriter printWriter = response.getWriter();
        printWriter.write("Sss - doPost<br/>");
        configServ.getServletContext().log("Sss - doPost");
    }
}
