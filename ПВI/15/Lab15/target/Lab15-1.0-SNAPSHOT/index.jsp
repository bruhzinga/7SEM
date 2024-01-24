<%@ page import="com.bstu.lab15.EmailAdmin" %>
<%@ page import="javax.mail.MessagingException" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<!DOCTYPE html>
<html>
<head>
    <title>Lab 15</title>
</head>
<body>
<%= EmailAdmin.showMessages(application.getInitParameter("UserEmail"),
                        application.getInitParameter("UserPassword"))
%>
<a href="./jsp/messageForm.jsp">Message</a></body>
</html>