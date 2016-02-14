<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<%@ taglib prefix="ct" uri="http://jwd.bg/tags" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Web Banking Page</title>
</head>
<body>
	<ct:Header title="Web Banking Page" />
	<form action="../WebBankingPage">
		<c:choose>
			<c:when test='${ accountName == null }'>
				Account name <input type="text" name="accountName" /><br />
			</c:when>
			<c:otherwise>
				Account name: <c:out value='${ accountName }' /><br /> 
			</c:otherwise>
		</c:choose>
		<c:choose>
			<c:when test='${ amount == null }'>
				Amount <input type="text" name="amount" /><br />
			</c:when>
			<c:otherwise>
				Current amount: <c:out value='${ amount }' /> <c:out value='${ currency }' /><br /> 
			</c:otherwise>
		</c:choose>		
		Operation <input type="radio" name="operation" value="withdraw" /> Withdraw <input type="radio" name="operation" value="deposit" /> Deposit<br />
		Change amount <input type="text" name="changeAmount" /><br />
		Currency <input type="radio" name="currency" value="leva" /> Leva <input type="radio" name="currency" value="euro"/> Euro <input type="radio" name="currency" value="dollar" /> Dollar<br />
		<input type="submit" name="Submit" />		
	</form>
	<c:if test='${ message != null }'>
		<p>
			<c:out value='${ message }' />
		</p>
	</c:if>
	<ct:Footer title="Web Banking Page" />
</body>
</html>