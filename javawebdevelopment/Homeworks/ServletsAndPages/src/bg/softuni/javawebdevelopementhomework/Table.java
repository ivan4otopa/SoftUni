package bg.softuni.javawebdevelopementhomework;

import java.io.IOException;
import java.util.Date;
import java.text.*;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.sun.org.apache.xerces.internal.impl.xpath.regex.ParseException;

/**
 * Servlet implementation class Table
 */
@WebServlet("/Table")
public class Table extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Table() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub			
		response.getWriter().append("<table border=\"1\">");
		response.getWriter().append("<thead>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<th>Topic</th>");
		response.getWriter().append("<th>Date</th>");
		response.getWriter().append("</tr>");
		response.getWriter().append("</thead>");
		response.getWriter().append("<tbody>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Web Developement Basics</td>");
		response.getWriter().append("<td>").append(getDate("14/01/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Servlets and Pages</td>");
		response.getWriter().append("<td>").append(getDate("21/01/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Containers, Filters and Sessions</td>");
		response.getWriter().append("<td>").append(getDate("28/01/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Java Beans</td>");
		response.getWriter().append("<td>").append(getDate("04/02/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Spring Core</td>");
		response.getWriter().append("<td>").append(getDate("11/02/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Spring MVC</td>");
		response.getWriter().append("<td>").append(getDate("18/02/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Spring Security</td>");
		response.getWriter().append("<td>").append(getDate("25/02/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Oracle Database</td>");
		response.getWriter().append("<td>").append(getDate("10/03/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Java Persistence</td>");
		response.getWriter().append("<td>").append(getDate("17/03/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Final Test</td>");
		response.getWriter().append("<td>").append(getDate("24/03/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Workshop - Building Web Application from Scratch</td>");
		response.getWriter().append("<td>").append(getDate("31/03/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("<tr>");
		response.getWriter().append("<td>Project Presentations</td>");
		response.getWriter().append("<td>").append(getDate("10/04/2016")).append("</td>");
		response.getWriter().append("</tr>");
		response.getWriter().append("</tbody>");
		response.getWriter().append("</table>");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}
	
	String getDate(String dateString) {
		SimpleDateFormat dateFormat = new SimpleDateFormat("dd/MM/yyyy");		
		Date date = new Date();
		
		try {
			date = dateFormat.parse(dateString);
		} catch (java.text.ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
		return new SimpleDateFormat("d MMMM y").format(date);
	}

}
