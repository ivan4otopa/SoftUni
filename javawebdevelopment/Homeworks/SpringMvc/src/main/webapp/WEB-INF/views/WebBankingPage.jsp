<%@ taglib prefix="form" uri="http://www.springframework.org/tags/form" %>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

<html>
<head>
	<title>Web Banking Page</title>
</head>
<body>
	<header>Web Banking Page</header>
		<form:form method="POST" action="ProcessInput">			
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
			Operation <input type="radio" name="operation" value="withdraw" /> Withdraw <input type="radio" name="operation" value="deposit"> Deposit<br />
			Change amount <input type="text" name="changeAmount" /><br />
			Currency <input type="radio" name="currency" value="leva" /> leva <input type="radio" name="currency" value="euro" /> euro <input type="radio" name="currency" value="dollar" /> dollars<br />
			<input type="submit" value="Submit" />
		</form:form>
		<c:if test='${ message != null }'>
			<c:out value='${ message }' />
		</c:if>
	<footer>Web Banking Page - 0.01</footer>
</body>
</html>