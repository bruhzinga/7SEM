<%--ДИРЕКТИВА--%>
<%@ page import="java.util.Calendar" %>
<%@ page import="java.text.SimpleDateFormat" %>
<%@ page import="java.util.Date" %>
<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <style>
        table,th,td
        {
            border: 2px solid black;
            border-collapse: collapse;
            text-align: center;
        }
    </style>
    <title>Lab4</title>
<%--    СКРИПЛЕТ--%>
    <%
        Calendar calendar =  Calendar.getInstance();
        Date date = calendar.getTime();
        SimpleDateFormat formatter = new SimpleDateFormat("dd-MM-yyyy");
        Integer n = calendar.get(Calendar.HOUR_OF_DAY);

        %>
<%--  ОБЬЯВЛЕНИЕ  --%>
    <%!
        String pageToGo = null;

        protected String Period(Integer h)
        {
            if ((h > 0) && (h <= 5))
            {
                return  "night";
            }
            else if ((h > 5) && (h <= 12))
            {
                return "morning";
            }
            else if ((h > 12) && (h <= 17))
            {
                return "afternoon";
            }
            else
            {
                return "evening";
            }
        }
        protected String Say(Integer h)
        {
            return "Good " + Period(h);
        }
    %>
</head>
<p><%=date%></p>
<body>

<h1>Task 1. Вывести строку в зависимости от времени суток:</h1>
<%--ВЫРАЖЕНИЕ--%>
<p><%=Say(n)%></p>


<hr>

<h1>Task 2. Вывести таблицу с датами и порядковым номером дня:</h1>
<div>
    <table>
    <thead>
        <tr>
            <td>Дата</td>
            <td>Номер дня в неделе</td>
        </tr>
    </thead>
    <% for(int i = 0; i < 6;i++)
        {%>
        <tr>
            <td><%= formatter.format(date)%></td>
                <% calendar.setTime(date); int day = calendar.get(Calendar.DAY_OF_WEEK);  %>
            <td><%= day == 1 ? 7 : day - 1%></td>
        </tr>
     <%calendar.add(Calendar.DATE,1); date = calendar.getTime();
        }%>
    </table>
</div>

<hr>


<h1>Task 5. Перейти на страницу в зависимости от времени суток:</h1>
<div>
   <input type="button" value="Press" onclick="getPage()"/>
    <p id="day"></p>
</div>

<hr>

<h1>Task 6. JSP:INCLUDE :</h1>
<p>
    <%
        String pagePath = "jsp/" + Period(n) + ".jsp";
    %>
    <jsp:include page="<%=pagePath%>"/>
</p>

<hr>

<h1>Task 7. Сервлет afternoon:</h1>
<div>
    <a href="${pageContext.request.contextPath}/Afternoon">Afternoon servlet</a>
</div>

<hr>

<h1>Task 8. Сервлет afternoon (forward):</h1>
<div>
    <hr>
    <%--<jsp:forward page="jsp/afternoon.jsp"/>--%>
    <hr>
</div>

<hr>

<h1>Task 11 - 13. Jjj сервлет: </h1>
<a href="./Jjj?parm=hc">GET (Jjj) (HTTPClient) </a> <br/>

<a href="./Jjj?parm=forw">GET (Jjj) (forward) </a> <br/>
<form action="Jjj" method="POST">
    <input type="submit" name="press" value="POST (Jjj)">
</form>

<script>
    const getPage = () =>
    {
        <%switch (Period(n))
        {
            case "morning": %>document.getElementById('day').innerHTML = `<%@ include file="jsp/morning.jsp"%>`<% break;
            case "night": %>document.getElementById('day').innerHTML = `<%@ include file="jsp/night.jsp"%>`<%break;
            case "evening": %>document.getElementById('day').innerHTML = `<%@ include file="jsp/evening.jsp"%>`<%break;
            case "afternoon": %>document.getElementById('day').innerHTML = `<%@ include file="jsp/afternoon.jsp"%>`<%break;
        }%>
    }

</script>
<br/>
</body>
</html>