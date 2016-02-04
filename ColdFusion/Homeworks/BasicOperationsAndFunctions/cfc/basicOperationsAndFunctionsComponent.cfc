<cfcomponent>
	<cffunction name="getFullName" access="public" output="false" returntype="string">
		<cfargument name="firstName" type="string" required="true" default="">
		<cfargument name="lastName" type="string" required="true" default=""/>

		<cfset fullName = arguments.firstName & ' ' & arguments.lastName />

		<cfreturn fullName />
	</cffunction>
</cfcomponent>