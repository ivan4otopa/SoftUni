<cfquery name="allUsers">
	SELECT * FROM user
</cfquery>
<cfoutput query="allUsers">
	<p>#allUsers.userid#. #allUsers.username#</p>
</cfoutput>