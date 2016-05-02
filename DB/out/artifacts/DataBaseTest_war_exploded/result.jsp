<%@ page import="java.sql.ResultSet" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
  <title>Lab 4.2</title>
</head>
<body>
<%
  ResultSet rs = (ResultSet)request.getAttribute("resultSet");
  if(rs == null)
    request.getRequestDispatcher("/").forward(request, response);
  if(rs.isBeforeFirst()) {

    while (rs.next()) {

      int id = rs.getInt("u_id");
      String login = rs.getString("u_login");
      String password = rs.getString("u_password");
      String email = rs.getString("u_email");
      String name = rs.getString("u_name");
      String remember = rs.getString("u_remember");

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
  rs.close();
%>
</body>
</html>
