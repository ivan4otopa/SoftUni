package bg.softuni.javawebdevelopementhomework;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

/**
 * Servlet implementation class Form
 */
@WebServlet("/Form")
public class Form extends HttpServlet {
	private static final long serialVersionUID = 1L;
       
    /**
     * @see HttpServlet#HttpServlet()
     */
    public Form() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		response.setContentType("text/html");
		response.getWriter().append("<form>");
		response.getWriter().append("<input type=\"number\" style=\"margin-bottom: 20px; padding-left: 5px;\" placeholder=\"ID...\" /><br />");
		response.getWriter().append("<input type=\"text\" style=\"margin-bottom: 20px; padding-left: 5px;\" placeholder=\"Topic...\" /><br />");
		response.getWriter().append("<input type=\"date\" style=\"margin-bottom: 20px;\" /><br />");
		response.getWriter().append("<input type=\"submit\" value=\"Submit\" style=\"margin-right: 20px;\"/>");
		response.getWriter().append("<button>Cancel</button>");
		response.getWriter().append("</form>");
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
