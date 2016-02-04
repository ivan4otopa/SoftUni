<cfparam name="form.userid" default="" />
<cfparam name="form.username" default="" />
<cfparam name="form.submitted" default="0" />
<form method="post">
	<label for="userid"><b>Enter user to edit id</b></label>
	<input type="text" id="userid" name="userid" /><br />
	<label for="username"><b>New username</b></label>
	<input type="text" id="username" name="username" /><br />
	<input type="submit" value="Submit" />
	<input type="hidden" name="submitted" value="1" />
</form>
<cfif form.submitted>
	<cfset user = EntityLoad('user', form.userid, true) />
	<cfset user.setUsername(form.username) />
	<cfset entitysave(user) />
</cfif>