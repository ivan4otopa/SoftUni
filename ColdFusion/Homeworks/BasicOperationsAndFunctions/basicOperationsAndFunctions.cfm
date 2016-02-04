<cfinclude template="inc/header.cfm">
<cfset arrayOfStructs = [{ firstName = 'Angela', lastName = 'Smith', gender = 'female' }, { firstName = 'Paul', lastName = "Johnson", gender = 'male' }, { firstName = 'Zack', lastName = 'Bennet', gender = 'male' }] />
<cfoutput>
	<table border="1">
		<thead>
			<tr>
				<th>Personal Title</th>
				<th>Full Name</th>
			</tr>
		</thead>
		<tbody>
			<cfloop from="1" to="#arrayLen(arrayOfStructs)#" index="i">
				<tr>
					<cfset personalTitle = '' />
					<cfif arrayOfStructs[i].gender eq "male">
						<cfset personalTitle = "Mr.">
					<cfelse>
						<cfset personalTitle = "Mrs.">
					</cfif>
					<cfset fullName = application.basicOperationsAndFunctionsComponent.getFullName(arrayOfStructs[i].firstName, arrayOfStructs[i].lastName) />
					<td>#personalTitle#</td>
					<td>#fullName#</td>
				</tr>
			</cfloop>
		</tbody>
	</table>
</cfoutput>
<cfinclude template="inc/footer.cfm">