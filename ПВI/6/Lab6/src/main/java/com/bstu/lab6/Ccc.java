package com.bstu.lab6;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.Objects;

@WebServlet(name = "Ccc", value = "/Ccc")
public class Ccc extends HttpServlet
{
    @Override
    public void init() throws ServletException
    {
        super.init();
        getServletContext().setAttribute("attrCBean", new CBean());
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        RequestDispatcher requestDispatcher = request.getRequestDispatcher("/jsp/ccc.jsp");
        requestDispatcher.forward(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        getResult(request, response);
    }

    private void getResult(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        String value1 = request.getParameter("value1");
        String value2 = request.getParameter("value2");
        String value3 = request.getParameter("value3");
        String cbean = request.getParameter("cbean");

        if (cbean != null && cbean.equals("new"))
        {
            System.out.println("New CBean");
            getServletContext().setAttribute("attrCBean", new CBean());
        }
        else System.out.println("Old CBean");

        setValues(value1, value2, value3);

        RequestDispatcher requestDispatcher = request.getRequestDispatcher("/jsp/ccc.jsp");
        requestDispatcher.forward(request, response);
    }

    private void setValues(String value1, String value2, String value3)
    {
        CBean ob = (CBean) getServletContext().getAttribute("attrCBean");

        if (!Objects.equals(value1, ""))
        {
            ob.setValue1(value1);
        }

        if (!Objects.equals(value2, ""))
        {
            ob.setValue2(value2);
        }

        if (!Objects.equals(value3, ""))
        {
            ob.setValue3(value3);
        }
    }
}
