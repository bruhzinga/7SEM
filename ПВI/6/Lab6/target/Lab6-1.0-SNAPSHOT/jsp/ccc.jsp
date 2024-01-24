<%--
  Created by IntelliJ IDEA.
  User: ON
  Date: 18.09.2022
  Time: 21:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import="javax.servlet.ServletContext" %>
<%@ page import="com.bstu.lab6.CBean" %>
<html>
<head>
    <title>
        Cbean page
    </title>
</head>
<body>
<%
    CBean ob = (CBean) pageContext.getServletContext().getAttribute("attrCBean");
%>
<h3>Value1: </h3><%=ob.getValue1()%>
<h3>Value2: </h3><%=ob.getValue2()%>
<h3>Value3: </h3><%=ob.getValue3()%>
</body>
</html>