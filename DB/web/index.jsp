<%@ page import="java.sql.ResultSet" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
  <title>Lab 4.2</title>
</head>
<body>
<%
  ResultSet resultSet = (ResultSet)request.getAttribute("resultSet");
  if(resultSet == null)
    request.getRequestDispatcher("/").forward(request, response);
  if(resultSet.isBeforeFirst()) {
    while (resultSet.next()) {
      int id = resultSet.getInt("u_id");
      String login = resultSet.getString("u_login");
      String password = resultSet.getString("u_password");
      String email = resultSet.getString("u_email");
      String name = resultSet.getString("u_name");
      String remember = resultSet.getString("u_remember");

%>
Id <%=id%><br>
Login <%=login%><br>
Password <%=password%><br>
E-mail <%=email%><br>
Name <%=name%><br>
Remember <%=remember%><br>
<br>
<%
    }
  }
  resultSet.close();
%>
</body>
</html>
