package com.bstu.lab8;

import org.apache.commons.httpclient.Header;
import org.apache.commons.httpclient.HttpClient;
import org.apache.commons.httpclient.methods.PostMethod;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.annotation.*;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet(name = "Aaa", value = "/Aaa")
public class Aaa extends HttpServlet {
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
    {
        HttpClient client = new HttpClient();
        String uri = "http://localhost:8082/"+request.getContextPath() + "/Bbb";
        PostMethod postMethod = new PostMethod(uri);

        postMethod.addRequestHeader("X-Aaa1", "1");
        postMethod.addRequestHeader("X-Aaa2", "2");
        postMethod.addRequestHeader("X-Aaa3", "3");
        postMethod.addParameter("X-Aaa1", "1");
        postMethod.addParameter("X-Aaa2", "2");
        postMethod.addParameter("X-Aaa3", "3");

        client.executeMethod(postMethod);

        PrintWriter printWriter = response.getWriter();
        response.setContentType("text/html");
        printWriter.println(postMethod.getResponseBodyAsString());
        printWriter.println("<h1>All Headers:</h1>");

        Header[] headers = postMethod.getResponseHeaders();
        printWriter.println("<table><thead><tr><th>Header</th><th>Value</th></thead><tbody>");


        for (Header header : headers)
        {
            printWriter.println("<tr><td>" + header.getName() + "</td><td>" + header.getValue() + "</td></tr>");
        }

        printWriter.println("</tbody></table>");

    }
}
