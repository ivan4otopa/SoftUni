package bg.jwd.bank.controllers;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.jwd.bank.dtos.Operation;
import bg.jwd.bank.services.OperationService;

@Controller
public class OperationController {
	@Autowired
	private OperationService operationService;
	
	@RequestMapping(value = "/operation", method = RequestMethod.GET)
	public String getOperationPage() {
		return "operation";
	}
	
	@RequestMapping(value = "/doOperation", method = RequestMethod.POST)
	public String doOperation(@ModelAttribute("operation") Operation operation) {
		if (operation.getOperation().equals("deposit")) {
			operationService.deposit(operation.getAccountNumber(), operation.getAmount(), operation.getCurrency());
		} else {
			operationService.withdraw(operation.getAccountNumber(), operation.getAmount(), operation.getCurrency());
		}
		
		return "redirect:/bankRegister";
	}
}
