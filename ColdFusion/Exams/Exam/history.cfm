<cfscript>
	qPlacards = cfcPlacard.getPlacards();
</cfscript>

<br>

<h2>Placard History</h2>

<br>

<div id="result">
    <table class="display result" id="placards" >
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
				<th>Report</th>
            </tr>
        </thead>
        <tbody>
            <cfoutput>
            	<cfloop query="qPlacards">
                <tr>
                    <td style="text-align:left;height:40px;">#plac_fromCompany#</td>
                    <td style="text-align:left;">#plac_toCompany#</td>
                    <td style="text-align:left;">#plac_toAddress1#</td>
                    <td style="text-align:left;">#plac_toCity#</td>
                    <td>#plac_toState#</td>
                    <td>#plac_toZip#</td>
                    <td><a href="index.cfm?placardID=#plac_id#" title="Select"><img height="15" alt="Select" src="include/img/hand2.png"></a></td>
                    <td><a href="printPlacard.cfm?placardID=#plac_id#" target="_blank" title="Print"><img height="15" alt="Print" src="include/img/pdf_icon.gif"></a></td>
                    <td><a href="?action=delete&placardID=#plac_id#">Delete</a></td>
					<td><a href="getReport.cfm?fromCompany=#plac_fromCompany#">Report</a></td>
                </tr>
                </cfloop>
            </cfoutput>
        </tbody>
    </table>
</div>