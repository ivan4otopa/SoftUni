<cfparam name="form.submitted" default="0">
<cfif form.submitted>
	<cffile action="upload" destination="#getTempDirectory()#" filefield="importFile" nameconflict="makeunique" />
	<cfspreadsheet action="read" src="#cffile.ServerDirectory#/#cffile.ServerFile#" query="importData" headerrow="1" excludeheaderrow="true" />
	<cfquery name="importData">
		INSERT INTO address(companyname, contactname, contacttitle, addressline1, city, region, postalcode, country, phone, fax)
		VALUES(
			importData.Company,
			importData.Contact,
			importData.Job,
			importData.Address,
			importData.City,
			importData.Region,
			importData.ZIP,
			importData.Country,
			importData.Phone,
			importData.Fax
		)
	</cfquery>
</cfif>
<form method="post" enctype="multipart/form-data">
	<label for="importFile">Import File</label>
	<input type="file" id="importFile" name="importFile" />
	<button type="submit">Upload</button>
	<input type="hidden" name="submitted" value="1" />
</form>