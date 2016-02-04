<cfinclude template="controller.cfm" />
<cfscript>
	qPlacards = cfcPlacard.getPlacardsByCompany(url.fromCompany);
</cfscript>
<cfoutput>
	<h1>All placards from company #url.fromCompany#</h1>
</cfoutput>
<table border="1">
	<thead>
		<tr>
			<th>Ship From</th>
               <th>Consignee</th>
               <th>Street Address</th>
               <th>City</th>
               <th>State</th>
               <th>Zip</th>
               <th></th>
               <th></th>
               <th></th>
		</tr>
	</thead>
	<tbody>
		<cfoutput>
			<cfloop query="qPlacards">
		    <tr>
		        <td style="text-align:left;height:40px;">#plac_fromCompany#</td>
		        <td style="text-align:center;">#plac_toCompany#</td>
		        <td style="text-align:left;">#plac_toAddress1#</td>
		        <td style="text-align:left;">#plac_toCity#</td>
		        <td>#plac_toState#</td>
		        <td>#plac_toZip#</td>
		        <td><a href="index.cfm?placardID=#plac_id#" title="Select"><img height="15" alt="Select" src="include/img/hand2.png"></a></td>
		        <td><a href="printPlacard.cfm?placardID=#plac_id#" target="_blank" title="Print"><img height="15" alt="Print" src="include/img/pdf_icon.gif"></a></td>
		        <td><a href="?action=delete&placardID=#plac_id#">Delete</a></td>
		    </tr>
		    </cfloop>
		</cfoutput>
		</tbody>
</table>