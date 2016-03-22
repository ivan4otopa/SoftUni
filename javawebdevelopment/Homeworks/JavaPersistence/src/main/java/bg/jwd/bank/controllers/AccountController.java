package bg.jwd.bank.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.jwd.bank.entities.Account;
import bg.jwd.bank.services.AccountService;

@Controller
public class AccountController {
	@Autowired
	private AccountService accountService;
		
	@RequestMapping(value = "/newAccount", method = RequestMethod.GET)
	public String getNewAccount() {
		return "newAccount";
	}
	
	@RequestMapping(value = "/addAccount", method = RequestMethod.POST)
	public String addAccount(@ModelAttribute("account") Account account) {
		accountService.addAccount(account);
		
		return "redirect:/bankRegister";
	}
}
