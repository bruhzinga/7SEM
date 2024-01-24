package com.bstu.lab10;

import javax.servlet.Servlet;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.io.PrintWriter;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Types;

public class Bbb extends HttpServlet implements Servlet {
      @Override
      protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
      {

            String param1 = request.getParameter("param1");

            String Url = "jdbc:sqlserver://localhost:1433;databaseName=WebService;Trusted_Connection=No;user=sa;password=Secret123456";
            try
            {
                Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");

                response.setContentType("text/html;charset=utf-8");
                System.out.println("Trying to connect");
                Connection connection = DriverManager.getConnection(Url);
                System.out.println("Connection Established Successfull");


                CallableStatement cstmt = connection.prepareCall("{call GetStudentsNumberByName(?,?)}");
                cstmt.setString(1, param1);
                cstmt.registerOutParameter(2, Types.INTEGER);
                PrintWriter printWriter = response.getWriter();
                cstmt.execute();
                printWriter.println("Count of searched students: " + cstmt.getInt(2));

            }
            catch (Exception e)
            {
                System.out.println("Unable to make connection with DB");
                e.printStackTrace();
            }
      }
}
