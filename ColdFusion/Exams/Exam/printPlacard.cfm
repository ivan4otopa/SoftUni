<cfinclude template="controller.cfm" />

<cfset saveName = "Placard"&URL.placardID&".pdf"/>
<cfset qPlacard = cfcPlacard.getPlacard(URL.placardID) />

<cfoutput>

<cfdocument
	format='PDF'
	localURL='true'
	pagetype='custom'
	saveasname='#saveName#'
	pageHeight='11'
	pageWidth='8.5'
    marginleft=".25"
    marginright=".25"
>

<html>
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
		<title>Print Placard</title>
		<link href="include/pdfstyle.css" rel="stylesheet" type="text/css" />
	</head>

	<body>

	<cfloop from="1" to="#qPlacard.plac_Pallets#" index=i>
		<cfdocumentitem type="footer" evalAtPrint="true">
			<span style="text-align:center; font-size:40px; font-family:Arial, Helvetica, sans-serif;">BATTERIES, NON-HAZARDOUS, NON-SPILLABLE</span>
		</cfdocumentitem>

		<div class="addressFrom">
			<strong>#UCase(qPlacard.plac_fromCompany)#</strong><br/>
			#UCase(qPlacard.plac_fromAddress1)#<br/>

			<cfif qPlacard.plac_fromAddress2 NEQ "">
				#UCase(qPlacard.plac_fromAddress2)#<br/>
			</cfif>

			#UCase(qPlacard.plac_fromCity)#,
			#UCase(qPlacard.plac_fromState)#
			#UCase(qPlacard.plac_fromZip)#<br/>
			#UCase(qPlacard.plac_fromTelephone)#<br/>
		</div>



		<div class="infoing">

        	<br/><br/><br/>

			PALLET <span style="font-size:150px; font-weight:bold">#i#</span> OF #UCase(qPlacard.plac_Pallets)#<br/><br/>

			<cfif qPlacard.plac_TrackingNumber NEQ "">
				PRO ##: #UCase(qPlacard.plac_TrackingNumber)#<br/><br/>
			<cfelse>
				<br/>
			</cfif>

			<cfif qPlacard.plac_PO NEQ "">
				PO: #UCase(qPlacard.plac_PO)#<br/><br>
			<cfelse>
				<br/>
			</cfif>

			<cfif qPlacard.carrier NEQ "">
				Carrier: #qPlacard.carrier#<br /><br>
			<cfelse>
				<br />
			</cfif>
		</div>


		<div class="infoing" style="float:left; width:150px;">SHIP TO:</div>

		<div class="addressTo">

			<strong>#UCase(qPlacard.plac_toCompany)#</strong><br/>
			<cfif qPlacard.plac_toAttentionTo NEQ "">
				ATTN: #UCase(qPlacard.plac_toAttentionTo)#<br/>
			</cfif>
			#UCase(qPlacard.plac_toAddress1)#<br/>
			<cfif qPlacard.plac_toAddress2 NEQ "">
				#UCase(qPlacard.plac_toAddress2)#<br/>
			</cfif>
			#UCase(qPlacard.plac_toCity)#,
			#UCase(qPlacard.plac_toState)#
			#UCase(qPlacard.plac_toZip)#
			<cfif qPlacard.plac_toCountry EQ "Canada">
			, CANADA
			</cfif>
			<br/>
			#UCase(qPlacard.plac_toTelephone)#
		</div>

		<div class="infoing"></div>

		<cfif i NEQ qPlacard.plac_Pallets>
			<cfdocumentitem type="pagebreak"  />
		</cfif>
	</cfloop>

	</body>
</html>

</cfdocument>

</cfoutput>