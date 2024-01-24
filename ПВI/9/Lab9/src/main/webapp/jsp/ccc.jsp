<%--
  Created by IntelliJ IDEA.
  User: ON
  Date: 18.09.2022
  Time: 21:07
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import="javax.servlet.ServletContext" %>
<%@ page import="com.bstu.lab9.CBean" %>
<html>
<head>
    <title>
        Cbean page
    </title>
</head>
<body>
<h3>CBean: </h3>
<%
    CBean objFromReq = (CBean) request.getAttribute("attrCBean");
    CBean objFromSess = (CBean) request.getSession().getAttribute(request.getSession().getId());
%>
<h2>Values from attribute of request</h2>
<div>
    <label><%=objFromReq != null ? objFromReq.getValue1() : "missing" %></label>
    <label><%=objFromReq != null ? objFromReq.getValue2() : "missing" %></label>
    <label><%=objFromReq != null ? objFromReq.getValue3() : "missing" %></label>
</div>


<h2>Values from attribute of session</h2>

<div>
    <label><%=objFromSess != null ? objFromSess.getValue1() : "missing" %></label>
    <label><%=objFromSess != null ? objFromSess.getValue2() : "missing" %></label>
    <label><%=objFromSess != null ? objFromSess.getValue3() : "missing" %></label>
</div>
</body>
</html>
