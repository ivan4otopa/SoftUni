<%@tag import="java.util.Date"%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ attribute name="hasDate" %>

<head>
	<title>Title</title>
</head>
<body>
	<h1>Content</h1>
	<c:choose>
		<c:when test='${ hasDate }'><%= new Date() %></c:when>
		<c:otherwise>No date</c:otherwise>
	</c:choose>
	<jsp:doBody />
	<footer>Version: 0.01</footer>
</body>