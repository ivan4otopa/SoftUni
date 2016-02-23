package bg.jwd.springmvc.controllers;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.jwd.springmvc.services.AccountService;

@Controller
public class AccountController {
	private static final String DEFAULT_NAME = "Dummy";
	private static final double DEFAULT_AMOUNT = 500;
	
	@Autowired
	private AccountService accountService;
	
	@RequestMapping(value = "/WebBankingPage", method = RequestMethod.GET)
	public String getPage() {
		return "WebBankingPage";
	}
	
	@RequestMapping(value = "/ProcessInput", method = RequestMethod.POST)
	public String processInput(Model model, HttpServletRequest request) {
		String accountName = request.getParameter("accountName");
		String currency = request.getParameter("currency");
		
		if (accountName != null && !accountName.equals("")) {
			double amount = Double.parseDouble(request.getParameter("amount"));
			
			accountService.createAccount(accountName, amount, currency);
			
			setModelAttributes(model);
		} else {
			String opration = request.getParameter("operation");
			
			double changeAmount = Double.parseDouble(request.getParameter("changeAmount"));
			
			if (changeAmount <= 0) {
				model.addAttribute("message", "You can't operate with amounts less than or equal to 0");
				setModelAttributes(model);
				
				return "WebBankingPage";
			}
			
			if (opration.equals("withdraw")) {				
				if (changeAmount > accountService.getAccount().getAmount()) {
					model.addAttribute("message", "Withdraw amount can't be more than the current amount");
					setModelAttributes(model);
					
					return "WebBankingPage";
				} else if (changeAmount > 0.5 * accountService.getAccount().getAmount()) {
					model.addAttribute("message", "Withdraw amount can't be more than 50 percent of the current amount");
					
					setModelAttributes(model);
					
					return "WebBankingPage";
				} else {
					accountService.withdraw(changeAmount, currency);
					
					setModelAttributes(model);
				}
			} else {
				if (!accountService.exists()) {
					accountService.createAccount(DEFAULT_NAME, DEFAULT_AMOUNT, currency);
				}

				accountService.deposit(changeAmount, currency);
				
				setModelAttributes(model);
			}
		}
		
		return "WebBankingPage";
	}
	
	private void setModelAttributes(Model model) {
		model.addAttribute("accountName", accountService.getAccount().getName());
		model.addAttribute("amount", accountService.getAccount().getAmount());
		model.addAttribute("currency", accountService.getAccount().getCurrency());
	}
}
