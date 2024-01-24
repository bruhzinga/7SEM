package com.bstu.lab4;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Afternoon", value = "/Afternoon")
public class Afternoon extends HttpServlet {


    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        //super.service(request, response);

        PrintWriter printWriter = response.getWriter();
        response.setContentType("text/html");
        printWriter.println("Servlet. Good afternoon");
    }

}
