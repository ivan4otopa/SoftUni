<cfparam name="form.gender" default="" />
<cfparam name="form.firstName" default="" />
<cfparam name="form.lastName" default="" />
<cfparam name="form.email" default="" />
<cfparam name="form.birthDate" default="" />
<cfparam name="form.description" default="" />
<cfparam name="form.languages" default="" />
<cfparam name="form.technologies" default="" />
<cfparam name="form.submitted" default="0">

<cfoutput>
	<form method="post">
		<label for="gender"><b>Gender</b></label><br />
		<cfif form.gender eq "Male">
			<input type="radio" id="gender" name="gender" value="Male" checked />Male
			<input type="radio" id="gender" name="gender" value="female" />Female<br />
		<cfelseif form.gender eq "Female">
			<input type="radio" id="gender" name="gender" value="Male" />Male
			<input type="radio" id="gender" name="gender" value="Female" checked />Female<br />
		<cfelse>
			<input type="radio" id="gender" name="gender" value="Male" />Male
			<input type="radio" id="gender" name="gender" value="female" />Female<br />
		</cfif>
		<label for="firstName"><b>First Name</b></label><br />
		<input type="text" id="firstName" name="firstName" value="#form.firstName#" /><br />
		<label for="lastName"><b>Last Name</b></label><br />
		<input type="text" id="lastName" name="lastName" value="#form.lastName#" /><br />
		<label for="email"><b>E-mail</b></label><br />
		<input type="email" id="email" name="email" value="#form.email#" /><br />
		<label for="birthDate"><b>Birth Date</b></label><br />
		<input type="date" id="birthDate" name="birthDate" value="#form.birthDate#" /><br />
		<label for="description"><b>Description</b></label><br />
		<textarea id="description" name="description">#form.description#</textarea><br />
		<label for="languages"><b>Languages</b></label><br />
		<input type="text" id="languages" name="languages" value="#form.languages#" /><br />
		<label for="lastName"><b>Technologies</b></label><br />
		<input type="text" id="technologies" name="technologies" value="#form.technologies#" /><br />
		<input type="hidden" name="submitted" value="1" />
		<input type="submit" value="Submit" />
	</form>
</cfoutput>

<cfif form.submitted>
	<cfoutput>
		#form.firstName# #form.lastName# is added successfully. He/She is age years old and speaks #form.languages#.
		You can ask him/her about: #form.technologies# and contact him/her via #form.email#.
	</cfoutput>
</cfif>