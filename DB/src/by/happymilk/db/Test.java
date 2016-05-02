package by.happymilk.db;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.sql.*;

@WebServlet(urlPatterns = "/")

public class Test extends HttpServlet {

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        try {
            Class.forName("com.mysql.jdbc.Driver");

            Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/auth", "root", "");

            Statement statement = connection.createStatement();

            request.setAttribute("resultSet", statement.executeQuery("SELECT * FROM `users`"));
            request.getRequestDispatcher("index.jsp").forward(request, response);

            statement.close();
            connection.close();
        } catch(Exception e) {
            e.printStackTrace();
        }
    }
}
