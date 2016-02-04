<cfparam name="form.submitted" default="0" />
<cfparam name="form.userid" default="" />
<h1>Get spcific user</h1>
<form method="post">
	<label><b>Enter specific user id</b></label>
	<input type="text" name="userid" />
	<input type="submit" value="Submit" />
	<input type="hidden" name="submitted" value="1" />
</form>
<cfif form.submitted>
	<cfquery name="specificUser">
		SELECT username FROM user
		WHERE userid = <cfqueryparam value="#form.userid#" cfsqltype="cf_sql_integer" />
	</cfquery>
	<cfoutput>
		<b>Specific user</b>: #specificUser.username#
	</cfoutput>
</cfif>