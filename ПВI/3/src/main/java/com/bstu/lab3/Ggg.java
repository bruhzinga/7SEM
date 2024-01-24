package com.bstu.lab3;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.stream.Collectors;
import javax.servlet.*;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.*;

@WebServlet(name = "Ggg", value = "/Ggg")
public class Ggg extends HttpServlet {
    private ServletConfig configServ;
    public Ggg()
    {
        super();
        System.out.println("Ggg - сonstructor");
    }

    @Override
    public void init(ServletConfig config) throws ServletException
    {
        super.init(config);
        this.configServ=config;
        configServ.getServletContext().log("Ggg - init");
    }

    @Override
    public void destroy()
    {
        super.destroy();
        configServ.getServletContext().log("Ggg - destroy");
    }

    @Override
    protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        //super.service(request, response);
        response.setContentType("text/html;charset=utf-8");
        configServ.getServletContext().log("Ggg - service");
        System.out.println("Ggg - service");

        PrintWriter printWriter = response.getWriter();

        String param1 = request.getParameter("param1");
        String _click = request.getParameter("click");

        RequestDispatcher requestDispatcher = null;
        printWriter.println("Ggg - service<br/>");

        if(param1 != null)
        {
            if(param1.equalsIgnoreCase("redirectToHTML"))
            {
                response.sendRedirect("html/redirect.html");
            }
        }

        if(_click != null)
        {
            if(_click.equalsIgnoreCase("GetForwardSssGggHTML"))
            {
                requestDispatcher = request.getRequestDispatcher("html/redirect.html");
                requestDispatcher.forward(request, response);
            }


            if (_click.equalsIgnoreCase("PostForwardSssGggForm")
                    ||_click.equalsIgnoreCase("PostRedirectSssGggForm")
                    || _click.equalsIgnoreCase("PostRedirectSssGggForBody"))
            {
                printWriter.println("Ggg parameters:<br/>" + request.getParameter("formParam") + "<br/>");
            }
            if(_click.equalsIgnoreCase("GetSssGggCLIENT"))
            {
                printWriter.println("After Ggg:" + request.getParameter("p1") + " " + request.getParameter("p2") + "<br/>");
            }

            if(_click.equalsIgnoreCase("PostSssGggCLIENT"))
            {
                printWriter.println("After Ggg:" + request.getParameter("p1") + " " + request.getParameter("p2") + "<br/>");
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
        response.addHeader("Access-Control-Allow-Origin", "*");
        PrintWriter printWriter = response.getWriter();
        printWriter.write("Ggg - doGet<br/>");
        System.out.println("Ggg - doGet");

        configServ.getServletContext().log("Ggg - doGet");


        String param1 = request.getParameter("param1");
        if(param1 != null)
        {
            printWriter.println("Param value = " + param1);
        }


    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        response.setContentType("text/html;charset=utf-8");

        PrintWriter printWriter = response.getWriter();
        printWriter.write("Ggg - doPost<br/>");
        System.out.println("Ggg - doPost");
        configServ.getServletContext().log("Ggg - doPost");
        String param1 = request.getParameter("param1");
        if(param1 != null)
        {
            printWriter.println("Param value = " + param1);
        }
    }
}
