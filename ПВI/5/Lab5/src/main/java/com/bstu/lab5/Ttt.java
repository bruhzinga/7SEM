package com.bstu.lab5;

import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Ttt", value = "/Ttt")
public class Ttt extends HttpServlet
{
    public Ttt()
    {
        super();
    }

    @Override
    public void init(ServletConfig config) throws ServletException
    {
        super.init();
    }

    @Override
    public void destroy()
    {
        super.destroy();
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        PrintWriter printWriter = response.getWriter();
        response.setContentType("text/html");
        String result = String.format("<p> Surname: %s <br/> Lastname: %s <br/> Sex: %s",
                request.getParameter("surname"),request.getParameter("lastname"),request.getParameter("sex"));
        printWriter.println(result);
    }
}