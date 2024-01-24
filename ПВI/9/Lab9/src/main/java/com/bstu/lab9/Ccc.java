package com.bstu.lab9;

import com.bstu.lab9.CBean;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
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
        getResult(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        getResult(request, response);
    }

    private void getResult(HttpServletRequest req, HttpServletResponse resp) throws ServletException, IOException
    {
        HttpSession session = req.getSession();
        String sessionId = session.getId();

        CBean cbeanSession = (CBean) session.getAttribute(sessionId);

        CBean objForSession = new CBean();
        CBean objForRequest = new CBean();

        String value1 = req.getParameter("value1");
        System.out.println(value1);

        String value2 = req.getParameter("value2");
        System.out.println(value2);

        String value3 = req.getParameter("value3");
        System.out.println(value3);

        String cbean = req.getParameter("cbean");

        if (cbeanSession != null)
        {
            objForSession = cbeanSession;
        }
        else
        {
            session.setAttribute(sessionId, objForSession);
            session.setMaxInactiveInterval(100);
        }

        if (cbean != null && cbean.equals("new")) 
        {
            req.setAttribute("attrCBean", new CBean());
            session.removeAttribute(sessionId);
            session.setAttribute(sessionId, new CBean());
        }

        setValues(objForSession, objForRequest, value1, value2, value3);

        session.setAttribute(sessionId, objForSession);
        req.setAttribute("attrCBean", objForRequest);

        RequestDispatcher requestDispatcher = req.getRequestDispatcher("/jsp/ccc.jsp");
        requestDispatcher.forward(req, resp);
    }

    private void setValues(CBean objForSession, CBean objForRequest, String value1, String value2, String value3) {
        
        if (!Objects.equals(value1, "")) 
        {
            objForSession.setValue1(value1);
            objForRequest.setValue1(value1);
        }

        if (!Objects.equals(value2, "")) 
        {
            objForSession.setValue2(value2);
            objForRequest.setValue2(value2);
        }

        if (!Objects.equals(value3, "")) 
        {
            objForSession.setValue3(value3);
            objForRequest.setValue3(value3);
        }
    }
}
