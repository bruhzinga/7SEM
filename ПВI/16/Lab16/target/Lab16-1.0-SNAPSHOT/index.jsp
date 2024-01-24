<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Lab16</title>
    <script type="text/javascript">
        let ws = null;

        function connect()
        {
            ws = new WebSocket("ws://localhost:8082${pageContext.request.contextPath}/websockets");

            ws.onmessage = function (event)
            {
                document.getElementById('Result').innerHTML = event.data;
            };
        }

        function disconnect()
        {
            ws.close();
        }
    </script>
</head>
<body>

<button onclick="connect()">START</button>
<button onclick="disconnect();">STOP</button>

<div id="Result"></div>
</body>
</html>