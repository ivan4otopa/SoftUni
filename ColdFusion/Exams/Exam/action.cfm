<cfparam name="URL.action" default="">

<cfif URL.action is 'delete'>
	<cfscript>
		cfcPlacard.deletePlacard(URL.placardID);
	</cfscript>
</cfif>

<cfif StructKeyExists(FORM, "SaveBtn")>
	<!--- The form was submitted. --->

	<!--- validation for some fields --->
	<cfset validatioPassed = "1" />
	<cfset errMsg = "" />

	<!--- required fields must not be empty --->
	<cfif FORM.fromCompany EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "From company field is empty. " />
	</cfif>
	<cfif FORM.fromAddress1 EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship Address 1 field is empty. " />
	</cfif>
	<cfif FORM.fromCity EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship City field is empty. " />
	</cfif>
	<cfif FORM.fromstate EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship State field is empty. " />
	</cfif>
	<!--- <cfif len(FORM.fromstate) NEQ "2">
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship State field should be 2 letters. " />
	</cfif> --->
	<!--- <cfif FORM.shipzip EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship Zip field is empty. " />
	</cfif> --->
	<cfif len(FORM.fromzip) NEQ "5">
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship Zip field must be 5 digits. " />
	</cfif>
	<cfif FORM.fromtelephone EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Ship Tel field is empty. " />
	</cfif>
	<cfif FORM.toCompany EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Consignee field is empty. " />
	</cfif>
	<cfif FORM.toaddress1 EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Consignee Address 1 field is empty. " />
	</cfif>
	<cfif FORM.tocity EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Consignee City field is empty. " />
	</cfif>
	<cfif len(FORM.tostate) NEQ "2">
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Consignee State field should be 2 letters. " />
	</cfif>

	<cfif len(FORM.tozip) LT "5" OR len(FORM.tozip) GT "7">
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Consignee Zip field must be 5 digits for US or 6 chars for Canada. " />
	</cfif>

	<cfif FORM.toTelephone EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Consignee Tel field is empty. " />
	</cfif>
	<cfif FORM.pallets EQ "" >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Pallets field is empty. " />
	</cfif>
	<cfif !isValid("integer", FORM.pallets) >
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Pallets field is not a number. " />
	<cfelseif FORM.pallets LT "1">
		<cfset validatioPassed = "0" />
		<cfset errMsg &= "Pallets field should be a number greater than 0. " />
	<cfelse>

	</cfif>

	<cfif validatioPassed EQ "0" >

		<cfoutput><br><b>Error: </b>#errMsg#</cfoutput>

	<cfelse>
		<!--- save the fields --->
		<cfset newPlacardID = cfcPlacard.savePlacard(FORM) />

        <cfoutput>
			<script type="text/javascript">
                window.open("printPlacard.cfm?placardID=#newPlacardID#", '_blank');
            </script>
        </cfoutput>

		<!--- THIS PART NEEDS TO BE MODIFIED --->
		<cfoutput><br><strong>PLACARD HAS BEEN SAVED. CLICK <a target = "_blank" href="printPlacard.cfm?placardID=#newPlacardID#"><img height="15" alt="Print" src="include/img/pdf_icon.gif"></a> TO PRINT.</strong><br><br></cfoutput>

	</cfif>
</cfif>
