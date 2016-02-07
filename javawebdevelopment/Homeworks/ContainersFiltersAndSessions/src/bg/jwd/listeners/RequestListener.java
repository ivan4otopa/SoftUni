package bg.jwd.listeners;

import java.util.Date;

import javax.servlet.ServletRequestEvent;
import javax.servlet.ServletRequestListener;
import javax.servlet.annotation.WebListener;
import javax.servlet.http.HttpServletRequest;

@WebListener
public class RequestListener implements ServletRequestListener {

	@Override
	public void requestDestroyed(ServletRequestEvent arg0) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void requestInitialized(ServletRequestEvent event) {
		HttpServletRequest request = (HttpServletRequest) event.getServletRequest();
		System.out.printf(
				"%s\n%s\n%s\n%s\n",
				event.getServletRequest().getRemoteAddr(),
				request.getSession().getId(),
				request.getAuthType(),
				new Date().toString());
	}

}
