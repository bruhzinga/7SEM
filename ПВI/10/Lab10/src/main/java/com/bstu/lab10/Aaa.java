package com.bstu.lab10;

import javax.servlet.Servlet;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;

public class Aaa extends HttpServlet implements Servlet
{
      @Override
      protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
      {
            int param1 = Integer.parseInt(request.getParameter("param1"));
            int param2 = Integer.parseInt(request.getParameter("param2"));

            String Url = "jdbc:sqlserver://localhost:1433;databaseName=WebService;Trusted_Connection=No;user=sa;password=Secret123456";
            try
            {
                Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
                response.setContentType("text/html;charset=utf-8");

                System.out.println("Trying to connect");
                Connection connection = DriverManager.getConnection(Url);
                System.out.println("Connection Established Successfull");

                PreparedStatement pstmt = connection.prepareStatement("SELECT * FROM Students where id > ? and id < ?");
                pstmt.setInt(1, param1 );
                pstmt.setInt(2, param2);
                ResultSet rs = pstmt.executeQuery();

                PrintWriter printWriter = response.getWriter();
                printWriter.println("<h1>Result set:</h1><table><thead><tr><th>Id</th><th>Name</th><th>Phone</th></thead><tbody>");
                while (rs.next())
                {
                    printWriter.println(
                    "<tr><td>" +
                    rs.getString("Id") +
                    "</td><td>" +
                    rs.getString("Name") +
                    "</td><td>" +
                    rs.getString("Phone") +"</td></tr>"
                  );
                }
                printWriter.println("</tbody></table>");


            }
            catch (Exception e)
            {
                System.out.println("Unable connect DB");
                e.printStackTrace();
            }
      }
}
