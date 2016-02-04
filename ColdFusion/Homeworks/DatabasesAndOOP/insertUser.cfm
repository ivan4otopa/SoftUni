<cfparam name="form.userid" default="" />
<cfparam name="form.username" default="" />
<cfparam name="form.submitted" default="0" />
<form method="post">
	<label for="id"><b>Id</b></label>
	<input type="text" id="id" name="userid" /><br />
	<label for="username"><b>Username</b></label>
	<input type="text" id="username" name="username" /><br />
	<input type="submit" value="Submit" />
	<input type="hidden" name="submitted" value="1" />
</form>
<cfif form.submitted>
	<cfquery>
		INSERT INTO user(userid, username)
		VALUES(<cfqueryparam value="#form.userid#" cfsqltype="cf_sql_integer" />, <cfqueryparam value="#form.username#" cfsqltype="cf_sql_varchar" />)
	</cfquery>
</cfif>