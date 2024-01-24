package com.bstu.lab4;

import org.apache.commons.httpclient.HostConfiguration;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.methods.GetMethod;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Calendar;

@WebServlet(name = "Jjj", value = "/Jjj")
public class Jjj extends HttpServlet 
{
    private Calendar calendar = Calendar.getInstance();
    private int hour = calendar.get(Calendar.HOUR_OF_DAY);

    @Override
    public void init() throws ServletException 
    {
        super.init();
        System.out.println("Jjj:init");
    }

    @Override
    public void destroy() 
    {
        super.destroy();
        System.out.println("Jjj:destroy");
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        System.out.println("Jjj:doGet");
        RequestDispatcher requestDispatcher = null;

        String param = request.getParameter("parm");
        HostConfiguration hconf = new HostConfiguration();
        hconf.setHost("localhost",80,"http");
        if(param.equalsIgnoreCase("forw"))
        {
            if (hour > 0 && hour <= 5)
            {
                requestDispatcher=request.getRequestDispatcher("./jsp/night.jsp");
                requestDispatcher.forward(request,response);
            }
            else if (hour > 5 && hour < 12)
            {
                requestDispatcher=request.getRequestDispatcher("jsp/morning.jsp");
                requestDispatcher.forward(request,response);
            }
            else if (hour >= 12 && hour <= 15)
            {
                requestDispatcher=request.getRequestDispatcher("jsp/afternoon.jsp");
                requestDispatcher.forward(request,response);
            }
            else
            {
                requestDispatcher=request.getRequestDispatcher("./jsp/evening.jsp");
                requestDispatcher.forward(request,response);
            }
        }
        else
        {
            HttpClient hc = new HttpClient();
            GetMethod gm = new GetMethod("http://localhost:8080" + request.getContextPath() + "/Jjj?parm=forw");

            hc.setHostConfiguration(hconf);
            hc.executeMethod(gm);
            response.setContentType("text/html");
            PrintWriter pw = response.getWriter();
            pw.println(gm.getResponseBodyAsString());
            pw.flush();
        }
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        System.out.println("Jjj:doPost");
        RequestDispatcher requestDispatcher = null;

        if (hour > 0 && hour <= 5)
        {
            requestDispatcher=request.getRequestDispatcher("./jsp/night.jsp");
            requestDispatcher.forward(request,response);
        }
        else if (hour > 5 && hour < 12)
        {
            requestDispatcher=request.getRequestDispatcher("jsp/morning.jsp");
            requestDispatcher.forward(request,response);
        }
        else if (hour >= 12 && hour <= 15)
        {
            requestDispatcher=request.getRequestDispatcher("jsp/afternoon.jsp");
            requestDispatcher.forward(request,response);
        }
        else
        {
            requestDispatcher=request.getRequestDispatcher("./jsp/evening.jsp");
            requestDispatcher.forward(request,response);
        }
    }

    @Override
    protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        System.out.println(request.getMethod());

        if(request.getMethod().contains("POST"))
        {
            this.doPost(request, response);
        }
        else if(request.getMethod().contains("GET"))
        {
            this.doGet(request, response);
        }
    }
}
// <!--<jsp:forward page="<%=pagePath%>"></jsp:forward>-->
