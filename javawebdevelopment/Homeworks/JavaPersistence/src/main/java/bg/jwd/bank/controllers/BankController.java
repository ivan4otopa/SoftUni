package bg.jwd.bank.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.jwd.bank.services.AccountService;

@Controller
public class BankController {	
	@Autowired
	private AccountService accountService;
	
	@RequestMapping(value = "/bankRegister", method = RequestMethod.GET)
	public String getRegister(Model model) {
		model.addAttribute("accounts", accountService.getAccounts());

		return "bankRegister";
	}
}
