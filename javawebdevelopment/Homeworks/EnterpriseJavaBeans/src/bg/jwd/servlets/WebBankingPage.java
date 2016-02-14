package bg.jwd.servlets;

import java.io.IOException;

import javax.ejb.EJB;
import javax.servlet.RequestDispatcher;
import javax.servlet.ServletContext;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.omg.CORBA.PRIVATE_MEMBER;

import bg.jwd.ejbs.Banking;

/**
 * Servlet implementation class WebBankingPage
 */
@WebServlet("/WebBankingPage")
public class WebBankingPage extends HttpServlet {
	private static final long serialVersionUID = 1L;
	private static final String DEFAULT_NAME = "Dummy";
	private static final double DEFAULT_AMOUNT = 500;
	private static final String DEFAULT_CURRENCY = "leva";
	
	@EJB
	private Banking banking;
	
    /**
     * @see HttpServlet#HttpServlet()
     */
    public WebBankingPage() {
        super();
        // TODO Auto-generated constructor stub
    }

	/**
	 * @see HttpServlet#doGet(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub			
		String accountName = request.getParameter("accountName");		
		String currency = request.getParameter("currency");
		
		if (accountName != null && !accountName.equals("")) {					
			double amount = Double.parseDouble(request.getParameter("amount"));
			
			banking.setAccount(accountName, amount, currency);
			
			request.getSession().setAttribute("accountName", banking.getAccountName());
			request.getSession().setAttribute("amount", banking.getAmount());
			request.getSession().setAttribute("currency", banking.getCurrency());
			response.sendRedirect("pages/WebBankingPage.jsp");
		} else {
			String operation = request.getParameter("operation");
			
			double changeAmount = Double.parseDouble(request.getParameter("changeAmount"));
			
			if (changeAmount <= 0) {
				request.getSession().setAttribute("message", "Change amount can't be less than or equal to 0");				
				response.sendRedirect("pages/WebBankingPage.jsp");
			} else {			
				if (operation.equals("withdraw")) {
					if (changeAmount > banking.getAmount()) {
						request.getSession().setAttribute("message", "Withdraw amount can't be more than the current amount");				
						response.sendRedirect("pages/WebBankingPage.jsp");
					} else if (changeAmount > 0.5 * banking.getAmount()) {
						request.getSession().setAttribute("message", "Withdraw amount can't be more 50 percent of the current amount");				
						response.sendRedirect("pages/WebBankingPage.jsp");
					} else {
						banking.withdraw(changeAmount, currency);				
						
						request.getSession().setAttribute("message", null);
						request.getSession().setAttribute("amount", banking.getAmount());
						request.getSession().setAttribute("currency", banking.getCurrency());
						response.sendRedirect("pages/WebBankingPage.jsp");
					}							
				} else {
					if (banking.getAccountName() == null) {
						banking.setAccount(DEFAULT_NAME, DEFAULT_AMOUNT, DEFAULT_CURRENCY);
					}
									
					banking.deposit(changeAmount, currency);
					
					request.getSession().setAttribute("message", null);
					request.getSession().setAttribute("accountName", banking.getAccountName());
					request.getSession().setAttribute("currency", banking.getCurrency());
					request.getSession().setAttribute("amount", banking.getAmount());
					response.sendRedirect("pages/WebBankingPage.jsp");
				}
			}
		}
	}

	/**
	 * @see HttpServlet#doPost(HttpServletRequest request, HttpServletResponse response)
	 */
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		// TODO Auto-generated method stub
		doGet(request, response);
	}

}
